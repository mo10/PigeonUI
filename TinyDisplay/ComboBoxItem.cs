﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigeonUI
{
    class ComboBoxItem
    {
        public string Text { get; set; }
        public object Tag { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
