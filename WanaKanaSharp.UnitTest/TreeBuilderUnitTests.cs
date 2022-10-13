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
        public void BuildTreeTest()
        {
            var tree = TreeBuilder.BuildTree();

            var tsuTree = tree["っ"];
            var mmi = tsuTree.Children["み"].Data;
            var mi = tree["み"].Data;
            Assert.AreEqual(mmi, "mmi");
            Assert.AreEqual(mi, "mi");
        }
    }
}
