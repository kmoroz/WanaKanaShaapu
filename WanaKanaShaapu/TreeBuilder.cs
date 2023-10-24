
using System.Text.Json;

namespace WanaKanaShaapu
{
    public class TreeBuilder
    {
        private static void BuildSubtree(Node node, (string Romaji, string Kana)[] constant)
        {
            foreach(var entry in constant)
                AddNode(node, entry.Romaji, entry.Kana);
        }

        private static void AddToTree(Dictionary<string, Node> tree, (string Romaji, string Kana)[] constant)
        {
            foreach (var entry in constant)
            {
                string firstChar = entry.Romaji.First().ToString();
                if (!tree.ContainsKey(firstChar))
                    tree.Add(firstChar, new Node(string.Empty));

                AddNode(tree[firstChar], entry.Romaji[1..], entry.Kana);
            }
        }

        private static void AddNode(Node node, string romaji, string kana)
        {
            if (romaji.Length == 0)
                return;
            else if (romaji.Length == 1 && !node.Children.ContainsKey(romaji))
                node.Children.Add(romaji, new Node(kana));
            else if (romaji.Length == 1 && node.Children.ContainsKey(romaji))
                node.Children[romaji].Data = kana;
            else
            {
                var firstChar = romaji.First().ToString();
                if (!node.Children.ContainsKey(firstChar))
                    node.Children.Add(firstChar.First().ToString(), new Node(string.Empty));
                node = node.Children[firstChar.ToString()];
                AddNode(node, romaji[1..], kana);
            }
        }

        public static Dictionary<string, Node> BuildRomajiToKanaTree()
        {
            var tree = new Dictionary<string, Node>();

            //basic
            foreach(var pair in Constants.BasicKunrei)
            {
                string mainKey = pair.Key;
                if (pair.Value.Length == 1)
                    tree.Add(mainKey,　new Node(pair.Value.First().Kana));
                else
                {
                    tree.Add(mainKey, new Node(string.Empty));
                    foreach (var subpair in pair.Value)
                    {
                        tree[mainKey].Children.Add(subpair.Romaji, new Node(subpair.Kana));
                    }
                }
            }

            //special symbols
            foreach (var symbol in Constants.SpecialSymbolsRomajiJp)
                tree.Add(symbol.Symbol, new Node(symbol.JSymbol));

            //add tya, sya, etc.
            AddToTree(tree, Constants.Consonants);
            foreach(var consonant in Constants.Consonants)
            {
                foreach (var smallY in Constants.SmallYRomajiJp)
                    AddNode(tree[consonant.Romaji], smallY.Romaji, consonant.Kana + smallY.Kana);
            }

            //things like うぃ, くぃ, etc.
            AddToTree(tree, Constants.AIUEOConstructions);
            foreach (var construction in Constants.AIUEOConstructions)
            {
                foreach (var vowel in Constants.SmallVowels)
                {
                    if (construction.Romaji.Length == 1)
                        AddNode(tree[construction.Romaji], vowel.Romaji, construction.Kana + vowel.Kana);
                    else
                        AddNode(tree[construction.Romaji.First().ToString()].Children[construction.Romaji.Last().ToString()], vowel.Romaji, construction.Kana + vowel.Kana);
                }
            }

            // different ways to write ん
            string[] nExpressions = { "n", "n'", "xn" };
            foreach(var expression in nExpressions)
            {
                if (expression.Length == 1)
                    tree["n"].Data = "ん";
                else
                {
                    if (!tree.ContainsKey(expression.First().ToString()))
                        tree.Add(expression.First().ToString(), new Node(string.Empty));
                    tree[expression.First().ToString()].Children.Add(expression.Last().ToString(), new Node("ん"));
                }
            }

            // c is equivalent to k, but not for chi, cha, etc. that's why we have to make a copy of k
            var kSubtreeCopy = JsonSerializer.Serialize(tree["k"].Children);
            tree.Add("c", new Node(string.Empty, JsonSerializer.Deserialize<Dictionary<string, Node>>(kSubtreeCopy)));

            //aliases
            foreach (var alias in Constants.Aliases)
            {
                var node = JsonSerializer.Serialize(tree[alias.Alternative[0].ToString()].Children[alias.Alternative[1].ToString()]);
                var nodeCopy = JsonSerializer.Deserialize<Node>(node);
                if (alias.Alias.Length == 1)
                    tree[alias.Alias] = nodeCopy;
                else if (alias.Alias.Length == 2)
                    tree[alias.Alias[0].ToString()].Children[alias.Alias[1].ToString()] = nodeCopy;
                else
                    tree[alias.Alias[0].ToString()].Children[alias.Alias[1].ToString()].Children[alias.Alias[2].ToString()] = nodeCopy;
            }

            //x & l subtree
            BuildSubtree(tree["x"], Constants.SmallLetters);
            tree.Add("l", new Node(string.Empty));
            BuildSubtree(tree["l"], Constants.SmallLetters);


            //add or modify special cases
            AddToTree(tree, Constants.SpecialCases);

            //tsu
            foreach (var consonant in Constants.Consonants)
            {
                var serialisedConsonantSubtree = JsonSerializer.Serialize(tree[consonant.Romaji].Children);
                var subtreeCopy = JsonSerializer.Deserialize<Dictionary<string, Node>>(serialisedConsonantSubtree);
                foreach (var node in subtreeCopy.Values)
                    addTsu(node);
                tree[consonant.Romaji].Children.Add(consonant.Romaji, new Node(string.Empty, subtreeCopy));
            }
            string[] consonants = { "c", "y", "w", "j" };
            foreach (var consonant in consonants)
            {
                var serialisedConsonantSubtree = JsonSerializer.Serialize(tree[consonant].Children);
                var subtreeCopy = JsonSerializer.Deserialize<Dictionary<string, Node>>(serialisedConsonantSubtree);
                foreach (var node in subtreeCopy.Values)
                    addTsu(node);
                tree[consonant].Children.Add(consonant, new Node(string.Empty, subtreeCopy));
            }
            // nn should not be っん
            tree["n"].Children.Remove("n");

            return tree;
        }

        private static void addTsu(Node node)
        {
            if (node.Data.Length != 0)
                node.Data = "っ" + node.Data;
            foreach (var childNode in node.Children)
                addTsu(childNode.Value);
        }


        public static Dictionary<string, Node> BuildKanaToHepburnTreeWithoutTsuAndNSubtree()
        {
            var tree = new Dictionary<string, Node>();

            //basic: go through basic romaji and add a node for each
            foreach(var pair in Constants.BasicRomaji)
            {
                tree.Add(pair.Kana, new Node(pair.Transliteration));
            }

            //add nodes for special symbols
            foreach (var symbol in Constants.SpecialSymbolsJpRomaji)
            {
                tree.Add(symbol.JSymbol, new Node(symbol.Symbol));
            }

            //add nodes for ya yu yo
            foreach (var kana in Constants.SmallYJpRomaji)
            {
                tree.Add(kana.Kana, new Node(kana.Transliteration));
            }

            //add nodes for small a i u e o
            foreach (var kana in Constants.smallAIUEO)
            {
                tree.Add(kana.Kana, new Node(kana.Transliteration));
            }

            //YOON_KANA for each Yoon Kana:
            //   find the node in the tree
            //   add a child from smallY and smallYExtra
            // e.g. くゃ => kya, くゅ => kyu
            foreach (var kana in Constants.yoonKana)
            {
                char firstRomajiChar = tree[kana].Data[0];
                foreach (var yKana in Constants.SmallYJpRomaji)
                {
                    tree[kana].Children.Add(yKana.Kana, new Node(firstRomajiChar + yKana.Transliteration));
                }
                foreach(var yKana in Constants.smallYExtra)
                {
                    tree[kana].Children.Add(yKana.Kana, new Node(firstRomajiChar + yKana.Transliteration));
                }
            }

            //YOON_KANA for each exceptional Yoon Kana:
            //   find the node in the tree
            //   add a child from smallY
            // e.g. じゃ -> ja 
            foreach (var kana in Constants.yoonExceptions)
            {
                foreach (var yKana in Constants.SmallYJpRomaji)
                {
                    var newNode = new Node(kana.Transliteration + yKana.Transliteration[1]);
                    tree[kana.Kana].Children.Add(yKana.Kana, newNode);
                }
                tree[kana.Kana].Children.Add("ぃ", new Node(kana.Transliteration + "yi"));
                tree[kana.Kana].Children.Add("ぇ", new Node(kana.Transliteration + "e"));
            }

            return tree;
        }

        public static Dictionary<string, Node> BuildKanaToHepburnTree()
        {
            var tree = BuildKanaToHepburnTreeWithoutTsuAndNSubtree();
            var tsuChildren = BuildKanaToHepburnTreeWithoutTsuAndNSubtree();

            tree.Add("っ", new Node(string.Empty, tsuChildren));

            foreach (var node in tree["っ"].Children.Values)
                ResolveTsu(node);

            static void ResolveTsu(Node node)
            {
                char firstLetter = node.Data[0];
                if (Constants.SokuonWhitelist.ContainsKey(firstLetter))
                {
                    string sokuonMapping = Constants.SokuonWhitelist[firstLetter];
                    node.Data = sokuonMapping + node.Data;
                }
                foreach (var childNode in node.Children)
                    ResolveTsu(childNode.Value);
            }

            foreach (var kana in Constants.AmbiguousVowels)
            {
                tree["ん"].Children.Add(kana.ToString(), new Node("n'" + tree[kana.ToString()].Data));
            }

            return tree;
        }
    }
}
