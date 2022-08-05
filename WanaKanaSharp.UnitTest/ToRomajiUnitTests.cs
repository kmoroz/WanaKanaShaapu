using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToRomajiUnitTests
    {
        [TestCase("ひらがな　カタカナ", "hiragana katakana")]
        //[TestCase("げーむ　ゲーム", "geemu ge-mu")]
        public void ToRomaji_WhenPassedKana_ReturnsItConvertedToLatinCharacters(string input, string expectedOutput)
        {
            string result = WanaKana.ToRomaji(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("ひらがな カタカナ", true, "hiragana KATAKANA")]
        public void ToRomaji_WhenPassedUpcaseKatakanaTrue_ReturnsUppercaseLatinCharacters(string input, bool upcaseKatakana, string expectedOutput)
        {
            string result = WanaKana.ToRomaji(input, new DefaultOptions { UpcaseKatakana = upcaseKatakana });

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
