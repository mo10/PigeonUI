using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PigeonUI
{
    class SettingsManager
    {
        private string ConfigPath = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), "Settings.xml");

        public AppSettings settings;
        public void LoadSettings()
        {
            AppSettings settings;
            try
            {
                using (TextReader reader = new StreamReader(ConfigPath))
                {
                    var serializer = new XmlSerializer(typeof(AppSettings));
                    settings = (AppSettings)serializer.Deserialize(reader);
                }
            }catch(Exception e)
            {
                settings = new AppSettings();
            }
            this.settings = settings;
        }
        public void LoadPlugins()
        {
            if (settings.Plugins == null)
                return;
            foreach (Plugin plugin in settings.Plugins)
            {
                plugin.Load();
                Console.WriteLine();
            }
        }
        public void AddPlugin(Plugin plugin)
        {
            plugin.Load();
            settings.Plugins.Add(plugin);
            SaveSettings();
        }
        public void SaveSettings()
        {
            using (TextWriter writer = new StreamWriter(ConfigPath))
            {
                var serializer = new XmlSerializer(typeof(AppSettings));
                serializer.Serialize(writer, settings);
            }
        }
        public void RemovePlugin(Plugin plugin)
        {
            this.settings.Plugins.Remove(plugin);
            SaveSettings();
        }
        /// <summary>
        /// 交换元素位置
        /// </summary>
        /// <param name="plugin">目标元素</param>
        /// <param name="idxOffset">位置偏移，上移一个位置-1，下移一个位置+1</param>
        public void Swap(Plugin plugin, int idxOffest)
        {
            int idx = this.settings.Plugins.FindIndex(a => a == plugin);
            int lastIdx = this.settings.Plugins.Count - 1;

            if ((idx > 0 && idxOffest > 0) || (idx < lastIdx && idxOffest < 0))
            {
                Plugin plugin1 = this.settings.Plugins[idx + idxOffest];
                this.settings.Plugins[idx + idxOffest] = plugin;
                this.settings.Plugins[idx] = plugin1;
                this.SaveSettings();

            }
        }
    }
}
