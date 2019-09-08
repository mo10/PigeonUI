using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PigeonUI
{
    /// <summary>
    /// 命令
    /// </summary>
    public enum Pigeon_Comm_Cmd : byte
    {
        READ_SETTINGS = 0,
        SAVE_SETTINGS,
    }
    /// <summary>
    /// 数据包装
    /// 
    /// Head+Cmd+Len+附加数据
    /// </summary>
    public struct Pigeon_Comm_Data
    {
        public byte Head;
        public Pigeon_Comm_Cmd Cmd;
        public UInt16 Len;
    }
    /// <summary>
    /// Settings数据包装
    /// </summary>
    public struct Pigeon_Settings
    {
        public byte ProfileIdx;
        public byte KeyDef;
        public byte Brightness;
        public UInt16 ColorTab1;
        public UInt16 ColorTab2;
        public UInt16 ColorTab3;
        public UInt16 ColorTab4;
        public UInt16 RLELen;
        [MarshalAs(UnmanagedType.ByValArray)]
        public UInt16[] RLEData;
    }
    public static class Data
    {
        /// <summary>
        /// 解析数据到 Pigeon_Comm_Data
        /// </summary>
        /// <param name="buf">byte数组</param>
        /// <returns></returns>
        public static Pigeon_Comm_Data DataParse(byte[] buf)
        {
            return ByteArrayToStructure<Pigeon_Comm_Data>(buf);
        }
        /// <summary>
        /// 将byte数组转换为结构体
        /// </summary>
        /// <typeparam name="T">目标结构体</typeparam>
        /// <param name="buf">byte数组</param>
        /// <returns></returns>
        public static T ByteArrayToStructure<T>(byte[] buf) where T : struct
        {
            var handle = GCHandle.Alloc(buf, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }
        /// <summary>
        /// 读取数据实体到指定结构体
        /// </summary>
        /// <typeparam name="T">目标结构体</typeparam>
        /// <param name="buf">byte数组</param>
        /// <returns></returns>
        public static T ParseDataBodyToStructure<T>(byte[] buf) where T : struct
        {
            Pigeon_Comm_Data data = ByteArrayToStructure<Pigeon_Comm_Data>(buf);
            byte[] buf2 = new byte[data.Len];
            // 复制buf+offset 到 buf2
            Buffer.BlockCopy(buf, Marshal.SizeOf(data), buf2, 0, buf2.Length);

            return ByteArrayToStructure<T>(buf2);
        }
        public static byte[] ToBytes<T>(T buf)
        {
            int size = Marshal.SizeOf(buf);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(buf, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }
    }
}
