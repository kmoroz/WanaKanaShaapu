using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp
{
    [Serializable]
    public class Node
    {
        public string Data { get; set; } = string.Empty;
        public Dictionary<string, Node> Children { get; set; } = new();

        public Node? FindChild(string key)
        {
            if (!Children.Any())
                return null;

            Children.TryGetValue(key, out Node child);

            return child;
        }

        public Node(string data)
        {
            Data = data;
            Children = new Dictionary<string, Node>();
        }

        public Node(string data, Dictionary<string, Node> children)
        {
            Data = data;
            Children = children;
        }

        public Node(){}
    }
}
