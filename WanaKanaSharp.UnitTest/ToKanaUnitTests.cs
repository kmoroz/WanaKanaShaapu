using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToKanaUnitTests
    {
        [TestCase("onaji BUTTSUUJI", "おなじ ブッツウジ")]
        [TestCase("ONAJI buttsuuji", "オナジ ぶっつうじ")]
        [TestCase("座禅‘zazen’スタイル", "座禅「ざぜん」スタイル")]
        [TestCase("batsuge-mu", "ばつげーむ")]
        [TestCase("!?.:/,~-‘’“”[](){}", "！？。：／、〜ー「」『』［］（）｛｝")]

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
