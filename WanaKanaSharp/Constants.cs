namespace WanaKanaSharp
{
    public static class Constants
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

        readonly public static CharacterRange[] JapanesePunctuationRanges = new CharacterRange[]
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

        readonly public static CharacterRange[] MacronCharacterRanges = new CharacterRange[]
        {
            new('\u0100', '\u0101'),
            new('\u0112', '\u0113'),
            new('\u012a', '\u012b'),
            new('\u014C', '\u014D'),
            new('\u016A', '\u016B')
        };

        readonly public static CharacterRange[] KanaCharacterRanges = new CharacterRange[]
        {
            HiraganaChars,
            KatakanaChars
        };

        readonly public static CharacterRange[] JapaneseCharacterRanges = new CharacterRange[]
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

        public static (string Kana, string Transliteration)[] BasicRomaji = new (string Kana, string Transliteration)[]
        {
            ("あ","a"),     ("い", "i"),   ("う", "u"),   ("え", "e"),   ("お", "o"),
            ("か", "ka"),   ("き", "ki"),  ("く", "ku"),  ("け", "ke"),  ("こ", "ko"),
            ("さ", "sa"),   ("し", "shi"), ("す", "su"),  ("せ", "se"),  ("そ", "so"),
            ("た", "ta"),   ("ち", "chi"), ("つ", "tsu"), ("て", "te"),  ("と", "to"),
            ("な", "na"),   ("に", "ni"),  ("ぬ", "nu"),  ("ね", "ne"),  ("の", "no"),
            ("は", "ha"),   ("ひ", "hi"),  ("ふ", "fu"),  ("へ", "he"),  ("ほ", "ho"),
            ("ま", "ma"),   ("み", "mi"),  ("む", "mu"),  ("め", "me"),  ("も", "mo"),
            ("ら", "ra"),   ("り", "ri"),  ("る", "ru"),  ("れ", "re"),  ("ろ", "ro"),
            ("や", "ya"),   ("ゆ", "yu"),  ("よ", "yo"),
            ("わ", "wa"),   ("ゐ", "wi"),  ("ゑ", "we"),  ("を", "wo"),
            ("ん", "n"),
            ("が", "ga"),   ("ぎ", "gi"),  ("ぐ", "gu"),  ("げ", "ge"),  ("ご", "go"),
            ("ざ", "za"),   ("じ", "ji"),  ("ず", "zu"),  ("ぜ", "ze"),  ("ぞ", "zo"),
            ("だ", "da"),   ("ぢ", "ji"),  ("づ", "zu"),  ("で", "de"),  ("ど", "do"),
            ("ば", "ba"),   ("び", "bi"),  ("ぶ", "bu"),  ("べ", "be"),  ("ぼ", "bo"),
            ("ぱ", "pa"),   ("ぴ", "pi"),  ("ぷ", "pu"),  ("ぺ", "pe"),  ("ぽ", "po"),
            ("ゔぁ", "va"), ("ゔぃ", "vi"), ("ゔ", "vu"),  ("ゔぇ", "ve"), ("ゔぉ", "vo")
        };

        public static (string JSymbol, string Symbol)[] SpecialSymbolsJpRomaji = new (string JSymbol, string Symbol)[]
        {
            ("。", "."),
            ("、", ","),
            ("：", ":"),
            ("・", "/"),
            ("！", "!"),
            ("？", "?"),
            ("〜", "~"),
            ("ー", "-"),
            ("「", "‘"),
            ("」", "’"),
            ("『", "“"),
            ("』", "”"),
            ("［", "["),
            ("］", "]"),
            ("（", "("),
            ("）", ")"),
            ("｛", "{"),
            ("｝", "}"),
            ("　", " "),
        };

        public static char[] AmbiguousVowels = { 'あ', 'い', 'う', 'え', 'お', 'や', 'ゆ', 'よ' };

        public static (string Kana, string Transliteration)[] SmallYJpRomaji = new (string Kana, string Transliteration)[]
        {
            ( "ゃ", "ya"), ("ゅ", "yu"), ("ょ", "yo")
        };

        public static (string Kana, string Transliteration)[] smallYExtra = new (string Kana, string Transliteration)[]
        {
            ("ぃ", "yi"), ("ぇ", "ye")
        };

        public static (string Kana, string Transliteration)[] smallAIUEO = new (string Kana, string Transliteration)[]
        {
            ("ぁ", "a"),
            ("ぃ", "i"),
            ("ぅ", "u"),
            ("ぇ", "e"),
            ("ぉ", "o"),
        };

        public static string[] yoonKana =
        {
            "き",
            "に",
            "ひ",
            "み",
            "り",
            "ぎ",
            "び",
            "ぴ",
            "ゔ",
            "く",
            "ふ",
        };

        public static (string Kana, string Transliteration)[] yoonExceptions = new (string Kana, string Transliteration)[]
        {
            ("し", "sh"),
            ("ち", "ch"),
            ("じ", "j"),
            ("ぢ", "j"),
        };

        public static (string Kana, string Transliteration)[] smallKana = new (string Kana, string Transliteration)[]
        {
            ("っ", ""),
            ("ゃ", "ya"),
            ("ゅ", "yu"),
            ("ょ", "yo"),
            ("ぁ", "a"),
            ("ぃ", "i"),
            ("ぅ", "u"),
            ("ぇ", "e"),
            ("ぉ", "o"),
        };

        public static Dictionary<char, string> SokuonWhitelist = new()
        {
            { 'b', "b" },
            { 'c', "t" },
            { 'd', "d" },
            { 'f', "f" },
            { 'g', "g" },
            { 'h', "h" },
            { 'j', "j" },
            { 'k', "k" },
            { 'm', "m" },
            { 'p', "p" },
            { 'q', "q" },
            { 'r', "r" },
            { 's', "s" },
            { 't', "t" },
            { 'v', "v" },
            { 'w', "w" },
            { 'x', "x" },
            { 'z', "z" }
        };

         //{"a", "あ" }, {"i", "い" }, {"u", "う" }, {"e", "え" }, {"o", "お" },
        public static Dictionary<string, (string Romaji, string Kana)[]> BasicKunrei = new ()
        {
            { "a", new (string Romaji, string Kana)[] { ("", "あ") } },
            { "i", new (string Romaji, string Kana)[] { ("", "い") } },
            { "u", new (string Romaji, string Kana)[] { ("", "う") } },
            { "e", new (string Romaji, string Kana)[] { ("", "え") } },
            { "o", new (string Romaji, string Kana)[] { ("", "お") } },
            { "k", new (string Romaji, string Kana)[] { ("a", "か"), ("i", "き"), ("u", "く"), ("e", "け"), ("o", "こ") } },
            { "s", new (string Romaji, string Kana)[] { ("a", "さ"), ("i", "し"), ("u", "す"), ("e", "せ"), ("o", "そ") } },
            { "t", new (string Romaji, string Kana)[] { ("a", "た"), ("i", "ち"), ("u", "つ"), ("e", "て"), ("o", "と") } },
            { "n", new (string Romaji, string Kana)[] { ("a", "な"), ("i", "に"), ("u", "ぬ"), ("e", "ね"), ("o", "の") } },
            { "h", new (string Romaji, string Kana)[] { ("a", "は"), ("i", "ひ"), ("u", "ふ"), ("e", "へ"), ("o", "ほ") } },
            { "m", new (string Romaji, string Kana)[] { ("a", "ま"), ("i", "み"), ("u", "む"), ("e", "め"), ("o", "も") } },
            { "y", new (string Romaji, string Kana)[] { ("a", "や"), ("u", "ゆ"), ("o", "よ") } },
            { "r", new (string Romaji, string Kana)[] { ("a", "ら"), ("i", "り"), ("u", "る"), ("e", "れ"), ("o", "ろ") } },
            { "w", new (string Romaji, string Kana)[] { ("a", "わ"), ("i", "ゐ"), ("e", "ゑ"), ("o", "を"), } },
            { "g", new (string Romaji, string Kana)[] { ("a", "が"), ("i", "ぎ"), ("u", "ぐ"), ("e", "げ"), ("o", "ご") } },
            { "z", new (string Romaji, string Kana)[] { ("a", "ざ"), ("i", "じ"), ("u", "ず"), ("e", "ぜ"), ("o", "ぞ") } },
            { "d", new (string Romaji, string Kana)[] { ("a", "だ"), ("i", "ぢ"), ("u", "づ"), ("e", "で"), ("o", "ど") } },
            { "b", new (string Romaji, string Kana)[] { ("a", "ば"), ("i", "び"), ("u", "ぶ"), ("e", "べ"), ("o", "ぼ") } },
            { "p", new (string Romaji, string Kana)[] { ("a", "ぱ"), ("i", "ぴ"), ("u", "ぷ"), ("e", "ぺ"), ("o", "ぽ") } },
            { "v", new (string Romaji, string Kana)[] { ("a", "ゔぁ"), ("i", "ゔぃ"), ("u", "ゔ"), ("e", "ゔぇ"), ("o", "ゔぉ") } }
        };

        public static (string Symbol, string JSymbol)[] SpecialSymbolsRomajiJp = new (string Symbol, string JSymbol)[]
        {
            (".", "。"),
            (",", "、"),
            (":", "："),
            ("/", "・"),
            ("!", "！"),
            ("?", "？"),
            ("~", "〜"),
            ("-", "ー"),
            ("‘", "「"),
            ("’", "」"),
            ("“", "『"),
            ("”", "』"),
            ("[", "［"),
            ("]", "］"),
            ("(", "（"),
            (")", "）"),
            ("{", "｛"),
            ("}", "｝"),
            (" ", "　"),
        };

        public static (string Romaji, string Kana)[] Consonants = new (string Romaji, string Kana)[]
        {
            ("k", "き"),
            ("s", "し"),
            ("t", "ち"),
            ("n", "に"),
            ("h", "ひ"),
            ("m", "み"),
            ("r", "り"),
            ("g", "ぎ"),
            ("z", "じ"),
            ("d", "ぢ"),
            ("b", "び"),
            ("p", "ぴ"),
            ("v", "ゔ"),
            ("q", "く"),
            ("f", "ふ"),
        };

        public static (string Romaji, string Kana)[] SmallYRomajiJp = new (string Romaji, string Kana)[]
        {
            ("ya", "ゃ"), 
            ("yi", "ぃ"), 
            ("yu", "ゅ"), 
            ("ye", "ぇ"), 
            ("yo", "ょ"),
        };

        public static (string Romaji, string Kana)[] SmallVowels = new (string Romaji, string Kana)[]
        {
            ("a", "ぁ"), 
            ("i", "ぃ"), 
            ("u", "ぅ"), 
            ("e", "ぇ"), 
            ("o", "ぉ"),
        };

        // typing one should be the same as having typed the other instead
        public static (string Alias, string Alternative)[] Aliases = new (string Alias, string Alternative)[]
        {
            ("sh", "sy"), // sha -> sya
            ("ch", "ty"), // cho -> tyo
            ("cy", "ty"), // cyo -> tyo
            ("chy", "ty"), // chyu -> tyu
            ("shy", "sy"), // shya -> sya
            ("j", "zy"), // ja -> zya
            ("jy", "zy"), // jye -> zye

            // exceptions to above rules
            ("shi", "si"),
            ("chi", "ti"),
            ("tsu", "tu"),
            ("ji", "zi"),
            ("fu", "hu"),
        };

        public static (string Romaji, string Kana)[] SmallLetters
        {
            get
            {
                var list = new List<(string Romaji, string Kana)>
                {
                    ("tu", "っ"),
                    ("wa", "ゎ"),
                    ("ka", "ヵ"),
                    ("ke", "ヶ"),
                };

                list.AddRange(SmallVowels);
                list.AddRange(SmallYRomajiJp);

                return list.ToArray();
            }
        }

        // don't follow any notable patterns
        public static (string Romaji, string Kana)[] SpecialCases = new (string Romaji, string Kana)[]
        {
            ("yi", "い"),
            ("wu", "う"),
            ("ye", "いぇ"),
            ("wi", "うぃ"),
            ("we", "うぇ"),
            ("kwa", "くぁ"),
            ("whu", "う"),
            // because it's not thya for てゃ but tha
            // and tha is not てぁ, but てゃ
            ("tha", "てゃ"),
            ("thu", "てゅ"),
            ("tho", "てょ"),
            ("dha", "でゃ"),
            ("dhu", "でゅ"),
            ("dho", "でょ"),
        };

        public static (string Romaji, string Kana)[] AIUEOConstructions = new (string Romaji, string Kana)[]
        {
            ("wh", "う"),
            ("kw", "く"),
            ("qw", "く"),
            ("q", "く"),
            ("gw", "ぐ"),
            ("sw", "す"),
            ("ts", "つ"),
            ("th", "て"),
            ("tw", "と"),
            ("dh", "で"),
            ("dw", "ど"),
            ("fw", "ふ"),
            ("f", "ふ"),
        };


        readonly public static Dictionary<string, string> RomajiHiraganaDictionary = new Dictionary<string, string>()
        {
            {"a",   "あ" },
            {"ba", "ば"},
            {"be", "べ"},
            {"bi", "び" },
            {"bj", "べん"},
            {"bk", "ぶん" },
            {"bna", "びゃ" },
            {"bne", "びぇ"},
            {"bni", "びぃ"},
            {"bnj", "びぇん"},
            {"bnk", "びゅん"},
            {"bno", "びょ"},
            {"bnq", "びょん"},
            {"bnu", "びゅ"},
            {"bnx", "びぃん" },
            {"bo", "ぼ"},
            {"bq", "ぼん"},
            {"bu", "ぶ"},
            {"bx", "びん"},
            {"bya", "びゃ"},
            {"bye", "びぇ"},
            {"byi", "びぃ"},
            {"byo", "びょ"},
            {"byu", "びゅ" },
            {"ca", "か"},
            {"ce", "け"},
            {"cha", "ちゃ"},
            {"che", "ちぇ"},
            {"chi", "ち"},
            {"cho", "ちょ"},
            {"chu", "ちゅ"},
            {"ci", "き"},
            {"cj", "けん"},
            {"ck", "くん"},
            {"cna", "きゃ"},
            {"cne", "きぇ"},
            {"cni", "きぃ"},
            {"cnj", "きぇん"},
            {"cnk", "きゅん" },
            {"cno", "きょ"},
            {"cnq", "きょん"},
            {"cnu", "きゅ"},
            {"cnx", "きぃん"},
            {"co",  "こ"},
            {"cq",  "こん"},
            {"cu",  "く"},
            {"cx",  "きん"},
            {"cya", "ちゃ"},
            {"cye", "ちぇ"},
            {"cyi", "ちぃ"},
            {"cyo", "ちょ"},
            {"cyu", "ちゅ"},
            {"da", "だ"},
            {"de", "で" },
            {"dha", "でゃ" },
            {"dhe", "でぇ"},
            {"dhi", "でぃ"},
            {"dho", "でょ"},
            {"dhu", "でゅ"},
            {"di", "ぢ"},
            {"dj", "でん"},
            {"dk", "づん"},
            {"dna", "ぢゃ"},
            {"dne", "ぢぇ"},
            {"dni", "ぢぃ"},
            {"dnj", "ぢぇん"},
            {"dnk", "ぢゅん"},
            {"dno", "ぢょ"},
            {"dnq", "ぢょん"},
            {"dnu", "ぢゅ"},
            {"dnx", "ぢぃん"},
            {"do", "ど"},
            {"dq", "どん"},
            {"du", "づ"},
            {"dwa", "どぁ"},
            {"dwe", "どぇ"},
            {"dwi", "どぃ"},
            {"dwo", "どぉ"},
            {"dwu", "どぅ"},
            {"dx",  "ぢん" },
            {"dya", "ぢゃ" },
            {"dye", "ぢぇ"},
            {"dyi", "ぢぃ"},
            {"dyo", "ぢょ"},
            {"dyu", "ぢゅ"},
            {"e", "え"},
            {"fa", "ふぁ"},
            {"fe", "ふぇ"},
            {"fi", "ふぃ"},
            {"fj", "ふぇん"},
            {"fk", "ふん"},
            {"fna", "ふゃ"},
            {"fne", "ふぇ"},
            {"fni", "ふぃ"},
            {"fno", "ふょ"},
            {"fnu", "ふゅ" },
            {"fo", "ふぉ" },
            {"fq", "ふぉん" },
            {"fu", "ふ" },
            {"fx", "ふぃん" },
            {"fya", "ふゃ"},
            {"fye", "ふぇ"},
            {"fyi", "ふぃ"},
            {"fyo", "ふょ"},
            {"fyu", "ふゅ" },
            {"ga", "が"},
            {"ge", "げ"},
            {"gi", "ぎ"},
            {"gj", "げん"},
            {"gk", "ぐん"},
            {"gna", "ぎゃ"},
            {"gne", "ぎぇ"},
            {"gni", "ぎぃ" },
            {"gnj", "ぎぇん"},
            {"gnk", "ぎゅん"},
            {"gno", "ぎょ"},
            {"gnq", "ぎょん"},
            {"gnu", "ぎゅ"},
            {"gnx", "ぎぃん"},
            {"go", "ご"},
            {"gq", "ごん" },
            {"gu", "ぐ"},
            {"gwa", "ぐぁ"},
            {"gwe", "ぐぇ"},
            {"gwi", "ぐぃ"},
            {"gwo", "ぐぉ"},
            {"gwu", "ぐぅ"},
            {"gx", "ぎん"},
            {"gya", "ぎゃ"},
            {"gye", "ぎぇ"},
            {"gyi", "ぎぃ"},
            {"gyo", "ぎょ"},
            {"gyu", "ぎゅ" },
            {"ha", "は" },
            {"he", "へ"},
            {"hi", "ひ" },
            {"hj", "へん"},
            {"hk", "ふん"},
            {"hna", "ひゃ"},
            {"hne", "ひぇ"},
            {"hni", "ひぃ" },
            {"hnj", "ひぇん"},
            {"hnk", "ひゅん" },
            {"hno", "ひょ" },
            {"hnq", "ひょん"},
            {"hnu", "ひゅ" },
            {"hnx", "ひぃん"},
            {"ho", "ほ"},
            {"hq", "ほん"},
            {"hu", "ふ"},
            {"hx", "ひん"},
            {"hya", "ひゃ"},
            {"hye", "ひぇ"},
            {"hyi", "ひぃ"},
            {"hyo", "ひょ"},
            {"hyu", "ひゅ" },
            {"i", "い" },
            {"ja", "じゃ"},
            {"je", "じぇ"},
            {"ji", "じ" },
            {"jk", "じゅん" },
            {"jo", "じょ" },
            {"jq", "じょん" },
            {"ju", "じゅ"},
            {"jx", "じん"},
            {"ka", "か"},
            {"ke", "け"},
            {"kha", "きゃ" },
            {"khe", "きぇ"},
            {"khi", "きぃ"},
            {"kho", "きょ"},
            {"khu", "きゅ"},
            {"ki", "き"},
            {"ko", "こ"},
            {"ku", "く" },
            {"kwa", "くぁ"},
            {"kwe", "くぇ"},
            {"kwi", "くぃ"},
            {"kwo", "くぉ"},
            {"kya", "きゃ"},
            {"kye", "きぇ"},
            {"kyi", "きぃ" },
            {"kyj", "きぇん"},
            {"kyk", "きゅん" },
            {"kyo", "きょ" },
            {"kyq", "きょん" },
            {"kyu", "きゅ" },
            {"kyx", "きぃん" },
            {"la", "ぁ"},
            {"le", "ぇ" },
            {"lha", "ゃ"},
            {"lho", "ょ"},
            {"lhu", "ゅ" },
            {"li",  "ぃ" },
            {"lka", "ヵ"},
            {"lke", "ヶ" },
            {"lo", "ぉ" },
            {"ltsu", "っ" },
            {"ltu", "っ" },
            {"lu", "ぅ" },
            {"lwa", "ゎ" },
            {"lya", "ゃ"},
            {"lye", "ぇ"},
            {"lyi", "ぃ"},
            {"lyo", "ょ"},
            {"lyu", "ゅ"},
            {"ma", "ま"},
            {"me", "め"},
            {"mi", "み"},
            {"mj", "めん"},
            {"mk", "むん" },
            {"mna", "みゃ"},
            {"mne", "みぇ"},
            {"mni", "みぃ" },
            {"mnj", "みぇん"},
            {"mnk", "みゅん"},
            {"mno", "みょ" },
            {"mnq", "みょん" },
            {"mnu", "みゅ" },
            {"mnx", "みぃん" },
            {"mo", "も" },
            {"mq", "もん" },
            {"mu", "む" },
            {"mx", "みん" },
            {"mya", "みゃ" },
            {"mye", "みぇ"},
            {"myi", "みぃ"},
            {"myo", "みょ"},
            {"myu", "みゅ"},
            {"n", "ん" },
            {"na", "な"},
            {"ne", "ね"},
            {"nha", "にゃ"},
            {"nhe", "にぇ"},
            {"nhi", "にぃ"},
            {"nhj", "にぇん"},
            {"nhk", "にゅん" },
            {"nho", "にょ" },
            {"nhq", "にょん" },
            {"nhu", "にゅ" },
            {"nhx", "にぃん" },
            {"ni", "に" },
            {"nj", "ねん"},
            {"nk", "ぬん"},
            {"no", "の" },
            {"nq", "のん" },
            {"nu", "ぬ" },
            {"nx", "にん" },
            {"nya", "にゃ" },
            {"nye", "にぇ"},
            {"nyi", "にぃ"},
            {"nyo", "にょ"},
            {"nyu", "にゅ"},
            {"o", "お" },
            {"pa", "ぱ"},
            {"pe", "ぺ" },
            {"pha", "ぴゃ"},
            {"phe", "ぴぇ"},
            {"phi", "ぴぃ" },
            {"phj", "ぴぇん"},
            {"phk", "ぴゅん" },
            {"pho", "ぴょ" },
            {"phq", "ぴょん" },
            {"phu", "ぴゅ" },
            {"phx", "ぴぃん" },
            {"pi", "ぴ" },
            {"pj", "ぺん" },
            {"pk", "ぷん" },
            {"pna", "ぴゃ"},
            {"pne", "ぴぇ"},
            {"pni", "ぴぃ"},
            {"pno", "ぴょ"},
            {"pnu", "ぴゅ" },
            {"po", "ぽ" },
            {"pq", "ぽん" },
            {"pu", "ぷ" },
            {"px", "ぴん" },
            {"pya", "ぴゃ"},
            {"pye", "ぴぇ"},
            {"pyi", "ぴぃ"},
            {"pyo", "ぴょ"},
            {"pyu", "ぴゅ" },
            {"qa", "くぁ"},
            {"qe", "くぇ"},
            {"qi", "くぃ"},
            {"qo", "くぉ" },
            {"ra", "ら"},
            {"re", "れ" },
            {"rha", "りゃ"},
            {"rhe", "りぇ"},
            {"rhi", "りぃ" },
            {"rhj", "りぇん"},
            {"rhk", "りゅん" },
            {"rho", "りょ" },
            {"rhq", "りょん" },
            {"rhu", "りゅ" },
            {"rhx", "りぃん" },
            {"ri", "り" },
            {"rj", "れん" },
            {"rk", "るん" },
            {"ro", "ろ" },
            {"rq", "ろん" },
            {"ru", "る" },
            {"rx", "りん" },
            {"rya", "りゃ"},
            {"rye", "りぇ"},
            {"ryi", "りぃ"},
            {"ryo", "りょ"},
            {"ryu", "りゅ" },
            {"sa", "さ"},
            {"se", "せ" },
            {"sha", "しゃ"},
            {"she", "しぇ"},
            {"shi", "し" },
            {"shj", "しぇん"},
            {"shk", "しゅん"},
            {"sho", "しょ" },
            {"shq", "しょん" },
            {"shu", "しゅ" },
            {"shx", "しぃん" },
            {"si", "し" },
            {"sj", "せん"},
            {"sk", "すん"},
            {"so", "そ" },
            {"sq", "そん" },
            {"su", "す" },
            {"sx", "しん" },
            {"sya", "しゃ"},
            {"sye", "しぇ"},
            {"syi", "しぃ"},
            {"syo", "しょ"},
            {"syu", "しゅ" },
            {"ta", "た"},
            {"te", "て" },
            {"tha", "てゃ"},
            {"the", "てぇ"},
            {"thi", "てぃ"},
            {"tho", "てょ"},
            {"thu", "てゅ" },
            {"ti", "ち" },
            {"tj", "てん"},
            {"tk", "つん"},
            {"tna", "ちゃ"},
            {"tne", "ちぇ"},
            {"tni", "ちぃ"},
            {"tnj", "てぇん"},
            {"tnk", "てゅん"},
            {"tno", "ちょ" },
            {"tnq", "てょん" },
            {"tnu", "ちゅ" },
            {"tnx", "てぃん" },
            {"to",  "と" },
            {"tq",  "とん" },
            {"tsa", "つゃ"},
            {"tse", "つぇ"},
            {"tsi", "つぃ"},
            {"tso", "つょ" },
            {"tsu", "つ" },
            {"tu", "つ" },
            {"twa", "とぁ"},
            {"twe", "とぇ"},
            {"twi", "とぃ"},
            {"two", "とぉ"},
            {"twu", "とぅ" },
            {"tx", "ちん" },
            {"tya", "ちゃ"},
            {"tye", "ちぇ"},
            {"tyi", "ちぃ"},
            {"tyo", "ちょ"},
            {"tyu", "ちゅ" },
            {"u", "う" },
            {"va", "ゔぁ"},
            {"ve", "ゔぇ"},
            {"vye", "ゔぇ"},
            {"vi", "ゔぃ"},
            {"vyi", "ゔぃ"},
            {"vo", "ゔぉ"},
            {"vya", "ゔゃ"},
            {"vyo", "ゔょ"},
            {"vyu", "ゔゅ"},
            {"vu", "ゔ" },
            {"wa", "わ" },
            {"we", "うぇ" },
            {"wha", "うぁ"},
            {"whe", "うぇ"},
            {"whi", "うぃ"},
            {"who", "うぉ"},
            {"whu", "う" },
            {"wu", "う" },
            {"wi", "うぃ" },
            {"wo", "を" },
            {"wye", "ゑ"},
            {"wyi", "ゐ" },
            {"xa", "ぁ"},
            {"xe", "ぇ"},
            {"xi", "ぃ" },
            {"xka", "ヵ"},
            {"xke", "ヶ" },
            {"xn", "ん"},
            {"xo", "ぉ" },
            {"xtsu", "っ" },
            {"xtu", "っ" },
            {"xu",  "ぅ" },
            {"xwa", "ゎ" },
            {"xya", "ゃ" },
            {"xye", "ぇ"},
            {"xyi", "ぃ"},
            {"xyo", "ょ"},
            {"xyu", "ゅ"},
            {"ya", "や" },
            {"ye", "いぇ" },
            {"yi", "い" },
            {"yk", "ゆん" },
            {"yo", "よ" },
            {"yq", "よん" },
            {"yu", "ゆ" },
            {"za", "ざ"},
            {"ze", "ぜ" },
            {"zha", "じゃ" },
            {"zhe", "じぇ" },
            {"zhi", "じぃ" },
            {"zhj", "じぇん"},
            {"zhk", "じゅん" },
            {"zho", "じょ" },
            {"zhq", "じょん" },
            {"zhu", "じゅ" },
            {"zhx", "じぃん" },
            {"zi", "じ" },
            {"zj", "ぜん"},
            {"zk", "ずん"},
            {"zo", "ぞ" },
            {"zq", "ぞん" },
            {"zu", "ず" },
            {"zx", "じん" }
            /*{"a", "あ"},
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

            {"xa" , "ぁ"},
            {"xi" , "ぃ"},
            {"xu" , "ぅ"},
            {"xe" , "ぇ"},
            {"xo" , "ぉ"},
            {"la" , "ぁ"},
            {"li" , "ぃ"},
            {"lu" , "ぅ"},
            {"le" , "ぇ"},
            {"lo" , "ぉ"},
            {"lya", "ゃ"},
            {"lyi", "ぃ"},
            {"lyu", "ゅ"},
            {"lye", "ぇ"},
            {"lyo", "ょ"},
            {"xya", "ゃ"},
            {"xyi", "ぃ"},
            {"xyu", "ゅ"},
            {"xye", "ぇ"},
            {"xyo", "ょ"},

            {"ga", "が"},
            {"gi", "ぎ"},
            {"gu", "ぐ"},
            {"ge", "げ"},
            {"go", "ご"},


            {"za", "ざ"},
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

            {"ye", "いぇ"},
            {"wi", "うぃ"},
            {"we", "うぇ"},
            {"kye", "きぇ"},
            {"kwi", "くぃ"},
            {"kwe", "くぇ"},
            {"kwo", "くぉ"},
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
            {"fyo", "ふょ" }*/
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

            {"xa" , "ァ"}, 
            {"xi" , "ィ"}, 
            {"xu" , "ゥ"}, 
            {"xe" , "ェ"}, 
            {"xo" , "ォ"},
            {"la" , "ァ"}, 
            {"li" , "ィ"}, 
            {"lu" , "ゥ"}, 
            {"le" , "ェ"}, 
            {"lo" , "ォ"},
            {"lya", "ャ"}, 
            {"lyi", "ィ"}, 
            {"lyu", "ュ"}, 
            {"lye", "ェ"}, 
            {"lyo", "ョ"},
            {"xya", "ャ"}, 
            {"xyi", "ィ"}, 
            {"xyu", "ュ"}, 
            {"xye", "ェ"}, 
            {"xyo", "ョ"},

            {"ga", "ガ"},
            {"gi", "ギ"},
            {"gu", "グ"},
            {"ge", "ゲ"},
            {"go", "ゴ"},

            {"za", "ザ"},
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
            {"&", "＆"},
            {"(", "（"},
            {")", "）"},
            {"=", "＝"},
            {"~", "〜"},
            {"|", "｜"},
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