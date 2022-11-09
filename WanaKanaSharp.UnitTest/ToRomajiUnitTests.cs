using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToRomajiUnitTests
    {
        [TestCase("ひらがな　カタカナ", "hiragana katakana")]
        [TestCase("げーむ　ゲーム", "ge-mu geemu")]
        [TestCase("がっこうなかった", "gakkounakatta")]
        [TestCase("!!がっこうなかった!!", "!!gakkounakatta!!")]
        [TestCase("ったったった", "ttattatta")]
        [TestCase("っこ った っこ", "kko tta kko")]
        [TestCase("!!  っこ った っこ  !!", "!!  kko tta kko  !!")]
        public void ToRomaji_WhenPassedKana_ReturnsItConvertedToLatinCharacters(string input, string expectedOutput)
        {
            string result = WanaKana.ToRomaji(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("ひらがな", true, "hiragana")]
        [TestCase(" !!ひら!!がな!!  ", true, " !!hira!!gana!!  ")]
        [TestCase("ひらがな ひらがな", true, "hiragana hiragana")]
        [TestCase("   ...   ひらがな@@@@@@@@@", true, "   ...   hiragana@@@@@@@@@")]
        [TestCase("カタカナ", true, "KATAKANA")]
        [TestCase("ひらがな カタカナ", true, "hiragana KATAKANA")]
        public void ToRomaji_WhenPassedUpcaseKatakanaTrue_ReturnsUppercaseLatinCharacters(string input, bool upcaseKatakana, string expectedOutput)
        {
            string result = WanaKana.ToRomaji(input, new DefaultOptions { UpcaseKatakana = upcaseKatakana });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("つじぎり", "tuzigili")]
        public void ToRomaji_WhenPassedACustomMap_ReturnsACorrectString(string input, string expectedOutput)
        {
            var map = new DefaultOptions { CustomRomajiMapping = new Dictionary<string, string> { { "じ", "zi" }, { "つ", "tu" }, { "り", "li" } } };
            string result = WanaKana.ToRomaji(input, map);

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
