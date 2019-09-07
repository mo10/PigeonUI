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
        IDeviceNotifier UsbDeviceNotifier = DeviceNotifier.OpenDeviceNotifier();
        WinUsbDevice inUsingDevice;
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
                && inUsingDevice.UsbRegistryInfo.SymbolicName.Equals(e.Device.Name)
                && e.EventType == EventType.DeviceRemoveComplete)
            {
                // Current device removed.
                DeviceDisconnect();
            }
            if (inUsingDevice == null && e.EventType == EventType.DeviceArrival)
                // Need to reload device lise
                ReloadDeviceList();
        }
        /// <summary>
        /// 打开USB设备
        /// </summary>
        /// <param name="usb"></param>
        private void OpenDevice(WinUsbRegistry usb)
        {
            if (usb.Open(out inUsingDevice) && inUsingDevice != null)
            {
                // Update controls
                btn_device_open.Text = "关闭设备";
                cb_device.Enabled = false;

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
            }
        }
        private void DeviceDisconnect()
        {
            EndpointWriter = null;
            EndpointReader = null;
            inUsingDevice = null;

            cb_device.Enabled = true;
            btn_device_open.Text = "打开设备";
        }
        private void ReloadDeviceList()
        {
            UsbRegDeviceList allDevices = WinUsbDevice.AllDevices;

            cb_device.BeginUpdate();
            cb_device.Items.Clear();
            foreach (WinUsbRegistry usbRegistry in allDevices)
            {
                if (usbRegistry.Device == null)
                    continue;
                int vid = usbRegistry.Vid;
                int pid = usbRegistry.Pid;
                string desc = (string)(usbRegistry.DeviceProperties["FriendlyName"].ToString().Length > 0 ? usbRegistry.DeviceProperties["FriendlyName"] : usbRegistry.DeviceProperties["DeviceDesc"]);

                ComboBoxItem item = new ComboBoxItem();
                item.Text = String.Format("{0:X4}:{1:X4} {2}", vid, pid, desc);
                item.Tag = usbRegistry;
                cb_device.Items.Add(item);
            }
            cb_device.EndUpdate();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            settingsManager.LoadSettings();
            settingsManager.LoadPlugins();
            // Load Settings
            btn_setting_backcolor.BackColor = Color.FromArgb(settingsManager.settings.BKRed, settingsManager.settings.BKGreen, settingsManager.settings.BKBlue);
            tbr_setting_brightness.Value = settingsManager.settings.Brightness;
            lv_brightness.Text = tbr_setting_brightness.Value.ToString();
            // Reload Plugin List
            ReloadPluginList();
            // Hook the usb device notifier event
            UsbDeviceNotifier.OnDeviceNotify += OnDeviceNotifyEvent;
            // Load Devices
            ReloadDeviceList();
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

        private void btn_device_open_Click(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cb_device.SelectedItem;
            if (item == null || item.Tag == null)
            {
                MessageBox.Show("Please select a device.");
                return;
            }
            if(inUsingDevice == null)
            {
                WinUsbRegistry usb = (WinUsbRegistry)item.Tag;
                OpenDevice(usb);
            }
            else
            {
                DeviceDisconnect();
            }
            
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

        private void btn_setting_backcolor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            dialog.AllowFullOpen = true;
            // Sets the initial color select to the current text color.
            dialog.Color = btn_setting_backcolor.BackColor;

            // Update the text box color if the user clicks OK 
            if (dialog.ShowDialog() == DialogResult.OK)
                btn_setting_backcolor.BackColor = dialog.Color;
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
    }
}
