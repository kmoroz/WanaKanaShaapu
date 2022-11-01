using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    internal class RomajiToKanaTreeBuilderUnitTests
    {
        private Dictionary<string, Node> _romajiTree;

        [OneTimeSetUp]
        public void SetupTestFixture()
        {
            _romajiTree = TreeBuilder.BuildRomajiToKanaTree();
        }

        [TestCaseSource("RomajiToKanaTestCases")]
        public void BuildRomajiToKana_WhenBuilt_HasCorrectValues(RomajiToKanaTestCase testCase)
            => testCase.Test(_romajiTree);

        static RomajiToKanaTestCase[] RomajiToKanaTestCases =
        {
            new RomajiToKanaTestCase{ Input = "a", ExpectedOutput = "あ"},
            new RomajiToKanaTestCase{ Input = "ka", ExpectedOutput = "か"},
            new RomajiToKanaTestCase{ Input = "kya", ExpectedOutput = "きゃ"},
            //new RomajiToKanaTestCase{ Input = "wha", ExpectedOutput = "うぁ"},
            //new RomajiToKanaTestCase{ Input = "qa", ExpectedOutput = "くぁ"},
            //new RomajiToKanaTestCase{ Input = "xn", ExpectedOutput = "ん"},
            //new RomajiToKanaTestCase{ Input = "ja", ExpectedOutput = "じゃ"},
            //new RomajiToKanaTestCase{ Input = "zya", ExpectedOutput = "じゃ"},
            //new RomajiToKanaTestCase{ Input = "sha", ExpectedOutput = "ャ"},
            //new RomajiToKanaTestCase{ Input = "sya", ExpectedOutput = "か"},
            //new RomajiToKanaTestCase{ Input = "syi", ExpectedOutput = "か"},
            //new RomajiToKanaTestCase{ Input = "shi", ExpectedOutput = "し"},
            //new RomajiToKanaTestCase{ Input = "si", ExpectedOutput = "し"},
            //new RomajiToKanaTestCase{ Input = "fu", ExpectedOutput = "ふ"},
            //new RomajiToKanaTestCase{ Input = "hu", ExpectedOutput = "ふ"},
            //new RomajiToKanaTestCase{ Input = "xo", ExpectedOutput = "ぉ"},
            //new RomajiToKanaTestCase{ Input = "xwa", ExpectedOutput = "ゎ"},
            //new RomajiToKanaTestCase{ Input = "ltu", ExpectedOutput = "っ"},
            //new RomajiToKanaTestCase{ Input = "yi", ExpectedOutput = "い"},
            //new RomajiToKanaTestCase{ Input = "dha", ExpectedOutput = "でゃ"},
            //new RomajiToKanaTestCase{ Input = "kka", ExpectedOutput = "っか"},
            //new RomajiToKanaTestCase{ Input = "sse", ExpectedOutput = "っせ"},
            //new RomajiToKanaTestCase{ Input = "kkya", ExpectedOutput = "っきゃ"},
        };

        internal class RomajiToKanaTestCase
        {
            public string Input { get; set; }
            public string ExpectedOutput { get; set; }

            public void Test(Dictionary<string, Node> tree)
            {
                var output = TreeTraverser.TraverseTree(Input, tree);

                Assert.AreEqual(output, ExpectedOutput, $"Expected '{Input}' => {ExpectedOutput} but was '{Input}' => {output}");
            }
        }

       /* #region old tests

        [Test]
        public void BuildRomajiToKanaTree_WhenBuilt_HasCorrectValues2()
        {
            var tree = TreeBuilder.BuildRomajiToKanaTree();

            var a = tree["a"].Data;
            var ka = tree["k"].Children["a"].Data;
            var kya = tree["k"].Children["y"].Children["a"].Data;
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

            //special cases
            var yi = tree["y"].Children["i"].Data;
            var dha = tree["d"].Children["h"].Children["a"].Data;

            //tsu
            var kka = tree["k"].Children["k"].Children["a"].Data;
            var sse = tree["s"].Children["s"].Children["e"].Data;
            var kkya = tree["k"].Children["k"].Children["y"].Children["a"].Data;

            Assert.AreEqual(a, "あ");
            Assert.AreEqual(ka, "か");
            Assert.AreEqual(kya, "きゃ");
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
            Assert.AreEqual(yi, "い");
            Assert.AreEqual(dha, "でゃ");
            Assert.AreEqual(kka, "っか");
            Assert.AreEqual(sse, "っせ");
            Assert.AreEqual(kkya, "っきゃ");
        }

#endregion*/
    }
}
