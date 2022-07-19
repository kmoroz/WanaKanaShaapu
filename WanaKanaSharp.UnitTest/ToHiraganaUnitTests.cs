﻿using NUnit.Framework;
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
        [TestCase("wi", "うぃ")]
        public void ToHiragana_WhenPassedKatakanaAndRomaji_ReturnsThemConvertedToHiragana(string input, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("only カナ", true, "only かな")]
        public void ToHiragana_WhenPassRomajiFlagIsEngabled_OnlyConvertsKatakana(string input, bool passRomaji, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input, new DefaultOptions { PassRomaji = passRomaji });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("wi", true, "ゐ")]
        public void ToHiragana_WhenPassUseObsoleteKanaFlag_ReturnsObsoleteKana(string input, bool useObsoleteKana, string expectedOutput)
        {
            string result = WanaKana.ToHiragana(input, new DefaultOptions { UseObsoleteKana = useObsoleteKana });

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
