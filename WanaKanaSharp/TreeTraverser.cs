using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp
{
    public static class TreeTraverser
    {
        public static string TraverseTree(string word, Dictionary<string, Node> tree)
        {
            if (word.Length == 0)
                return string.Empty;

            Node node;
            tree.TryGetValue(word[0].ToString(), out node);

            if (node is null)
                return word[0].ToString() + TraverseTree(word[1..], tree);

            for (var i = 1; i < word.Length; i++)
            {
                if (!node.Children.Any())
                    return node.Data + TraverseTree(word[i..], tree);

                Node child = node.FindChild(word[i].ToString());
                if (child is not null)
                    node = child;
            }

            return node.Data;
        }
    }

}
