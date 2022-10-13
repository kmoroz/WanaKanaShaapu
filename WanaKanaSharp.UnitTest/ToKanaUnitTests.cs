using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToKanaUnitTests
    {
        [TestCase("座禅‘zazen’スタイル", "座禅「ざぜん」スタイル")]
        [TestCase("batsuge-mu", "ばつげーむ")]
        [TestCase("!?.:/,~-‘’“”[](){}", "！？。：／、〜ー「」『』［］（）｛｝")]
        [TestCase("!?.:/,~-‘’“”[](){}", "！？。：／、〜ー「」『』［］（）｛｝")]
        public void ToKana_WhenPassedInput_ConvertsItCorrectly(string input, string expectedOutput)
        {
            string result = WanaKana.ToKana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("ヶ", "ヶ")]
        [TestCase("ヵ", "ヵ")]
        [TestCase("1", "1")]
        [TestCase("@", "@")]
        [TestCase("#", "#")]
        [TestCase("$", "$")]
        [TestCase("%", "%")]
        public void ToKana_WhenPassedTheSymbolsThatAreNotToBeConverted_ReturnsThemAsTheyAre(string input, string expectedOutput)
        {
            string result = WanaKana.ToKana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("onaji BUTTSUUJI", "おなじ ブッツウジ")]
        [TestCase("ONAJI buttsuuji", "オナジ ぶっつうじ")]
        public void ToKana_WhenPassedLowerAndUpperCaseLatinChacters_ReturnsThemConvertedToHiraganaAndKatakanaRespectively(string input, string expectedOutput)
        {
            string result = WanaKana.ToKana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("we", true, "ゑ")]
        public void ToKana_WhenPassedObsoleteKanaFlagTrue_ReturnsObsoleteKanaString(string input, bool useObsoleteKana, string expectedOutput)
        {
            string result = WanaKana.ToKana(input, new DefaultOptions { UseObsoleteKana = useObsoleteKana });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("wanakana", "わにBanaに")]
        public void ToKana_WhenPassedCustomMapping_ReturnsACorrectString(string input, string expectedOutput)
        {
            string result = WanaKana.ToKana(input, new DefaultOptions { CustomKanaMapping = new Dictionary<string, string> { { "na", "に" }, { "ka", "Bana" } } });

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
