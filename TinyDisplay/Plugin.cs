using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PigeonUI
{
    [Serializable]
    public class Plugin
    {
        public bool Enabled { get; set; }
        public string Path { get; set; }
        public string Setting { get; set; }
        [XmlIgnore]
        public IPlugin Instance { get; set; }
        [XmlIgnore]
        public Exception Exception { get; set; }
        public Plugin()
        {
            Enabled = false;
            Path = null;
            Setting = null;
            Instance = null;
            Exception = null;
        }
        /// <summary>
        /// Plugin实例化
        /// </summary>
        /// <param name="enabled">插件是否启用</param>
        /// <param name="path">插件路径</param>
        /// <param name="setting">插件设置(序列化后字符串)</param>
        public Plugin(bool enabled=false,string path=null,string setting=null)
        {
            Enabled = enabled;
            Path = path;
            Setting = setting;
        }

        public void Load()
        {
            try
            {
                AssemblyName name = AssemblyName.GetAssemblyName(this.Path);
                Assembly assembly = Assembly.Load(name);
                foreach (Type type in assembly.GetExportedTypes())
                {
                    if (type.Name.Equals("PluginEntity"))
                    {
                        this.Instance = (IPlugin)Activator.CreateInstance(type);
                        break;
                    }
                }
                if(this.Instance == null)
                {
                    this.Exception = new Exception("Plugin entity not found!");
                }
            }catch(Exception e)
            {
                this.Exception = e;
            }
            this.Instance.OnLoad();
        }
    }
}
