using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToHiraganaUnitTests
    {
        [TestCase("toukyou, オオサカ", "とうきょう、　おおさか")]
        [TestCase("wi", "うぃ")]
        [TestCase("ラーメン", "らあめん")]
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
