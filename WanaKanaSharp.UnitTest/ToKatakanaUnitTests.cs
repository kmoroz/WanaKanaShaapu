using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class ToKatakanaUnitTests
    {
        [TestCase("toukyou, おおさか", "トウキョウ、　オオサカ")]
        [TestCase("wi", "ウィ")]
        public void ToKatakana_WhenPassedHiraganaAndRomaji_ReturnsThemConvertedToKatakana(string input, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input);

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("only かな", true, "only カナ")]
        public void ToKatakana_WhenPassRomajiFlagIsEngabled_OnlyConvertsHiragana(string input, bool passRomaji, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input, new DefaultOptions { PassRomaji = passRomaji });

            Assert.AreEqual(result, expectedOutput);
        }

        [TestCase("wi", true, "ヰ")]
        public void ToKatakana_WhenPassUseObsoleteKanaFlag_ReturnsObsoleteKana(string input, bool useObsoleteKana, string expectedOutput)
        {
            string result = WanaKana.ToKatakana(input, new DefaultOptions { UseObsoleteKana = useObsoleteKana });

            Assert.AreEqual(result, expectedOutput);
        }
    }
}
