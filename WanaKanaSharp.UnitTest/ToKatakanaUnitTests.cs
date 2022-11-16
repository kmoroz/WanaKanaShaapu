﻿using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToKatakanaUnitTests
    {
        [TestCase("", "")]
        public void ToKatakana_WhenPassedAnEmptyString_ReturnsAnEmptyString(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("a", "ア")]
        [TestCase("i", "イ")]
        [TestCase("u", "ウ")]
        [TestCase("e", "エ")]
        [TestCase("o", "オ")]
        [TestCase("la", "ァ")]
        [TestCase("xa", "ァ")]
        [TestCase("li", "ィ")]
        [TestCase("xi", "ィ")]
        [TestCase("lu", "ゥ")]
        [TestCase("xu", "ゥ")]
        [TestCase("le", "ェ")]
        [TestCase("xe", "ェ")]
        [TestCase("lo", "ォ")]
        [TestCase("xo", "ォ")]
        [TestCase("yi", "イ")]
        [TestCase("wu", "ウ")]
        [TestCase("whu", "ウ")]
        [TestCase("xa", "ァ")]
        [TestCase("xi", "ィ")]
        [TestCase("xu", "ゥ")]
        [TestCase("xe", "ェ")]
        [TestCase("xo", "ォ")]
        [TestCase("xyi", "ィ")]
        [TestCase("xye", "ェ")]
        [TestCase("ye" , "イェ")]
        [TestCase("wha", "ウァ")]
        [TestCase("whi", "ウィ")]
        [TestCase("whe", "ウェ")]
        [TestCase("who", "ウォ")]
        [TestCase("wi", "ウィ")]
        [TestCase("we", "ウェ")]
        [TestCase("va", "ヴァ")]
        [TestCase("vi", "ヴィ")]
        [TestCase("vu", "ヴ")]
        [TestCase("ve", "ヴェ")]
        [TestCase("vo", "ヴォ")]
        [TestCase("vyi", "ヴィ")]
        [TestCase("vye", "ヴェ")]
        [TestCase("vya", "ヴャ")]
        [TestCase("vyu", "ヴュ")]
        [TestCase("vyo", "ヴョ")]
        [TestCase("ka", "カ")]
        [TestCase("ki", "キ")]
        [TestCase("ku", "ク")]
        [TestCase("ke", "ケ")]
        [TestCase("ko", "コ")]
        [TestCase("lka", "ヵ")]
        [TestCase("lke", "ヶ")]
        [TestCase("xka", "ヵ")]
        [TestCase("xke", "ヶ")]
        [TestCase("kya", "キャ")]
        [TestCase("kyi", "キィ")]
        [TestCase("kyu", "キュ")]
        [TestCase("kye", "キェ")]
        [TestCase("kyo", "キョ")]
        [TestCase("ca" , "カ")]
        [TestCase("ci" , "キ")]
        [TestCase("cu" , "ク")]
        [TestCase("ce" , "ケ")]
        [TestCase("co" , "コ")]
        [TestCase("lca", "ヵ")]
        [TestCase("lce", "ヶ")]
        [TestCase("xca", "ヵ")]
        [TestCase("xce", "ヶ")]
        [TestCase("qya", "クャ")]
        [TestCase("qyu", "クュ")]
        [TestCase("qyo", "クョ")]
        [TestCase("qwa", "クァ")]
        [TestCase("qwi", "クィ")]
        [TestCase("qwu", "クゥ")]
        [TestCase("qwe", "クェ")]
        [TestCase("qwo", "クォ")]
        [TestCase("qa", "クァ")]
        [TestCase("qi", "クィ")]
        [TestCase("qe", "クェ")]
        [TestCase("qo", "クォ")]
        [TestCase("kwa" , "クァ")]
        [TestCase("kwi" , "クィ")]
        [TestCase("kwe" , "クェ")]
        [TestCase("kwo" , "クォ")]
        [TestCase("qyi" , "クィ")]
        [TestCase("qye" , "クェ")]
        [TestCase("ga", "ガ")]
        [TestCase("gi", "ギ")]
        [TestCase("gu", "グ")]
        [TestCase("ge", "ゲ")]
        [TestCase("go", "ゴ")]
        [TestCase("gya", "ギャ")]
        [TestCase("gyi", "ギィ")]
        [TestCase("gyu", "ギュ")]
        [TestCase("gye", "ギェ")]
        [TestCase("gyo", "ギョ")]
        [TestCase("gwa", "グァ")]
        [TestCase("gwi", "グィ")]
        [TestCase("gwu", "グゥ")]
        [TestCase("gwe", "グェ")]
        [TestCase("gwo", "グォ")]
        [TestCase("sa", "サ")]
        [TestCase("si", "シ")]
        [TestCase("su", "ス")]
        [TestCase("se", "セ")]
        [TestCase("so", "ソ")]
        [TestCase("shi", "シ")]
        [TestCase("za", "ザ")]
        [TestCase("zi", "ジ")]
        [TestCase("zu", "ズ")]
        [TestCase("ze", "ゼ")]
        [TestCase("zo", "ゾ")]
        [TestCase("ji", "ジ")]
        [TestCase("sya", "シャ")]
        [TestCase("syi", "シィ")]
        [TestCase("syu", "シュ")]
        [TestCase("sye", "シェ")]
        [TestCase("syo", "ショ")]
        [TestCase("sha", "シャ")]
        [TestCase("shu", "シュ")]
        [TestCase("she", "シェ")]
        [TestCase("sho", "ショ")]
        [TestCase("shya", "シャ")]
        [TestCase("shyu", "シュ")]
        [TestCase("shye", "シェ")]
        [TestCase("shyo", "ショ")]
        [TestCase("swa", "スァ")]
        [TestCase("swi", "スィ")]
        [TestCase("swu", "スゥ")]
        [TestCase("swe", "スェ")]
        [TestCase("swo", "スォ")]
        [TestCase("zya", "ジャ")]
        [TestCase("zyi", "ジィ")]
        [TestCase("zyu", "ジュ")]
        [TestCase("zye", "ジェ")]
        [TestCase("zyo", "ジョ")]
        [TestCase("ja", "ジャ")]
        [TestCase("ju", "ジュ")]
        [TestCase("je", "ジェ")]
        [TestCase("jo", "ジョ")]
        [TestCase("jya", "ジャ")]
        [TestCase("jyi", "ジィ")]
        [TestCase("jyu", "ジュ")]
        [TestCase("jye", "ジェ")]
        [TestCase("jyo", "ジョ")]
        [TestCase("ta", "タ")]
        [TestCase("ti", "チ")]
        [TestCase("tu", "ツ")]
        [TestCase("te", "テ")]
        [TestCase("to", "ト")]
        [TestCase("chi", "チ")]
        [TestCase("tsu", "ツ")]
        [TestCase("ltu", "ッ")]
        [TestCase("xtu", "ッ")]
        [TestCase("ltsu", "ッ")]
        [TestCase("tya", "チャ")]
        [TestCase("tyi", "チィ")]
        [TestCase("tyu", "チュ")]
        [TestCase("tye", "チェ")]
        [TestCase("tyo", "チョ")]
        [TestCase("cha", "チャ")]
        [TestCase("chu", "チュ")]
        [TestCase("che", "チェ")]
        [TestCase("cho", "チョ")]
        [TestCase("cya", "チャ")]
        [TestCase("cyi", "チィ")]
        [TestCase("cyu", "チュ")]
        [TestCase("cye", "チェ")]
        [TestCase("cyo", "チョ")]
        [TestCase("chya", "チャ")]
        [TestCase("chyu", "チュ")]
        [TestCase("chye", "チェ")]
        [TestCase("chyo", "チョ")]
        [TestCase("tsa", "ツァ")]
        [TestCase("tsi", "ツィ")]
        [TestCase("tse", "ツェ")]
        [TestCase("tso", "ツォ")]
        [TestCase("tha", "テャ")]
        [TestCase("thi", "ティ")]
        [TestCase("thu", "テュ")]
        [TestCase("the", "テェ")]
        [TestCase("tho", "テョ")]
        [TestCase("twa", "トァ")]
        [TestCase("twi", "トィ")]
        [TestCase("twu", "トゥ")]
        [TestCase("twe", "トェ")]
        [TestCase("two", "トォ")]
        [TestCase("da", "ダ")]
        [TestCase("di", "ヂ")]
        [TestCase("du", "ヅ")]
        [TestCase("de", "デ")]
        [TestCase("do", "ド")]
        [TestCase("dya", "ヂャ")]
        [TestCase("dyi", "ヂィ")]
        [TestCase("dyu", "ヂュ")]
        [TestCase("dye", "ヂェ")]
        [TestCase("dyo", "ヂョ")]
        [TestCase("dha", "デャ")]
        [TestCase("dhi", "ディ")]
        [TestCase("dhu", "デュ")]
        [TestCase("dhe", "デェ")]
        [TestCase("dho", "デョ")]
        [TestCase("dwa", "ドァ")]
        [TestCase("dwi", "ドィ")]
        [TestCase("dwu", "ドゥ")]
        [TestCase("dwe", "ドェ")]
        [TestCase("dwo", "ドォ")]
        [TestCase("na", "ナ")]
        [TestCase("ni", "ニ")]
        [TestCase("nu", "ヌ")]
        [TestCase("ne", "ネ")]
        [TestCase("no", "ノ")]
        [TestCase("nya", "ニャ")]
        [TestCase("nyi", "ニィ")]
        [TestCase("nyu", "ニュ")]
        [TestCase("nye", "ニェ")]
        [TestCase("nyo", "ニョ")]
        [TestCase("ha", "ハ")]
        [TestCase("hi", "ヒ")]
        [TestCase("hu", "フ")]
        [TestCase("he", "ヘ")]
        [TestCase("ho", "ホ")]
        [TestCase("fu", "フ")]
        [TestCase("hya", "ヒャ")]
        [TestCase("hyi", "ヒィ")]
        [TestCase("hyu", "ヒュ")]
        [TestCase("hye", "ヒェ")]
        [TestCase("hyo", "ヒョ")]
        [TestCase("fya", "フャ")]
        [TestCase("fyu", "フュ")]
        [TestCase("fyo", "フョ")]
        [TestCase("fwa", "ファ")]
        [TestCase("fwi", "フィ")]
        [TestCase("fwu", "フゥ")]
        [TestCase("fwe", "フェ")]
        [TestCase("fwo", "フォ")]
        [TestCase("fa", "ファ")]
        [TestCase("fi", "フィ")]
        [TestCase("fe", "フェ")]
        [TestCase("fo", "フォ")]
        [TestCase("fyi","フィ")]
        [TestCase("fye", "フェ")]
        [TestCase("ba", "バ")]
        [TestCase("bi", "ビ")]
        [TestCase("bu", "ブ")]
        [TestCase("be", "ベ")]
        [TestCase("bo", "ボ")]
        [TestCase("bya", "ビャ")]
        [TestCase("byi", "ビィ")]
        [TestCase("byu", "ビュ")]
        [TestCase("bye", "ビェ")]
        [TestCase("byo", "ビョ")]
        [TestCase("pa", "パ")]
        [TestCase("pi", "ピ")]
        [TestCase("pu", "プ")]
        [TestCase("pe", "ペ")]
        [TestCase("po", "ポ")]
        [TestCase("pya", "ピャ")]
        [TestCase("pyi", "ピィ")]
        [TestCase("pyu", "ピュ")]
        [TestCase("pye", "ピェ")]
        [TestCase("pyo", "ピョ")]
        [TestCase("ma", "マ")]
        [TestCase("mi", "ミ")]
        [TestCase("mu", "ム")]
        [TestCase("me", "メ")]
        [TestCase("mo", "モ")]
        [TestCase("mya", "ミャ")]
        [TestCase("myi", "ミィ")]
        [TestCase("myu", "ミュ")]
        [TestCase("mye", "ミェ")]
        [TestCase("myo", "ミョ")]
        [TestCase("ya", "ヤ")]
        [TestCase("yu", "ユ")]
        [TestCase("yo", "ヨ")]
        [TestCase("xya", "ャ")]
        [TestCase("xyu", "ュ")]
        [TestCase("xyo", "ョ")]
        [TestCase("ra", "ラ")]
        [TestCase("ri", "リ")]
        [TestCase("ru", "ル")]
        [TestCase("re", "レ")]
        [TestCase("ro", "ロ")]
        [TestCase("rya", "リャ")]
        [TestCase("ryi", "リィ")]
        [TestCase("ryu", "リュ")]
        [TestCase("rye", "リェ")]
        [TestCase("ryo", "リョ")]
        [TestCase("wa", "ワ")]
        [TestCase("wo", "ヲ")]
        [TestCase("lwa", "ヮ")]
        [TestCase("xwa", "ヮ")]
        [TestCase("n", "ン")]
        [TestCase("nn", "ンン")]
        [TestCase("xn", "ン")]
        // double consonants
        [TestCase("atta", "アッタ")]
        [TestCase("gakkounakatta", "ガッコウナカッタ")]
        [TestCase("babba", "バッバ")]
        [TestCase("cacca", "カッカ")]
        [TestCase("chaccha", "チャッチャ")]
        [TestCase("dadda", "ダッダ")]
        [TestCase("fuffu", "フッフ")]
        [TestCase("gagga", "ガッガ")]
        [TestCase("hahha", "ハッハ")]
        [TestCase("jajja", "ジャッジャ")]
        [TestCase("kakka", "カッカ")]
        [TestCase("mamma", "マッマ")]
        [TestCase("nanna", "ナンナ")]
        [TestCase("pappa", "パッパ")]
        [TestCase("qaqqa", "クァックァ")]
        [TestCase("rarra", "ラッラ")]
        [TestCase("sassa", "サッサ")]
        [TestCase("shassha", "シャッシャ")]
        [TestCase("tatta", "タッタ")]
        [TestCase("tsuttsu", "ツッツ")]
        [TestCase("vavva", "ヴァッヴァ")]
        [TestCase("wawwa", "ワッワ")]
        [TestCase("yayya", "ヤッヤ")]
        [TestCase("zazza", "ザッザ")]
        //
        [TestCase("NLTU", "ンッ")]

        public void ToKatakana_WhenPassedRomaji_ReturnsItConvertedToKatakana(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("ヶ", "ヶ")]
        [TestCase("ヵ", "ヵ")]
        [TestCase("1", "1")]
        [TestCase("@", "@")]
        [TestCase("#", "#")]
        [TestCase("$", "$")]
        [TestCase("%", "%")]
        public void ToKatakana_WhenPassedCertainSymbols_ReturnsThemUnconverted(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("!", "！")]
        [TestCase("?", "？")]
        [TestCase(".", "。")]
        [TestCase(":", "：")]
        [TestCase("/", "・")]
        [TestCase(",", "、")]
        [TestCase("~", "〜")]
        [TestCase("-", "ー")]
        [TestCase("‘", "「")]
        [TestCase("’", "」")]
        [TestCase("“", "『")]
        [TestCase("”", "』")]
        [TestCase("[", "［")]
        [TestCase("]", "］")]
        [TestCase("(", "（")]
        [TestCase(")", "）")]
        [TestCase("{", "｛")]
        [TestCase("}", "｝")]
        public void ToKatakana_WhenPassedPunctuation_ConvertsItCorrectly(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("toukyou, おおさか", "トウキョウ、 オオサカ")]
        [TestCase("wi", "ウィ")]
        public void ToKatakana_WhenPassedHiraganaAndRomaji_ReturnsThemConvertedToKatakana(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("スタイル", "スタイル")]
        [TestCase("アメリカじん", "アメリカジン")]
        public void ToKatakana_WhenPassedKana_ConvertsItCorrectly(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("ばつゲーム", "バツゲーム")]
        [TestCase("バツゲーム", "バツゲーム")]
        [TestCase("テスーと", "テスート")]
        public void ToKatakana_WhenPassedALongVowelMark_ConvertsItCorrectly(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("only かな", true, "only カナ")]
        [TestCase("only かな", false, "オンly カナ")]
        [TestCase("座禅‘zazen’すたいる", true, "座禅‘zazen’スタイル")]
        [TestCase("座禅‘zazen’すたいる", false, "座禅「ザゼン」スタイル")]
        public void ToKatakana_WhenPassRomajiFlagIsEngabled_OnlyConvertsHiragana(string input, bool passRomaji, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input, new DefaultOptions { PassRomaji = passRomaji });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("aiueo", "AIUEO")]
        public void ToKatakana_WhenPassedLowerAndUpperCaseRomaji_ConvertsItTheSameWay(string lowercase, string uppercase)
        {
            string lowercaseResult = WanaKana.ToKatakana(lowercase);
            string uppercaseResult = WanaKana.ToKatakana(uppercase);

            Assert.AreEqual(lowercaseResult, uppercaseResult);
        }

        [TestCase("wi", true, "ヰ")]
        [TestCase("we", true, "ヱ")]
        [TestCase("wi", false, "ウィ")]
        [TestCase("IROHANIHOHETO", true, "イロハニホヘト")]
        [TestCase("CHIRINURUWO", true, "チリヌルヲ")]
        [TestCase("WAKAYOTARESO", true, "ワカヨタレソ")]
        [TestCase("TSUNENARAMU", true, "ツネナラム")]
        [TestCase("UWINOOKUYAMA", true, "ウヰノオクヤマ")]
        [TestCase("KEFUKOETE", true, "ケフコエテ")]
        [TestCase("ASAKIYUMEMISHI", true, "アサキユメミシ")]
        [TestCase("WEHIMOSESU", true, "ヱヒモセス")]
        public void ToKatakana_WhenObsoleteKanaFlagIsTrue_ConvertsObsoleteKanaCorrectly(string input, bool useObsoleteKana, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input, new DefaultOptions { UseObsoleteKana = useObsoleteKana });

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
