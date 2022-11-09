﻿using System.Runtime.InteropServices;

namespace WanaKanaSharp
{
    public static class TreeTraverser
    {
        public static string TraverseTree(string result, string word, Dictionary<string, Node> head, Dictionary<string, Node> tree, [Optional] DefaultOptions options)
        {
            if (word.Length == 0)
                return string.Empty;

            if (options is null)
                options = new DefaultOptions();

            //If character is not in tree, add and continue
            if (!tree.ContainsKey(word[0].ToString()))
                return word[0].ToString() + TraverseTree(result, word[1..], head, tree, options);
            

            Node node = tree[word[0].ToString()];
            if (options.CustomRomajiMapping.ContainsKey(word[0].ToString()))
                return options.CustomRomajiMapping[word[0].ToString()] + TraverseTree(result, word[1..], tree, tree, options);
            
            if (word.Length == 1)
                return node.Data;

            if (WanaKana.IsHiragana(word.First().ToString()))
                result = node.Data;

            if (!node.Children.Any() || !node.Children.ContainsKey(word[1].ToString()))
                result = node.Data;
            if (!node.Children.Any() && word.Length == 1)
                return result;

            if (node.Children.ContainsKey(word[1].ToString()))
                return TraverseTree(result, word[1..], head, tree[word[0].ToString()].Children, options);
            else
                return result += TraverseTree(result, word[1..], head, head, options);

            return string.Empty;
        }
    }
}