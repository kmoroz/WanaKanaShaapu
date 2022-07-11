using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class IsJapaneseUnitTests
    {
        [TestCase("泣き虫.!~$")]
        public void IsJapanese_WhenPassedLatinPunctuation_ReturnsFalse(string input)
        {
            var result = WanaKana.IsJapanese(input);

            Assert.False(result);
        }

        [TestCase("A泣き虫")]
        public void IsJapanese_WhenPassedLatinCharacters_ReturnsFalse(string input)
        {
            var result = WanaKana.IsJapanese(input);

            Assert.False(result);
        }

        [TestCase("泣き虫")]
        public void IsJapanese_WhenPassedKanjiAndKana_ReturnsTrue(string input)
        {
            var result = WanaKana.IsJapanese(input);

            Assert.True(result);
        }

        [TestCase("あア")]
        public void IsJapanese_WhenPassedKana_ReturnsTrue(string input)
        {
            var result = WanaKana.IsJapanese(input);

            Assert.True(result);
        }

        [TestCase("２月")]
        public void IsJapanese_WhenPassedZenkakuNumbers_ReturnsTrue(string input)
        {
            var result = WanaKana.IsJapanese(input);

            Assert.True(result);
        }

        [TestCase("泣き虫。！〜＄")]
        public void IsJapanese_WhenPassedJapanesePunctuation_ReturnsTrue(string input)
        {
            var result = WanaKana.IsJapanese(input);

            Assert.True(result);
        }

        [TestCase("≪偽括弧≫", "[≪≫]")]
        public void IsJapanese_WhenPassedWrongSymbolsAndRegexToIgnoreThem_ReturnsTrue(string input, string allowed)
        {
            var result = WanaKana.IsJapanese(input, allowed);

            Assert.True(result);
        }
    }
}
