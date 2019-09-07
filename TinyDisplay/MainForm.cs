using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TinyDisplay
{
    public partial class MainForm : Form
    {
        SettingsManager settingsManager;
        Plugin curPlugin;
        public MainForm()
        {
            InitializeComponent();
            settingsManager = new SettingsManager();
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
