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
        [TestCase("げーむ　ゲーム", "geemu ge-mu")]
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

        [TestCase("つじぎり", "tuzigili")]
        public void ToRomaji_WhenPassedACustomMap_ReturnsACorrectString(string input, string expectedOutput)
        {
            var map = new Dictionary<string, string> { { "じ", "zi" }, { "つ", "tu" }, { "り", "li" } };
            string result = WanaKana.ToRomaji(input, map: map);

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
