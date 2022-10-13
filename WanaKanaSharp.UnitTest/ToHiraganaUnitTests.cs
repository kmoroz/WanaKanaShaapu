using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToHiraganaUnitTests
    {
        [TestCase("toukyou, オオサカ", "とうきょう、　おおさか")]
        [TestCase("wi", "うぃ")]
        [TestCase("ラーメン", "らあめん")]
        [TestCase("atta", "あった")]
        [TestCase("a", "あ")]
        [TestCase("i", "い")]
        [TestCase("u", "う")]
        [TestCase("e", "え")]
        [TestCase("o", "お")]
        [TestCase("la", "ぁ")]
        [TestCase("xa", "ぁ")]
        [TestCase("li", "ぃ")]
        [TestCase("xi", "ぃ")]
        [TestCase("lu", "ぅ")]
        [TestCase("xu", "ぅ")]
        [TestCase("le", "ぇ")]
        [TestCase("xe", "ぇ")]
        [TestCase("lo", "ぉ")]
        [TestCase("xo", "ぉ")]
        [TestCase("yi", "い")]
        [TestCase("wu", "う")]
        [TestCase("whu", "う")]
        [TestCase("xa", "ぁ")]
        [TestCase("xi", "ぃ")]
        [TestCase("xu", "ぅ")]
        [TestCase("xe", "ぇ")]
        [TestCase("xo", "ぉ")]
        [TestCase("xyi", "ぃ")]
        [TestCase("xye", "ぇ")]
        [TestCase("ye", "いぇ")] 
        [TestCase("wha", "うぁ")]
        [TestCase("whi", "うぃ")]
        [TestCase("whe", "うぇ")]
        [TestCase("who", "うぉ")]
        [TestCase("wi", "うぃ")]
        [TestCase("we", "うぇ")]
        [TestCase("va", "ゔぁ")]
        [TestCase("vi", "ゔぃ")]
        [TestCase("vu", "ゔ")]
        [TestCase("ve", "ゔぇ")]
        [TestCase("vo", "ゔぉ")]
        [TestCase("vyi", "ゔぃ")]
        [TestCase("vye", "ゔぇ")]
        [TestCase("vya", "ゔゃ")]
        [TestCase("vyu", "ゔゅ")]
        [TestCase("vyo", "ゔょ")]
        [TestCase("ka", "か")]
        [TestCase("ki", "き")]
        [TestCase("ku", "く")]
        [TestCase("ke", "け")]
        [TestCase("ko", "こ")]
        [TestCase("lka", "ヵ")]
        [TestCase("lke", "ヶ")]
        [TestCase("xka", "ヵ")]
        [TestCase("xke", "ヶ")]
        [TestCase("kya", "きゃ")]
        [TestCase("kyi", "きぃ")]
        [TestCase("kyu", "きゅ")]
        [TestCase("kye", "きぇ")]
        [TestCase("kyo", "きょ")]
        [TestCase("ca", "か")] 
        [TestCase("ci", "き")] 
        [TestCase("cu", "く")] 
        [TestCase("ce", "け")] 
        [TestCase("co", "こ")] 
        [TestCase("lca", "ヵ")]
        [TestCase("lce", "ヶ")]
        [TestCase("xca", "ヵ")]
        [TestCase("xce", "ヶ")]
        [TestCase("qya", "くゃ")]
        [TestCase("qyu", "くゅ")]
        [TestCase("qyo", "くょ")]
        [TestCase("qwa", "くぁ")]
        [TestCase("qwi", "くぃ")]
        [TestCase("qwu", "くぅ")]
        [TestCase("qwe", "くぇ")]
        [TestCase("qwo", "くぉ")]
        [TestCase("qa", "くぁ")]
        [TestCase("qi", "くぃ")]
        [TestCase("qe", "くぇ")]
        [TestCase("qo", "くぉ")]
        [TestCase("kwa", "くぁ")] 
        [TestCase("kwi", "くぃ")] 
        [TestCase("kwe", "くぇ")] 
        [TestCase("kwo", "くぉ")] 
        [TestCase("qyi", "くぃ")] 
        [TestCase("qye", "くぇ")] 
        [TestCase("ga", "が")]
        [TestCase("gi", "ぎ")]
        [TestCase("gu", "ぐ")]
        [TestCase("ge", "げ")]
        [TestCase("go", "ご")]
        [TestCase("gya", "ぎゃ")]
        [TestCase("gyi", "ぎぃ")]
        [TestCase("gyu", "ぎゅ")]
        [TestCase("gye", "ぎぇ")]
        [TestCase("gyo", "ぎょ")]
        [TestCase("gwa", "ぐぁ")]
        [TestCase("gwi", "ぐぃ")]
        [TestCase("gwu", "ぐぅ")]
        [TestCase("gwe", "ぐぇ")]
        [TestCase("gwo", "ぐぉ")]
        [TestCase("sa", "さ")]
        [TestCase("si", "し")]
        [TestCase("su", "す")]
        [TestCase("se", "せ")]
        [TestCase("so", "そ")]
        [TestCase("shi", "し")]
        [TestCase("za", "ざ")]
        [TestCase("zi", "じ")]
        [TestCase("zu", "ず")]
        [TestCase("ze", "ぜ")]
        [TestCase("zo", "ぞ")]
        [TestCase("ji", "じ")]
        [TestCase("sya", "しゃ")]
        [TestCase("syi", "しぃ")]
        [TestCase("syu", "しゅ")]
        [TestCase("sye", "しぇ")]
        [TestCase("syo", "しょ")]
        [TestCase("sha", "しゃ")]
        [TestCase("shu", "しゅ")]
        [TestCase("she", "しぇ")]
        [TestCase("sho", "しょ")]
        [TestCase("shya", "しゃ")]
        [TestCase("shyu", "しゅ")]
        [TestCase("shye", "しぇ")]
        [TestCase("shyo", "しょ")]
        [TestCase("swa", "すぁ")]
        [TestCase("swi", "すぃ")]
        [TestCase("swu", "すぅ")]
        [TestCase("swe", "すぇ")]
        [TestCase("swo", "すぉ")]
        [TestCase("zya", "じゃ")]
        [TestCase("zyi", "じぃ")]
        [TestCase("zyu", "じゅ")]
        [TestCase("zye", "じぇ")]
        [TestCase("zyo", "じょ")]
        [TestCase("ja", "じゃ")]
        [TestCase("ju", "じゅ")]
        [TestCase("je", "じぇ")]
        [TestCase("jo", "じょ")]
        [TestCase("jya", "じゃ")]
        [TestCase("jyi", "じぃ")]
        [TestCase("jyu", "じゅ")]
        [TestCase("jye", "じぇ")]
        [TestCase("jyo", "じょ")]
        public void ToHiragana_WhenPassedKatakanaAndRomaji_ReturnsThemConvertedToHiragana(string input, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("only カナ", true, "only かな")]
        public void ToHiragana_WhenPassedRomajiFlagIsEngabled_OnlyConvertsKatakana(string input, bool passRomaji, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input, new DefaultOptions { PassRomaji = passRomaji });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("wi", true, "ゐ")]
        public void ToHiragana_WhenPassedUseObsoleteKanaFlag_ReturnsObsoleteKana(string input, bool useObsoleteKana, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input, new DefaultOptions { UseObsoleteKana = useObsoleteKana });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("only convert the katakana: ヒラガナ", true, "only convert the katakana: ひらがな")]
        public void ToHiragana_WhenPassedPassRomajiSetToTrue_ReturnsRomajiUnconverted(string input, bool passRomaji, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input, new DefaultOptions { PassRomaji = passRomaji });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("ラーメン", false, "らーめん")]
        public void ToHiragana_WhenPassedConvertLongVowelMarkSetToFalse_ReturnsCorrectOutput(string input, bool convertLongVowelMark, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input, new DefaultOptions {  ConvertLongVowelMark = convertLongVowelMark });

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
