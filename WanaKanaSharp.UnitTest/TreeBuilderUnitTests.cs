using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    internal class TreeBuilderUnitTests
    {
        [Test]
        public void BuildKanaToHepburnTree_WhenBuilt_HasCorrectValues()
        {
            var tree = TreeBuilder.BuildKanaToHepburnTree();

            var tsuTree = tree["っ"];
            var mmi = tsuTree.Children["み"].Data;
            var mi = tree["み"].Data;
            Assert.AreEqual(mmi, "mmi");
            Assert.AreEqual(mi, "mi");
        }

        [Test]
        public void BuildRomajiToKanaTree_WhenBuilt_HasCorrectValues()
        {
            var tree = TreeBuilder.BuildRomajiToKanaTree();

            var a = tree["a"].Data;
            var ka = tree["k"].Children["a"].Data;
            Assert.AreEqual(a, "あ");
            Assert.AreEqual(ka, "か");
        }
    }
}
