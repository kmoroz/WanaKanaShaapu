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
        public static Dictionary<string, Node> BuildTree()
        {
            var tree = new Dictionary<string, Node>();

            //basic: go through basic romaji and add a node for each
            foreach(var pair in Constants.basicRomaji)
            {
                tree.Add(pair.Kana, new Node(pair.Transliteration));
            }

            //add nodes for special symbols
            foreach (var symbol in Constants.specialSymbols)
            {
                tree.Add(symbol.jSymbol, new Node(symbol.Transliteration));
            }

            //add nodes for ya yu yo
            foreach (var Kana in Constants.smallY)
            {
                tree.Add(Kana.Kana, new Node(Kana.Transliteration));
            }

            //add nodes for small a i u e o
            foreach (var Kana in Constants.smallAIUEO)
            {
                tree.Add(Kana.Kana, new Node(Kana.Transliteration));
            }

            //YOON_KANA for each Yoon Kana:
            //   find the node in the tree
            //   add a child from smallY and smallYExtra
            // e.g. くゃ => kya, くゅ => kyu
            foreach (var kana in Constants.yoonKana)
            {
                char firstRomajiChar = tree[kana].Data[0];
                foreach (var yKana in Constants.smallY)
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
                foreach (var yKana in Constants.smallY)
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
            var tsuChildren = new Dictionary<string, Node>(tree);

            foreach(var node in tsuChildren.Values)
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

            return tree;
        }

 
    }
}
