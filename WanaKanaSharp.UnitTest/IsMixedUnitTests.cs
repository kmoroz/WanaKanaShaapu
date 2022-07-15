using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class IsMixedUnitTests
    {
        [TestCase("Abあア")]
        public void IsMixed_WhenPassedRomajiAndKana_ReturnsTrue(string input)
        {
            var result = WanaKana.IsMixed(input);

            Assert.True(result);
        }

        [TestCase("お腹A")]
        public void IsMixed_WhenPassedRomajiKanaAndKanji_ReturnsTrue(string input)
        {
            var result = WanaKana.IsMixed(input);

            Assert.True(result);
        }

        [TestCase("お腹A", false)]
        public void IsMixed_WhenPassKanjiSetToFalse_ReturnsFalse(string input, bool passKanji)
        {
            var result = WanaKana.IsMixed(input, new DefaultOptions { PassKanji = passKanji });

            Assert.IsFalse(result);
        }

        [TestCase("ab")]
        public void IsMixed_WhenPassedRomaji_ReturnsFalse(string input)
        {
            var result = WanaKana.IsMixed(input);

            Assert.IsFalse(result);
        }

        [TestCase("あア")]
        public void IsMixed_WhenPassedKana_ReturnsFalse(string input)
        {
            var result = WanaKana.IsMixed(input);

            Assert.IsFalse(result);
        }
    }
}
