﻿using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class TokenizeUnitTests
    {
        [TestCase("ふふフフ", new string[]{"ふふ", "フフ"})]
        [TestCase("感じ", new string[]{ "感", "じ" })]
        [TestCase("truly 私は悲しい", new string[] { "truly", " ", "私", "は", "悲", "しい" })]
        [TestCase("5romaji here...!?漢字ひらがな４カタ　カナ「ＳＨＩＯ」。！", 
            new string[] { "5", "romaji", " ", "here", "...!?", "漢字", "ひらがな", "４", "カタ", "　",　"カナ", "「", "ＳＨＩＯ", "」。！" })]
        public void Tokenize_WhenPassedAMixedString_ReturnsCorrectTokens(string input, string[] expectedResult)
        {
            var tokenization = WanaKana.Tokenize(input);
            CollectionAssert.AreEquivalent(tokenization.Values, expectedResult);
        }

        [TestCase("truly 私は悲しい", true, new string[] { "truly ", "私は悲しい" })]
        [TestCase("5romaji here...!?漢字ひらがなカタ　カナ４「ＳＨＩＯ」。！", true,
            new string[] { "5", "romaji here", "...!?", "漢字ひらがなカタ　カナ", "４「", "ＳＨＩＯ", "」。！" })]
        public void Tokenize_WhenPassedCompactTrue_ReturnsCorrectTokens(string input, bool compact, string[] expectedResult)
        {
            var tokenization = WanaKana.Tokenize(input, compact);
            CollectionAssert.AreEquivalent(tokenization.Values, expectedResult);
        }

        [Test]
        public void Tokenize_WhenPassedAMixedString_ReturnsDetailedTokens()
        {
            var tokenization = WanaKana.Tokenize(input: "5romaji here...!?漢字ひらがなカタ　カナ４「ＳＨＩＯ」。！ لنذهب");

            var expectedOutput = new Token[]
            {
                 new Token("englishNumeral",  "5" ),
                 new Token("en",  "romaji" ),
                 new Token("space",  " " ),
                 new Token("en",  "here" ),
                 new Token("englishPunctuation",  "...!?" ),
                 new Token("kanji",  "漢字" ),
                 new Token("hiragana",  "ひらがな" ),
                 new Token("katakana",  "カタ" ),
                 new Token("space",  "　" ),
                 new Token("katakana",  "カナ" ),
                 new Token("japaneseNumeral",  "４" ),
                 new Token("japanesePunctuation",  "「" ),
                 new Token("ja",  "ＳＨＩＯ" ),
                 new Token("japanesePunctuation",  "」。！" ),
                 new Token("space",  " " ),
                 new Token("other",  "لنذهب" ),
            };

            CollectionAssert.AreEquivalent(tokenization.Tokens, expectedOutput);
        }

        [Test]
        public void Tokenize_WhenCompactIsTrue_ReturnsDetailedTokens()
        {
            var tokenization = WanaKana.Tokenize(input: "5romaji here...!?漢字ひらがなカタ　カナ４「ＳＨＩＯ」。！ لنذهب", compact: true);

            var expectedOutput = new Token[]
            {
                new("other",  "5" ),
                new("en",  "romaji here" ),
                new("other",  "...!?" ),
                new("ja",  "漢字ひらがなカタ　カナ" ),
                new("other",  "４「" ),
                new("ja",  "ＳＨＩＯ" ),
                new("other",  "」。！" ),
                new("en",  " " ),
                new("other",  "لنذهب" ),
            };

            CollectionAssert.AreEquivalent(tokenization.Tokens, expectedOutput);
        }
    }
}