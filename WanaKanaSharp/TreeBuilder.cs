
using System.Text.Json;

namespace WanaKanaSharp
{
    public class TreeBuilder
    {
        private static void BuildLXSubtrees(Dictionary<string, Node> tree, string key)
        {
            foreach (var smallLetter in Constants.SmallLetters)
            {
                var xSubtree = tree[key];
                if (smallLetter.Romaji.Length == 1)
                    xSubtree.Children.Add(smallLetter.Romaji, new Node(smallLetter.Kana));
                else
                {
                    var firstChar = smallLetter.Romaji.First().ToString();
                    var lastChar = smallLetter.Romaji.Last().ToString();
                    foreach (char c in smallLetter.Romaji)
                    {
                        if (firstChar == c.ToString())
                        {
                            if (!xSubtree.Children.ContainsKey(firstChar))
                                xSubtree.Children.Add(firstChar, new Node(string.Empty));
                        }
                        else
                            xSubtree.Children[firstChar].Children.Add(lastChar, new Node(smallLetter.Kana));
                    }
                }
            }
        }

        private static void AddToRomajiKanaTree(Dictionary<string, Node> tree, string key, string value)
        {
            string firstChar = key.First().ToString();
            string lastChar = key.Last().ToString();

            if (!tree.ContainsKey(firstChar))
                tree.Add(firstChar, new Node(string.Empty));
            if (key.Length == 2)
            {
                if (!tree[firstChar].Children.ContainsKey(lastChar))
                    tree[firstChar].Children.Add(lastChar, new Node(value));
                tree[firstChar].Children[lastChar].Data = value;
            }
            else if (key.Length == 3)
            {
                var secondChar = key[1].ToString();
                if (!tree[firstChar].Children[secondChar].Children.ContainsKey(lastChar))
                    tree[firstChar].Children[secondChar].Children.Add(lastChar, new Node(value));
                tree[firstChar].Children[secondChar].Children[lastChar].Data = value;
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
            {
                tree.Add(symbol.Symbol, new Node(symbol.JSymbol));
            }

            //add tya, sya, etc.
            foreach(var consonant in Constants.Consonants)
            {
                if (!tree.ContainsKey(consonant.Romaji))
                    tree.Add(consonant.Romaji, new Node(string.Empty));
                foreach (var smallY in Constants.SmallYRomajiJp)
                {
                    if (!tree[consonant.Romaji].Children.ContainsKey("y"))
                        tree[consonant.Romaji].Children.Add("y", new Node(string.Empty));
                    tree[consonant.Romaji].Children["y"].Children.Add(smallY.Romaji[1].ToString(), new Node(consonant.Kana + smallY.Kana));
                }
            }

            //things like うぃ, くぃ, etc.
            foreach (var construction in Constants.AIUEOConstructions)
            {
                if (!tree.ContainsKey(construction.Romaji.First().ToString()))
                    tree.Add(construction.Romaji.First().ToString(), new Node(string.Empty));
                if (construction.Romaji.Length == 1)
                {
                    foreach (var vowel in Constants.SmallVowels)
                        tree[construction.Romaji].Children.Add(vowel.Romaji, new Node(construction.Kana + vowel.Kana));
                }
                else
                {
                    //get the second letter (e.g. for wh, 'h')
                    var nextConsonant = construction.Romaji[1].ToString();

                    //declare a new subtree to store the next consonant + small vowels
                    var nextConsonantVowelSubtree = new Dictionary<string, Node>();

                    //iterate through the small vowels and create a sub tree
                    foreach (var smallVowel in Constants.SmallVowels)
                        nextConsonantVowelSubtree.Add(smallVowel.Romaji, new Node(construction.Kana + smallVowel.Kana));

                    tree[construction.Romaji.First().ToString()].Children.Add(nextConsonant, new Node(string.Empty, nextConsonantVowelSubtree));
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
            BuildLXSubtrees(tree, "x");
            tree.Add("l", new Node(string.Empty));
            BuildLXSubtrees(tree, "l");

            foreach (var exception in Constants.SpecialCases)
                AddToRomajiKanaTree(tree, exception.Romaji, exception.Kana);

            //tsu
            foreach (var consonant in Constants.Consonants)
            {
                var serialisedConsonantSubtree = JsonSerializer.Serialize(tree[consonant.Romaji].Children);
                var subtreeCopy = JsonSerializer.Deserialize<Dictionary<string, Node>>(serialisedConsonantSubtree);
                foreach (var node in subtreeCopy.Values)
                    addTsu(node);
                tree[consonant.Romaji].Children.Add(consonant.Romaji, new Node(string.Empty, subtreeCopy));
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
