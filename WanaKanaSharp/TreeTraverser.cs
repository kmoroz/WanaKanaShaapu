using System.Runtime.InteropServices;

namespace WanaKanaSharp
{
    public static class TreeTraverser
    {
        public static string TraverseTree(string word, Dictionary<string, Node> tree, [Optional] DefaultOptions options)
        {
            if (word.Length == 0)
                return string.Empty;

            if (options != null && options.CustomRomajiMapping != null && options.CustomRomajiMapping.ContainsKey(word[0].ToString()))
                return options.CustomRomajiMapping[word[0].ToString()] + TraverseTree(word[1..], tree, options);

            Node node;
            tree.TryGetValue(word[0].ToString(), out node);
            
            //If there are no nodes, we return the character as is (e.g. 'a', 'b', '?')
            if (node is null)
                return word[0].ToString() + TraverseTree(word[1..], tree, options);

            //If the node has children, we traverse as far as we can
            if (node.Children.Any())
            {
                for (var i = 1; i < word.Length; i++)
                {
                    Node child = node.FindChild(word[i].ToString());

                    if (child is null)
                        continue;

                    return child.Data + TraverseTree(word[(i+1)..], tree, options);
                }
            }

            //If the node had children but none we a match, we 
            //call the method on the remainder of the string
            return node.Data + TraverseTree(word[1..], tree, options);
        }
    }

}
