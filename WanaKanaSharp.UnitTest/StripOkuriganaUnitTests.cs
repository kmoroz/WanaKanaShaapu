using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class StripOkuriganaUnitTests 
    {
        [TestCase("踏み込む", "踏み込")]
        [TestCase("お祝い", "お祝")]
        public void StripOkurigana_WhenPassedAStringEndingWithOkurigana_ReturnsAStringWithoutIt(string input, string expectedOutput)
        {
            string result = WanaKana.StripOkurigana(input);
                
            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("お腹", true, "腹")]
        public void StripOkurigana_WhenPassedLeadingAsTrue_ReturnsAStringWithoutLeadingOkurigana(string input, bool leading, string expectedOutput)
        {
            string result = WanaKana.StripOkurigana(input, leading: leading);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("ふみこむ", "踏み込む", "ふみこ")]
        public void StripOkurigana_WhenPassedHiraganaAndMatchedKanji_ReturnsHiraganaWithoutOkuriganaMatched(string input, string matchKanji, string expectedOutput)
        {
            string result = WanaKana.StripOkurigana(input, matchKanji: matchKanji);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("おみまい", "お見舞い", true,  "みま")]
        public void StripOkurigana_WhenPassedHiraganaMatchedKanjiAndLeadingTrue_ReturnsHiraganaWithoutOkuriganaMatched(string input, string matchKanji, bool leading, string expectedOutput)
        {
            string result = WanaKana.StripOkurigana(input, matchKanji: matchKanji, leading: leading);

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
