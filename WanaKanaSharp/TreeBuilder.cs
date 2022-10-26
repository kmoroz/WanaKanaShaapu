using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                {
                    if (!tree.ContainsKey(expression))
                        tree.Add(expression, new Node("ん"));
                }
                else
                {
                    if (!tree.ContainsKey(expression.First().ToString()))
                        tree.Add(expression.First().ToString(), new Node(string.Empty));
                    tree[expression.First().ToString()].Children.Add(expression.Last().ToString(), new Node("ん"));
                }
            }

            // c is equivalent to k, but not for chi, cha, etc. that's why we have to make a copy of k
            tree["c"] = tree["k"];

            //aliases
            foreach(var alias in Constants.Aliases)
            {
                var alternativeSubtree = tree[alias.Alternative[0].ToString()].Children[alias.Alternative[1].ToString()];
                if (alias.Alias.Length == 1)
                        tree[alias.Alias] = alternativeSubtree;
                else if (alias.Alias.Length == 2)
                    tree[alias.Alias[0].ToString()].Children[alias.Alias[1].ToString()] = alternativeSubtree;
                else
                    tree[alias.Alias[0].ToString()].Children[alias.Alias[1].ToString()].Children[alias.Alias[2].ToString()] = alternativeSubtree;
            }

            //x & l subtree
            BuildLXSubtrees(tree, "x");
            tree.Add("l", new Node(string.Empty));
            BuildLXSubtrees(tree, "l");

            return tree;
        }

        public static Dictionary<string, Node> BuildKanaToHepburnTree()
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
            /*            foreach (var yoonKana in Constants.yoonKana)
            {
                foreach (var smallVowel in Constants.smallAIUEO)
                {
                    var newNode = new Node(yoonKana.Transliteration + smallVowel.Transliteration);
                    tree[yoonKana.Kana].Children.Add(smallVowel.Kana, newNode);
                }
            }*/



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

            //smallY
            //iterate over small y list and merge it with the first char of yoon kana and add a node
            // e.g. き＋ゃ　＝＞　きゃ

            //smallYExtra
            //iterate over small y extra list and merge it with the first char of yoon kana and add a node
            // e.g. き＋ゃ　＝＞　きゃ

            //YOON_EXCEPTIONS
            // part 1 iterate over YOON_EXCEPTIONS list and merge it with the SECOND char of smallY list and add a node
            // e.g. じゃ -> ja 
            // part 2 iterate over YOON_EXCEPTIONS, add small i or small e nodes and add -yi and -e readings to them

            //TSU TREE
            //iterate over the existing tree and if value[0] is in sokuonwhitelist add node with sokuonwhitelist[value[0]] + value

            var tsuChildren = tree.ToDictionary(entry => entry.Key, entry => new Node(entry.Value.Data, entry.Value.Children));

            foreach (var node in tsuChildren.Values)
                ResolveTsu(node);

            tree.Add("っ", new Node(string.Empty, tsuChildren));

            static void ResolveTsu(Node node)
            {
                char firstLetter = node.Data[0];
                if(Constants.SokuonWhitelist.ContainsKey(firstLetter))
                {
                    string sokuonMapping = Constants.SokuonWhitelist[firstLetter];
                    node.Data = sokuonMapping + node.Data;
                }
                foreach (var childNode in node.Children)
                    ResolveTsu(childNode.Value);
            }
            //AMBIGUOUS_VOWELS
            //iterate over AMBIGUOUS_VOWELS and do n'AMBIGUOUS_VOWEL
            // e.g. node　ん　node あ　ー＞ n'a
            foreach(var kana in Constants.AmbiguousVowels)
            {
                tree["ん"].Children.Add(kana.ToString(), new Node("n'" + tree[kana.ToString()].Data));
            }

            return tree;
        }
    }
}
