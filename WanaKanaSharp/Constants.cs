namespace WanaKanaSharp
{
    public class Constants
    {
        #region character ranges

        public const char KanaMin = '\u3040';
        public const char KanaMax = '\u30ff';
        public const char PunctuationMin = '\u3000';
        public const char PunctuationMax = '\u303f';
        public const char Choonpu = 'ー';
        public const char KanjiMin = '\u4e00';
        public const char KanjiMax = '\u9fa0';
        public const char RomajiMin = '\uff20';
        public const char RomajiMax = '\uff50';
        public const char JapanesePunctuationMin = '\u3000';
        public const char JapanesePunctuationMax = '\u303f';
        public const char ZenzakuMin = '\uff00';
        public const char ZenzakuMax = '\uffef';
        public const string EnglishVowels = "aeiouAEIOU";
        public const string SokuonHiragana = "っ";
        public const string SokuonKatakana = "ッ";

        readonly public static CharacterRange HiraganaChars = new CharacterRange('\u3040', '\u309f');
        readonly public static CharacterRange KatakanaChars = new CharacterRange('\u30a0', '\u30ff');
        readonly public static CharacterRange KanjiChars = new CharacterRange('\u4e00', '\u9fa0');
        readonly public static CharacterRange ZenkakuNumbers = new CharacterRange('\uff10', '\uff19');
        readonly public static CharacterRange ZenkakuUppercaseChars = new CharacterRange('\uff21', '\uff3a');
        readonly public static CharacterRange ZenkakuLowercaseChars = new CharacterRange('\uff41', '\uff5a');
        readonly public static CharacterRange ZenkakuCurrencyChars = new CharacterRange('\uffe0', '\uffee');
        readonly public static CharacterRange CJKPunctuationChars = new CharacterRange('\u3000', '\u303f');
        readonly public static CharacterRange RomajiChars = new CharacterRange('\u0000', '\u007f');
        readonly public static CharacterRange ZenkakuPunct1 = new CharacterRange('\uff01', '\uff0f');
        readonly public static CharacterRange ZenkakuPunct2 = new CharacterRange('\uff1a', '\uff1f');
        readonly public static CharacterRange ZenkakuPunct3 = new CharacterRange('\uff3b', '\uff3f');
        readonly public static CharacterRange ZenkakuPunct4 = new CharacterRange('\uff5b', '\uff60');
        readonly public static CharacterRange KanaPunctChars = new CharacterRange('\uff61', '\uff65');
        readonly public static CharacterRange KatakanaPunctChars = new CharacterRange('\u30fb', '\u30fc');

        readonly public static CharacterRange[] JapanesePunctuation = new CharacterRange[]
        {
            ZenkakuPunct1,
            ZenkakuPunct2,
            ZenkakuPunct3,
            ZenkakuPunct4,
            ZenkakuCurrencyChars,
            CJKPunctuationChars,
            KanaPunctChars,
            KatakanaPunctChars
        };

        readonly public static CharacterRange[] MacronChars = new CharacterRange[]
        {
            new('\u0100', '\u0101'),
            new('\u0112', '\u0113'),
            new('\u012a', '\u012b'),
            new('\u014C', '\u014D'),
            new('\u016A', '\u016B')
        };

        readonly public static CharacterRange[] KanaChars = new CharacterRange[]
        {
            HiraganaChars,
            KatakanaChars
        };

        readonly public static CharacterRange[] JapaneseChars = new CharacterRange[]
        {
            HiraganaChars,
            KatakanaChars,
            KanjiChars,
            ZenkakuNumbers,
            ZenkakuUppercaseChars,
            ZenkakuLowercaseChars,
            ZenkakuCurrencyChars,
            ZenkakuPunct1,
            ZenkakuPunct2,
            ZenkakuPunct3,
            ZenkakuPunct4,
            CJKPunctuationChars,
            KanaPunctChars,
            KatakanaPunctChars
        };

        #endregion

        #region dictionaries

        readonly public static Dictionary<string, string> RomajiHiraganaDictionary = new Dictionary<string, string>()
        {
            {"a", "あ"},
            {"i", "い"},
            {"u", "う"},
            {"e", "え"},
            {"o", "お"},

            {"ka", "か"},
            {"ki", "き"},
            {"ku", "く"},
            {"ke", "け"},
            {"ko", "こ"},

            {"sa", "さ"},
            {"si", "し"},
            {"su", "す"},
            {"se", "せ"},
            {"so", "そ"},

            {"ta", "た"},
            {"ti", "ち"},
            {"tu", "つ"},
            {"tsu", "つ"},
            {"te", "て"},
            {"to", "と"},

            {"na", "な"},
            {"ni", "に"},
            {"nu", "ぬ"},
            {"ne", "ね"},
            {"no", "の"},
            {"n", "ん"},

            {"ha", "は"},
            {"hi", "ひ"},
            {"hu", "ふ"},
            {"he", "へ"},
            {"ho", "ほ"},

            {"ma", "ま"},
            {"mi", "み"},
            {"mu", "む"},
            {"me", "め"},
            {"mo", "も"},

            {"ya", "や"},
            {"yu", "ゆ"},
            {"yo", "よ"},

            {"ra", "ら"},
            {"ri", "り"},
            {"ru", "る"},
            {"re", "れ"},
            {"ro", "ろ"},

            {"wa", "わ"},
            {"wo", "を"},

            {"ga", "が"},
            {"gi", "ぎ"},
            {"gu", "ぐ"},
            {"ge", "げ"},
            {"go", "ご"},


            {"za", "ざ"},
            {"zi", "じ"},
            {"ji", "じ"},
            {"zu", "ず"},
            {"ze", "ぜ"},
            {"zo", "ぞ"},

            {"da", "だ"},
            {"di", "ぢ"},
            {"du", "づ"},
            {"de", "で"},
            {"do", "ど"},

            {"ba", "ば"},
            {"bi", "び"},
            {"bu", "ぶ"},
            {"be", "べ"},
            {"bo", "ぼ"},

            {"pa", "ぱ"},
            {"pi", "ぴ"},
            {"pu", "ぷ"},
            {"pe", "ぺ"},
            {"po", "ぽ"},

            {"kya", "きゃ"},
            {"kyu", "きゅ"},
            {"kyo", "きょ"},

            {"sya", "しゃ"},
            {"syu", "しゅ"},
            {"syo", "しょ"},

            {"tya", "ちゃ"},
            {"tyu", "ちゅ"},
            {"tyo", "ちょ"},

            {"nya", "にゃ"},
            {"nyu", "にゅ"},
            {"nyo", "にょ"},

            {"hya", "ひゃ"},
            {"hyu", "ひゅ"},
            {"hyo", "ひょ"},

            {"mya", "みゃ"},
            {"myu", "みゅ"},
            {"myo", "みょ"},

            {"rya", "りゃ"},
            {"ryu", "りゅ"},
            {"ryo", "りょ"},

            {"gya", "ぎゃ"},
            {"gyu", "ぎゅ"},
            {"gyo", "ぎょ"},

            {"zya", "じゃ"},
            {"zyu", "じゅ"},
            {"zyo", "じょ"},

            {"dya", "ぢゃ"},
            {"dyu", "ぢゅ"},
            {"dyo", "ぢょ"},

            {"bya", "びゃ"},
            {"byu", "びゅ"},
            {"byo", "びょ"},

            {"pya", "ぴゃ"},
            {"pyu", "ぴゅ"},
            {"pyo", "ぴょ"},

            {"kwa", "くゎ"},
            {"gwa", "ぐゎ"},

/*          {"a", "ぁ"},
            {"i", "ぃ"},
            {"u", "ぅ"},
            {"e", "ぇ"},
            {"o", "ぉ"},
            {"ya", "ゃ"},
            {"yu", "ゅ"},
            {"yo", "ょ"},
            {"wa", "ゎ"},*/

            {"ye", "いぇ"},
            {"wi", "うぃ"},
            {"we", "うぇ"},
/*          {"wo", "うぉ"},*/
            {"kye", "きぇ"},
/*          {"kwa", "くぁ"},*/
            {"kwi", "くぃ"},
            {"kwe", "くぇ"},
            {"kwo", "くぉ"},
/*          {"gwa", "ぐぁ"},*/
            {"gwi", "ぐぃ"},
            {"gwe", "ぐぇ"},
            {"gwo", "ぐぉ"},

            {"she", "しぇ"},
            {"je", "じぇ"},
            {"che", "ちぇ"},
            {"tsa", "つぁ"},
            {"tsi", "つぃ"},
            {"tse", "つぇ"},
            {"tso", "つぉ"},
            {"thi", "てぃ"},
            {"thu", "てゅ"},
            {"dhi", "でぃ"},
            {"dhu", "でゅ"},
            {"two", "とぅ"},
            {"dwu", "どぅ"},
            {"nye", "にぇ"},
            {"hye", "ひぇ"},
            {"fa", "ふぁ"},
            {"fi", "ふぃ"},
            {"fe", "ふぇ"},
            {"fo", "ふぉ"},
            {"fyu" , "ふゅ"},
            {"fyo", "ふょ" }
        };

        readonly public static Dictionary<string, string> RomajiKatakanaDictionary = new Dictionary<string, string>()
        {
            {"a", "ア"},
            {"i", "イ"},
            {"u", "ウ"},
            {"e", "エ"},
            {"o", "オ"},

            {"ka", "カ"},
            {"ki", "キ"},
            {"ku", "ク"},
            {"ke", "ケ"},
            {"ko", "コ"},

            {"sa", "サ"},
            {"si", "シ"},
            {"su", "ス"},
            {"se", "セ"},
            {"so", "ソ"},

            {"ta", "タ"},
            {"ti", "チ"},
            {"tu", "ツ"},
            {"tsu", "ツ"},
            {"te", "テ"},
            {"to", "ト"},

            {"na", "ナ"},
            {"ni", "ニ"},
            {"nu", "ヌ"},
            {"ne", "ネ"},
            {"no", "ノ"},
            {"n", "ン" },

            {"ha", "ハ"},
            {"hi", "ヒ"},
            {"hu", "フ"},
            {"he", "ヘ"},
            {"ho", "ホ"},

            {"ma", "マ"},
            {"mi", "ミ"},
            {"mu", "ム"},
            {"me", "メ"},
            {"mo", "モ"},

            {"ya", "ヤ"},
            {"yu", "ユ"},
            {"yo", "ヨ"},

            {"ra", "ラ"},
            {"ri", "リ"},
            {"ru", "ル"},
            {"re", "レ"},
            {"ro", "ロ"},

            {"wa", "ワ"},
            {"wo", "ヲ"},

            {"ga", "ガ"},
            {"gi", "ギ"},
            {"gu", "グ"},
            {"ge", "ゲ"},
            {"go", "ゴ"},


            {"za", "ザ"},
            {"zi", "ジ"},
            {"ji", "ジ"},
            {"zu", "ズ"},
            {"ze", "ゼ"},
            {"zo", "ゾ"},

            {"da", "ダ"},
            {"di", "ヂ"},
            {"du", "ヅ"},
            {"de", "デ"},
            {"do", "ド"},

            {"ba", "バ"},
            {"bi", "ビ"},
            {"bu", "ブ"},
            {"be", "ベ"},
            {"bo", "ボ"},

            {"pa", "パ"},
            {"pi", "ピ"},
            {"pu", "プ"},
            {"pe", "ペ"},
            {"po", "ポ"},

            {"kya", "キャ"},
            {"kyu", "キュ"},
            {"kyo", "キョ"},

            {"sya", "シャ"},
            {"syu", "シュ"},
            {"syo", "ショ"},

            {"tya", "チャ"},
            {"tyu", "チュ"},
            {"tyo", "チョ"},

            {"nya", "ニャ"},
            {"nyu", "ニュ"},
            {"nyo", "ニョ"},

            {"hya", "ヒャ"},
            {"hyu", "ヒュ"},
            {"hyo", "ヒョ"},

            {"mya", "ミャ"},
            {"myu", "ミュ"},
            {"myo", "ミョ"},

            {"rya", "リャ"},
            {"ryu", "リュ"},
            {"ryo", "リョ"},

            {"gya", "ギャ"},
            {"gyu", "ギュ"},
            {"gyo", "ギョ"},

            {"zya", "ジャ"},
            {"zyu", "ジュ"},
            {"zyo", "ジョ"},

            {"dya", "ヂャ"},
            {"dyu", "ヂュ"},
            {"dyo", "ヂョ"},

            {"bya", "ビャ"},
            {"byu", "ビュ"},
            {"byo", "ビョ"},

            {"pya", "ピャ"},
            {"pyu", "ピュ"},
            {"pyo", "ピョ"},

            {"kwa", "クヮ"},
            {"gwa", "グヮ"},

/*            {"ァ", "a"},
            {"ィ", "i"},
            {"ゥ", "u"},
            {"ェ", "e"},
            {"ォ", "o"},
            {"ャ", "ya"},
            {"ュ", "yu"},
            {"ョ", "yo"},
            {"ヮ", "wa"},
            {"ヵ", "ka"},
            {"ヶ", "ke"},*/

            {"ye","イェ"},
            {"wi","ウィ"},
            {"whe","ウェ"},
            {"who","ウォ"},
            {"vu","ヴ"},
            {"va","ヴァ"},
            {"vi","ヴィ"},
            {"ve","ヴェ"},
            {"vo","ヴォ"},
            {"vyu","ヴュ"},
            {"vyo","ヴョ"},
            {"kye","キェ"},
            {"qa","クァ"},
            {"qi","クィ"},
            {"qe","クェ"},
            {"qo","クォ"},
            {"gua","グァ"},
            {"gui", "グィ"},
            {"gue", "グェ"},
            {"guo", "グォ"},

            {"she", "シェ"},
            {"je", "ジェ"},
            {"che", "チェ"},
            {"tsa", "ツァ"},
            {"tsi", "ツィ"},
            {"tse", "ツェ"},
            {"tso", "ツォ"},
            {"thi", "ティ"},
            {"thu", "テュ"},
            {"dhi", "ディ"},
            {"dhu", "デュ"},
            {"two", "トゥ"},
            {"dwu", "ドゥ"},
            {"nye", "ニェ"},
            {"hye", "ヒェ"},
            {"fa", "ファ"},
            {"fi", "フィ"},
            {"fe", "フェ"},
            {"fo", "フォ"},
            {"fyu", "フュ"},
            {"fyo", "フョ"}
        };

        readonly public static Dictionary<string, string> WhitespacePunctuationDictionary = new Dictionary<string, string>()
        {
            {" ", "　"},
            {"!", "！"},
            {"#", "＃"},
            {"$", "＄"},
            {"%", "％"},
            {"&", "＆"},
            {"(", "（"},
            {")", "）"},
            {"=", "＝"},
            {"~", "〜"},
            {"|", "｜"},
            {"@", "＠"},
            {"`", "‘"},
            {"+", "＋"},
            {"*", "＊"},
            {";", "；"},
            {":", "："},
            {"<", "＜"},
            {">", "＞"},
            {",", "、"},
            {".", "。"},
            {"/", "／"},
            {"?", "？"},
            {"_", "＿"},
            {"･", "・"},
            {"‘", "「"},
            {"’", "」"},
            {"{", "｛"},
            {"}", "｝"},
            {"^", "＾"},
            {"-", "ー"},
            {"“", "『"},
            {"”", "』"},
            {"[", "［"},
            {"]", "］"}
        };

        readonly public static Dictionary<string, string> RomajiObsoleteHiraganaDictionary = new Dictionary<string, string>()
        {
            {"wi", "ゐ"},
            {"we", "ゑ" }
        };

        readonly public static Dictionary<string, string> RomajiObsoleteKatakanaDictionary = new Dictionary<string, string>()
        {
            {"wi", "ヰ"},
            {"we", "ヱ" }
        };

        #endregion
    }
}