using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class IsRomajiUnitTests
    {
        [TestCase("Tōkyō and Ōsaka")]
        public void IsRomaji_WhenPassedLatinAndMacronCharacters_ReturnsTrue(string input)
        {
            var result = WanaKana.IsRomaji(input);

            Assert.True(result);
        }

        [TestCase("12a*b&c-d")]
        public void IsRomaji_WhenPassedLatinCharactersPunctuationAndNumerals_ReturnsTrue(string input)
        {
            var result = WanaKana.IsRomaji(input);

            Assert.True(result);
        }

        [TestCase("あアA")]
        public void IsRomaji_WhenPassedKanaAndLatinCharacters_ReturnsFalse(string input)
        {
            var result = WanaKana.IsRomaji(input);

            Assert.False(result);
        }

        [TestCase("お願い")]
        public void IsRomaji_WhenPassedNoLatinCharacters_ReturnsFalse(string input)
        {
            var result = WanaKana.IsRomaji(input);

            Assert.False(result);
        }

        [TestCase("a！b&cーd")]
        public void IsRomaji_WhenPassedLatinAndJapaneseCharacters_ReturnsFalse(string input)
        {
            var result = WanaKana.IsRomaji(input);

            Assert.False(result);
        }

        [TestCase("a！b&cーd", "[！ー]")]
        public void IsRomaji_WhenPassedLatinAndJapaneseCharactersAndRegexToIgnoreThem_ReturnsTrue(string input, string allowed)
        {
            var result = WanaKana.IsRomaji(input, allowed);

            Assert.True(result);
        }
    }
}
