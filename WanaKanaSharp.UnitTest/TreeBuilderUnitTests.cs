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
            var wha = tree["w"].Children["h"].Children["a"].Data;
            var qa = tree["q"].Children["a"].Data;
            var xn = tree["x"].Children["n"].Data;

            //aliases
            var ja = tree["j"].Children["a"].Data;
            var zya = tree["z"].Children["y"].Children["a"].Data;
            var sha = tree["s"].Children["h"].Children["a"].Data;
            var sya = tree["s"].Children["y"].Children["a"].Data;
            var shi = tree["s"].Children["h"].Children["i"].Data;
            var si = tree["s"].Children["i"].Data;
            var fu = tree["f"].Children["u"].Data;
            var hu = tree["h"].Children["u"].Data;

            //x&l subtrees
            var xo = tree["x"].Children["o"].Data;
            var xwa = tree["x"].Children["w"].Children["a"].Data;
            var ltu = tree["l"].Children["t"].Children["u"].Data;

            Assert.AreEqual(a, "あ");
            Assert.AreEqual(ka, "か");
            Assert.AreEqual(wha, "うぁ");
            Assert.AreEqual(qa, "くぁ");
            Assert.AreEqual(xn, "ん");
            Assert.AreEqual(ja, zya);
            Assert.AreEqual(sha, sya);
            Assert.AreEqual(shi, si);
            Assert.AreEqual(fu, hu);
            Assert.AreEqual(xo, "ぉ");
            Assert.AreEqual(xwa, "ゎ");
            Assert.AreEqual(ltu, "っ");
        }
    }
}
