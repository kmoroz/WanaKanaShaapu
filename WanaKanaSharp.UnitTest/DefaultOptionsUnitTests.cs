using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    public class DefaultOptionsUnitTests
    {
        [Test]
        public void DefaultOptions_WhenPartiallyInstantiated_PropertiesHaveDefaultValues()
        {
            DefaultOptions myOptions = new DefaultOptions();

            Assert.IsFalse(myOptions.UseObsoleteKana);
            Assert.IsFalse(myOptions.PassRomaji);
            Assert.IsTrue(myOptions.ConvertLongVowelMark);
            Assert.IsFalse(myOptions.UpcaseKatakana);
            Assert.IsNull(myOptions.IMEMode);
            Assert.AreEqual(myOptions.Romanization,"hepburn");
            Assert.NotNull(myOptions.CustomKanaMapping);
            Assert.NotNull(myOptions.CustomRomajiMapping);
        }
    }
}
