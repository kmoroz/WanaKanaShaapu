using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WanaKanaSharp
{
    public static class WanaKana
    {
        public static bool IsHiragana(string input)
        {
            foreach (char c in input)
            {
                if ((c >= Constants.HiraganaMin && c <= Constants.HiraganaMax) || c == Constants.Choonpu)
                    continue;
                else
                    return false;
            }
            return true;
        }
        public static bool IsKana(string input)
        {
            foreach (char c in input)
            {
                if (c >= Constants.KanaMin && c <= Constants.KanaMax)
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsKanji(string input)
        {
            foreach (char c in input)
            {
                if (c >= Constants.KanjiMin && c <= Constants.KanjiMax)
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsKatakana(string input)
        {
            foreach (char c in input)
            {
                if (c >= Constants.KatakanaMin && c <= Constants.KatakanaMax)
                    continue;
                else
                    return false;
            }
            return true;
        }

        private static bool IsMacron(char c)
        {
            if (c == Constants.MacronAMin || c == Constants.MacronAMax
                || c == Constants.MacronOMin || c == Constants.MacronOMax
                || c == Constants.MacronUMin || c == Constants.MacronUMax)
                return true;
            return false;
        }

        public static bool IsRomaji(string input, [Optional] string allowed)
        {
            if (allowed != null)
                input = Regex.Replace(input, allowed, string.Empty);

            foreach (char c in input)
            {
                if (Char.IsAscii(c) || Char.IsWhiteSpace(c)
                    || Char.IsPunctuation(c) || IsMacron(c))
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsJapanese(string input, [Optional] string allowed)
        {
            if (allowed != null)
                input = Regex.Replace(input, allowed, string.Empty);

            foreach (char c in input)
            {
                if (IsKana(c.ToString()) || IsKanji(c.ToString())
                    || (c >= Constants.JapanesePunctuationMin && c <= Constants.JapanesePunctuationMax)
                    || (c >= Constants.ZenzakuMin && c <= Constants.ZenzakuMax))
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsMixed(string input, [Optional] DefaultOptions options)
        {
            bool containsRomaji = false;
            bool containsKana = false;
            foreach (char c in input)
            {
                if (IsKana(c.ToString()))
                    containsKana = true;
                else if (IsRomaji(c.ToString()))
                    containsRomaji = true;
                else if (options != null && !options.PassKanji && IsKanji(c.ToString()))
                    return false;
                if (containsRomaji && containsKana)
                    return true;
            }
            return false;
        }

        public static string StripOkurigana(string input, [Optional] bool leading, [Optional]  string matchKanji)
         {
            string okuriganaString = input;
            if (matchKanji != null)
                okuriganaString = matchKanji;
            while (IsHiragana(okuriganaString.Last().ToString()))
            {
                okuriganaString = okuriganaString.Remove(okuriganaString.Length - 1);
            }
            if (leading)
            {
                while(IsHiragana(okuriganaString.First().ToString()))
                {
                    okuriganaString = okuriganaString.Remove(0, 1);
                }
            }
            if (matchKanji != null)
            {
                if (leading)
                    return input.Substring(1, okuriganaString.Length);
                return input.Remove(okuriganaString.Length);
            }
                return okuriganaString;
        }

        public static string ToHiragana(string input, [Optional] DefaultOptions options)
        {
            string result = "";
            string syllable = "";
            foreach (char c in input)
            {
                if (IsKatakana(c.ToString()))
                    result += (char)(c - 0x60);
                else if (IsRomaji(c.ToString()) || Char.IsLetter(c))
                {
                    syllable += c;
                    foreach (var item in HiraganaRomaji.HiraganaRomajiDictionary)
                    {
                        if (item.Value == syllable)
                        {
                            result += item.Key;
                            syllable = "";
                        }
                    }
                }
                else
                    result += c;
            }
            return result;
        }
    }
}