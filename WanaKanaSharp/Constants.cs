namespace WanaKanaSharp
{
    public class Constants
    {
        /*        public static char HiraganaMin = '\u3040';
                public static char HiraganaMax = '\u309f';*/
        public static char KanaMin = '\u3040';
        public static char KanaMax = '\u30ff';
        public static char PunctuationMin = '\u3000';
        public static char PunctuationMax = '\u303f';
        public static char Choonpu = 'ー';
        public static char KanjiMin = '\u4e00';
        public static char KanjiMax = '\u9fa0';
        public static char RomajiMin = '\uff20';
        public static char RomajiMax = '\uff50';
        public static char JapanesePunctuationMin = '\u3000';
        public static char JapanesePunctuationMax = '\u303f';
        public static char ZenzakuMin = '\uff00';
        public static char ZenzakuMax = '\uffef';
        /*        public static char KatakanaMin = '\u30a0';
                public static char KatakanaMax = '\u30ff';*/
        public static string EnglishVowels = "aeiouAEIOU";

        public static CharacterRange HiraganaChars = new CharacterRange('\u3040', '\u309f');
        public static CharacterRange KatakanaChars = new CharacterRange('\u30a0', '\u30ff');
        public static CharacterRange KanjiChars = new CharacterRange('\u4e00', '\u9fa0');
        public static CharacterRange ZenkakuNumbers = new CharacterRange('\uff10', '\uff19');
        public static CharacterRange ZenkakuUppercaseChars = new CharacterRange('\uff21', '\uff3a');
        public static CharacterRange ZenkakuLowercaseChars = new CharacterRange('\uff41', '\uff5a');
        public static CharacterRange ZenkakuCurrencyChars = new CharacterRange('\uffe0', '\uffee');
        public static CharacterRange CJKPunctuationChars = new CharacterRange('\u3000', '\u303f');
        public static CharacterRange RomajiChars = new CharacterRange('\u0000', '\u007f');

        public static CharacterRange[] ZenkakuPunctuation = new CharacterRange[]
        {
            new('\uff01', '\uff0f'),
            new('\uff1a', '\uff1f'),
            new('\uff3b', '\uff3f'),
            new('\uff5b', '\uff60')
        };

        public static CharacterRange[] MacronChars = new CharacterRange[]
        {
            new('\u0100', '\u0101'),
            new('\u0112', '\u0113'),
            new('\u012a', '\u012b'),
            new('\u014C', '\u014D'),
            new('\u016A', '\u016B')
        };



        public static CharacterRange[] KanaChars = new CharacterRange[]
        {
            HiraganaChars,
            KatakanaChars
        };

        public static CharacterRange[] JapaneseChars = new CharacterRange[]
        {
            HiraganaChars,
            KatakanaChars,
            KanjiChars
        };
    }
}
