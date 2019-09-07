using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyDisplay
{
    [Serializable]
    public class AppSettings
    {
        public int BKRed { get; set; }
        public int BKGreen { get; set; }
        public int BKBlue { get; set; }
        public int Brightness { get; set; }
        public string LastDevice { get; set; }
        public List<Plugin> Plugins;
        public AppSettings()
        {
            BKRed = 0;
            BKBlue = 0;
            BKGreen = 0;
            Brightness = 50;
            LastDevice = null;
            Plugins = null;
        }
    }
}
