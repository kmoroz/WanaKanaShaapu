using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class IsKanjiUnitTests
    {
        [TestCase("勢い")]
        public void IsKanji_WhenPassedHiragana_ReturnsFalse(string input)
        {
            var result = WanaKana.IsKanji(input);

            Assert.False(result);
        }

        [TestCase("あAア")]
        public void IsKanji_WhenPassedLatinCharactersAndKana_ReturnsFalse(string input)
        {
            var result = WanaKana.IsKanji(input);

            Assert.False(result);
        }

        [TestCase("🐸")]
        public void IsKanji_WhenPassedEmoji_ReturnsFalse(string input)
        {
            var result = WanaKana.IsKanji(input);

            Assert.False(result);
        }

        [TestCase("刀")]
        [TestCase("切腹")]
        public void IsKanji_WhenPassedKanji_ReturnsTrue(string input)
        {
            var result = WanaKana.IsKanji(input);

            Assert.True(result);
        }
    }
}
