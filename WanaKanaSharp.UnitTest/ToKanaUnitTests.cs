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
    }
}
