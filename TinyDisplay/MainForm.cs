using LibUsbDotNet;
using LibUsbDotNet.DeviceNotify;
using LibUsbDotNet.Main;
using LibUsbDotNet.WinUsb;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PigeonUI
{
    public partial class MainForm : Form
    {
        SettingsManager settingsManager;
        Plugin curPlugin;

        UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(0x1209, 0x2700);
        IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
        UsbDevice inUsingDevice;
        UsbEndpointWriter EndpointWriter;
        UsbEndpointReader EndpointReader;
        public MainForm()
        {
            InitializeComponent();
            settingsManager = new SettingsManager();
        }
        private void OnDeviceNotifyEvent(object sender, DeviceNotifyEventArgs e)
        {
            if (inUsingDevice != null
                && inUsingDevice.UsbRegistryInfo.IsAlive == false
                && e.EventType == EventType.DeviceRemoveComplete)
            {
                // Current device removed.
                DeviceDisconnect();
            }
            if (inUsingDevice == null && e.EventType == EventType.DeviceArrival)
                // Try to open device
                OpenDevice();
        }
        private static void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        {
            Pigeon_Comm_Data data = Data.DataParse(e.Buffer);
            if (data.Head == 0x66)
            {
                Pigeon_Settings settingss = new Pigeon_Settings();
                settingss.Brightness = 10;
                settingss.ProfileIdx = 0;
                settingss.KeyDef = 3;
                settingss.RLELen = 615;
                byte[] a = Data.ToBytes(settingss);
                Pigeon_Settings settings = Data.ParseDataBodyToStructure<Pigeon_Settings>(e.Buffer);
                if (settings.Brightness == 1)
                {

                }
            }
        }
        /// <summary>
        /// 打开USB设备
        /// </summary>
        /// <param name="usb"></param>
        private void OpenDevice()
        {
            if (inUsingDevice != null)
                return;
            // Open Device
            inUsingDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);
            if (inUsingDevice != null)
            {
                IUsbDevice wholeUsbDevice = inUsingDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);
                    // Claim interface #0.
                    wholeUsbDevice.ClaimInterface(0);
                }
                EndpointWriter = inUsingDevice.OpenEndpointWriter(WriteEndpointID.Ep02);
                EndpointReader = inUsingDevice.OpenEndpointReader(ReadEndpointID.Ep02);

                EndpointReader.DataReceived += (OnRxEndPointData);
                EndpointReader.DataReceivedEnabled = true;
                // Update controls
                lb_status.Text = "已连接";
                lb_status.ForeColor = Color.Green;

                Pigeon_Comm_Data data = new Pigeon_Comm_Data();
                data.Head = 0x66;
                data.Cmd = Pigeon_Comm_Cmd.READ_SETTINGS;
                data.Len = 0;
                //
                byte[] vs = Data.ToBytes(data);
                // Send to device
                int bytesWritten;
                EndpointWriter.Write(vs, 1000, out bytesWritten);
            }
        }
        private void DeviceDisconnect()
        {
            if (inUsingDevice != null && inUsingDevice.IsOpen)
            {
                EndpointReader.DataReceivedEnabled = false;
                EndpointReader.DataReceived -= (OnRxEndPointData);
                IUsbDevice wholeUsbDevice = inUsingDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // Release interface #0.
                    wholeUsbDevice.ReleaseInterface(0);
                }
                inUsingDevice.Close();
            }
            EndpointWriter = null;
            EndpointReader = null;
            inUsingDevice = null;

            // Update controls
            lb_status.Text = "未连接";
            lb_status.ForeColor = Color.Red;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            settingsManager.LoadSettings();
            settingsManager.LoadPlugins();
            // Load Settings
            tbr_setting_brightness.Value = settingsManager.settings.Brightness;
            lv_brightness.Text = tbr_setting_brightness.Value.ToString();
            // Reload Plugin List
            ReloadPluginList();
            // Hook the usb device notifier event
            UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
            // Load Devices
            OpenDevice();
        }
        private void ReloadPluginList()
        {
            lv_plugins.BeginUpdate();
            lv_plugins.Items.Clear();
            if (settingsManager.settings.Plugins != null)
            foreach (Plugin plugin in settingsManager.settings.Plugins)
            {
                ListViewItem moduleItem;
                if (plugin.Instance == null)
                    moduleItem = new ListViewItem("<Load Failed>", "ModuleError_16x");
                else
                    moduleItem = new ListViewItem(plugin.Instance.Name, "Module_16x");
                moduleItem.Tag = plugin;
                moduleItem.Checked = plugin.Enabled;
                lv_plugins.Items.Add(moduleItem);
            }
            lv_plugins.EndUpdate();
        }
        private void ShowPluginInfo(Plugin plugin)
        {
            curPlugin = plugin;
            lb_plugin_enabled.Text = plugin.Enabled ? "是" : "否";
            lb_plugin_name.Text = (plugin.Instance == null ? "Unknown" : plugin.Instance.Name);
            lb_plugin_author.Text = (plugin.Instance == null ? "Unknown" : plugin.Instance.Author);
            lb_plugin_version.Text = (plugin.Instance == null ? "Unknown" : plugin.Instance.Version);
            lb_plugin_path.Text = plugin.Path;
            tb_plugin_desc.Text = (plugin.Instance == null ? plugin.Exception.Message.ToString() : plugin.Instance.Description);
        }
        private void btn_addPlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择插件";        
            dialog.Filter = "插件文件(*.dll)|*.dll";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach(var file in dialog.FileNames)
                {
                    Plugin plugin = new Plugin(false, file);
                    settingsManager.AddPlugin(plugin);
                }
                // Reload Plugin List
                ReloadPluginList();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lv_brightness.Text = tbr_setting_brightness.Value.ToString();
        }

        private void btn_plugin_remove_Click(object sender, EventArgs e)
        {
            if (lv_plugins.SelectedItems.Count > 0)
            {
                DialogResult dr = MessageBox.Show("确认移除插件吗？\n\n该操作不会删除插件文件。", "确认", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    settingsManager.RemovePlugin((Plugin)lv_plugins.Items[lv_plugins.SelectedItems[0].Index].Tag);
                    // Reload Plugin List
                    ReloadPluginList();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void lv_plugins_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            
            Plugin plugin = (Plugin)e.Item.Tag;
            plugin.Enabled = e.Item.Checked;
            settingsManager.SaveSettings();
        }

        private void lv_plugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_plugins.SelectedItems.Count > 0)
            {
                ShowPluginInfo((Plugin)lv_plugins.SelectedItems[0].Tag);
            }
        }

        private void Btn_plugin_setting_Click(object sender, EventArgs e)
        {
            Plugin plugin = (Plugin)lv_plugins.SelectedItems[0].Tag;
            if (plugin != null && plugin.Instance != null)
                plugin.Instance.OnShowSettingUI();
        }

        private void Btn_plugin_up_Click(object sender, EventArgs e)
        {
            Plugin plugin = (Plugin)lv_plugins.SelectedItems[0].Tag;
            int idx = settingsManager.settings.Plugins.FindIndex(a => a == plugin);
            if(idx > 0)
            {
                Plugin plugin1 = settingsManager.settings.Plugins[idx - 1];
                settingsManager.settings.Plugins[idx - 1] = plugin;
                settingsManager.settings.Plugins[idx] = plugin1;
                settingsManager.SaveSettings();
                // Reload Plugin List
                ReloadPluginList();
                lv_plugins.Items[idx - 1].Selected = true;
                lv_plugins.Select();
            }
        }

        private void Btn_plugin_down_Click(object sender, EventArgs e)
        {
            Plugin plugin = (Plugin)lv_plugins.SelectedItems[0].Tag;
            int idx = settingsManager.settings.Plugins.FindIndex(a => a == plugin);
            int lastIdx = settingsManager.settings.Plugins.Count - 1;
            if (idx < lastIdx)
            {
                Plugin plugin1 = settingsManager.settings.Plugins[idx + 1];
                settingsManager.settings.Plugins[idx + 1] = plugin;
                settingsManager.settings.Plugins[idx] = plugin1;
                settingsManager.SaveSettings();
                // Reload Plugin List
                ReloadPluginList();
                lv_plugins.Items[idx + 1].Selected = true;
                lv_plugins.Select();
            }
        }

        private void Btn_plugin_url_Click(object sender, EventArgs e)
        {
            if (curPlugin.Instance != null && curPlugin.Instance.Url != null)
            {
                System.Diagnostics.Process.Start(curPlugin.Instance.Url);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeviceDisconnect();
            UsbDevice.Exit();
        }
    }
}
