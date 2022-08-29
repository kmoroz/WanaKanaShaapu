using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class IsHiraganaUnitTests
    {
        [TestCase("A")]
        public void IsHiragana_WhenPassedLatinCharacters_ReturnsFalse(string input)
        {
            var result = WanaKana.IsHiragana(input);

            Assert.False(result);
        }

        [TestCase("あア")]
        public void IsHiragana_WhenPassedKatakana_ReturnsFalse(string input)
        {
            var result = WanaKana.IsHiragana(input);

            Assert.False(result);
        }

        [TestCase("げーむ")]
        [TestCase("すげー")]
        public void IsHiragana_WhenPassedHiragana_ReturnsTrue(string input)
        {
            var result = WanaKana.IsHiragana(input);

            Assert.True(result);
        }
    }
}
