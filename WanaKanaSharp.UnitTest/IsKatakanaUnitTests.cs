using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class IsKatakanaUnitTests
    {
        [TestCase("A")]
        public void IsKatakana_WhenPassedLatinCharacters_ReturnsFalse(string input)
        {
            var result = WanaKana.IsKatakana(input);

            Assert.False(result);
        }

        [TestCase("あ")]
        [TestCase("あア")]
        public void IsKatakana_WhenPassedHiragana_ReturnsFalse(string input)
        {
            var result = WanaKana.IsKatakana(input);

            Assert.False(result);
        }

        [TestCase("ゲーム")]
        public void IsKatakana_WhenPassedKatakana_ReturnsTrue(string input)
        {
            var result = WanaKana.IsKatakana(input);

            Assert.True(result);
        }
    }
}
