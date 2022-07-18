using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToHiraganaUnitTests
    {
        [TestCase("toukyou, オオサカ", "とうきょう、　おおさか")]
        public void ToHiragana_WhenPassedKatakanaAndRomaji_ReturnsThemConvertedToHiragana(string input, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input);

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
