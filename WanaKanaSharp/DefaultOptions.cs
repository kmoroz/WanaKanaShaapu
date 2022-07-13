﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp
{
    public class DefaultOptions
    {
        public bool UseObsoleteKana { get; set; }
        public bool PassRomaji { get; set; }
        public bool PassKanji { get; set; } = true;
        public bool UpcaseKatakana { get; set; }
        public dynamic IMEMode { get; set; }
        public string Romanization { get; set; } = "hepburn";
    }
}