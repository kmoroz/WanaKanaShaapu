namespace WanaKanaSharp
{
    public struct Token
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public Token(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }

    public class Tokenization
    {
        public List<Token> Tokens { get; set; } = new List<Token>();
        public string[] Values { get { return Tokens.Select(token => token.Value).ToArray(); } }
    }
}