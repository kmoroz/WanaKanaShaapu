using System.Runtime.InteropServices;

namespace WanaKanaSharp.Internal
{
    internal static class Utils
    {
        internal static bool IsMacron(char c)
        {
            foreach (var range in Constants.MacronCharacterRanges)
            {
                if (range.IsCharacterWithinRange(c))
                    return true;
            }
            return false;
        }

        internal static bool IsSokuon(string input)
        {
            if (input == Constants.SokuonHiragana || input == Constants.SokuonKatakana)
                return true;

            if (input.Length == 2 && !WanaKana.IsJapanese(input))
            {
                if (input.First() == input.Last())
                    return true;
            }
            return false;
        }

        internal static string ConvertChoonpu(string input, int i, bool isDestinationRomaji, [Optional] DefaultOptions options)
        {
            if (!options.ConvertLongVowelMark)
                return "ー";
            else
            {
                var syllable = Constants.KanaToHepburnTree[input[i - 1].ToString()].Data;
                var longVowel = syllable.Last().ToString();
                var longVowelConverted = Constants.RomajiToKanaTree[longVowel].Data;
                if (!isDestinationRomaji)
                    return longVowelConverted;
                return longVowel;
            }
        }

        internal static string KatakanaToHiragana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                bool isPreviousCharHiragana = i > 0 && WanaKana.IsHiragana(input[i - 1].ToString());
                if (c == Constants.Choonpu && !isPreviousCharHiragana
                    && i != 0)
                    result += ConvertChoonpu(result, i, false, options);
                else if (WanaKana.IsKatakana(c.ToString()) 
                    && c != Constants.Choonpu
                    && !Constants.KanaAsSymbol.Contains(c.ToString()))
                        result += (char)(c - 0x60);
                else
                    result += c;
            }
            return result;
        }

        internal static string HiraganaToKatakana(string input, DefaultOptions options)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (WanaKana.IsHiragana(c.ToString()) && !isCharLongDash(c)
                    && !isCharSlashDot(c))
                    result += (char)(c + 0x60);
                else
                    result += c;
            }
            return result;
        }

        internal static string GetTokenTypeCompact(char c)
        {
            string letter = c.ToString();
            if (WanaKana.IsJapanese(letter) && (Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                return "ja";
            else if (Char.IsAscii(c) && (Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                return "en";
            else
                return "other";
        }

        internal static string GetTokenType(char c, bool compact)
        {
            string letter = c.ToString();
            if (compact)
                return GetTokenTypeCompact(c);
            if (WanaKana.IsKanji(letter))
                return "kanji";
            else if (WanaKana.IsHiragana(letter))
                return "hiragana";
            else if (WanaKana.IsKatakana(letter))
                return "katakana";
            else if (Char.IsWhiteSpace(c))
                return "space";
            else if (Constants.ZenkakuNumbers.IsCharacterWithinRange(c))
                return "japaneseNumeral";
            else if (WanaKana.IsJapanese(letter) && Char.IsPunctuation(c))
                return "japanesePunctuation";
            else if (WanaKana.IsJapanese(letter))
                return "ja";
            else if (Char.IsAscii(c) && Char.IsLetter(c))
                return "en";
            else if (Char.IsDigit(c) && Char.IsAscii(c))
                return "englishNumeral";
            else if (Char.IsPunctuation(c)) //|| Constants.WhitespacePunctuationDictionary.ContainsKey(letter))
                return "englishPunctuation";
            else
                return "other";
        }

        internal static string ResolveSokuon(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                if (IsSokuon(letter.ToString()) && i + 1 < input.Length)
                {
                    input = input.Substring(0, i) + input[i + 1] + input.Substring(i + 1);
                }
            }
            return input;
        }

        internal static Dictionary<string, Node> AddObsoleteKana()
        {
            var treeCopy = TreeBuilder.BuildRomajiToKanaTree();
            foreach (var kana in Constants.ObsoleteKana)
                treeCopy[kana.Romaji.First().ToString()].Children[kana.Romaji.Last().ToString()].Data = kana.Kana;
            return treeCopy;
        }

        internal static Dictionary<string, Node> CreateCustomTree(DefaultOptions options)
        {
            var treeCopy = TreeBuilder.BuildRomajiToKanaTree();
            foreach (var pair in options.CustomKanaMapping)
                ChangeNodeData(treeCopy, pair.Key, pair.Value);
            return treeCopy;
        }

        internal static void ChangeNodeData(Dictionary<string, Node> tree, string key, string value)
        {
            Node node = tree[key.First().ToString()];
            if (key.Length == 1 || !node.Children.Any())
                node.Data = value;
            else if (node.Children.ContainsKey(key[1].ToString()))
                ChangeNodeData(tree[key.First().ToString()].Children, key[1..], value);
        }

        internal static List<string> SliceInput(string input)
        {
            List<string> inputArray = new List<string>();
            string temp = string.Empty;
            for (int i = 1; i < input.Length; i++)
            {
                if ((char.IsLower(input[i]) && char.IsLower(input[i - 1]))
                    || (char.IsUpper(input[i]) && char.IsUpper(input[i - 1])) || char.IsWhiteSpace(input[i - 1]))
                    temp += input[i - 1];
                else
                {
                    temp += input[i - 1];
                    inputArray.Add(temp);
                    temp = string.Empty;
                }
            }
            temp += input.Last();
            inputArray.Add(temp);
            return inputArray;
        }

        internal static bool isCharLongDash(char c)
        {
            if (c == Constants.ProlongedSoundMark)
                return true;
            return false;
        }
        internal static bool isCharSlashDot(char c)
        {
            if (c == Constants.KanaSlashDot)
                return true;
            return false;
        }
    }
}