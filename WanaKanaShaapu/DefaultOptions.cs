using System.Collections.Generic;

namespace WanaKanaShaapu
{
    public class DefaultOptions
    {
        public bool UseObsoleteKana { get; set; }
        public bool PassRomaji { get; set; }
        public bool ConvertLongVowelMark { get; set; } = true;
        public bool UpcaseKatakana { get; set; }
        public dynamic IMEMode { get; set; }
        public string Romanization { get; set; } = "hepburn";
        public Dictionary<string, string> CustomKanaMapping = new Dictionary<string, string>();
        public Dictionary<string, string> CustomRomajiMapping = new Dictionary<string, string>();
    }
}