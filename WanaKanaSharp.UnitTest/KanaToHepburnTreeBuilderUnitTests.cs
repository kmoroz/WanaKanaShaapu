using NUnit.Framework;

namespace WanaKanaSharp.UnitTests
{
    [TestFixture]
    internal class KanaToHepburnTreeBuilderUnitTests
    {
        private Dictionary<string, Node> _hiraganaTree;

        [OneTimeSetUp]
        public void SetupTestFixture()
        {
            _hiraganaTree = TreeBuilder.BuildKanaToHepburnTree();
        }

        [TestCaseSource("KanaToHepburnTestCases")]
        public void KanaToHepburnTree_WhenBuilt_HasCorrectValues(KanaToHepburnTestCase testCase)
            => testCase.Test(_hiraganaTree);

        static KanaToHepburnTestCase[] KanaToHepburnTestCases =
        {
            new KanaToHepburnTestCase{ Input = "み", ExpectedOutput = "mi"},
            new KanaToHepburnTestCase{ Input = "。", ExpectedOutput = "."},
            new KanaToHepburnTestCase{ Input = "ょ", ExpectedOutput = "yo"},
            new KanaToHepburnTestCase{ Input = "ふょ", ExpectedOutput = "fyo"},
            new KanaToHepburnTestCase{ Input = "みょ", ExpectedOutput = "myo"},
            new KanaToHepburnTestCase{ Input = "にゅ", ExpectedOutput = "nyu"},
            new KanaToHepburnTestCase{ Input = "ひぇ", ExpectedOutput = "hye"},
            new KanaToHepburnTestCase{ Input = "くぃ", ExpectedOutput = "kyi"},
            new KanaToHepburnTestCase{ Input = "じゃ", ExpectedOutput = "ja"},
            new KanaToHepburnTestCase{ Input = "ぢゃ", ExpectedOutput = "ja"},
            new KanaToHepburnTestCase{ Input = "じぃ", ExpectedOutput = "jyi"},
            new KanaToHepburnTestCase{ Input = "じぇ", ExpectedOutput = "je"},
            new KanaToHepburnTestCase{ Input = "っみ", ExpectedOutput = "mmi"},
            new KanaToHepburnTestCase{ Input = "んあ", ExpectedOutput = "n'a"},
            new KanaToHepburnTestCase{ Input = "んん", ExpectedOutput = "nn"},
        };

        internal class KanaToHepburnTestCase
        {
            public string Input { get; set; }
            public string ExpectedOutput { get; set; }

            public void Test(Dictionary<string, Node> tree)
            {
                var output = TreeTraverser.TraverseTree(Input, tree);

                Assert.AreEqual(output, ExpectedOutput, $"Expected '{Input}' => {ExpectedOutput} but was '{Input}' => {output}");
            }
        }

    }
}