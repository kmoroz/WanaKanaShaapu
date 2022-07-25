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
                else if (IsRomaji(c.ToString()))
                {
                    syllable += c;
                    if (options != null && options.PassRomaji)
                        result += c;
                    else if (Char.IsLetter(c))
                    {
                        foreach (var item in HiraganaRomaji.HiraganaRomajiDictionary)
                        {
                            if (item.Value == syllable.ToLower())
                            {
                                if (options != null && options.UseObsoleteKana && HiraganaRomaji.ObsoleteHiraganaDictionary.ContainsKey(syllable))
                                    result += HiraganaRomaji.ObsoleteHiraganaDictionary[syllable];
                                else
                                    result += item.Key;
                                syllable = "";
                            }
                        }
                    }
                    else if (Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                    {
                        foreach (var item in HiraganaRomaji.WhitespacePunctuationDictionary)
                        {
                            if (item.Value == syllable)
                            {
                                result += item.Key;
                                syllable = "";
                            }
                        }
                    }
                }
                else
                    result += c;
            }
            return result;
        }
        public static string ToKatakana(string input, [Optional] DefaultOptions options)
        {
            string result = "";
            string syllable = "";
            foreach (char c in input)
            {
                if (IsHiragana(c.ToString()))
                    result += (char)(c + 0x60);
                else if (IsRomaji(c.ToString()))
                {
                    syllable += c;
                    if (options != null && options.PassRomaji)
                        result += c;
                    else if (Char.IsLetter(c))
                    {
                        foreach (var item in HiraganaRomaji.KatakanaRomajiDictionary)
                        {
                            if (item.Value == syllable.ToLower())
                            {
                                if (options != null && options.UseObsoleteKana && HiraganaRomaji.ObsoleteKatakanaDictionary.ContainsKey(syllable))
                                    result += HiraganaRomaji.ObsoleteKatakanaDictionary[syllable];
                                else
                                    result += item.Key;
                                syllable = "";
                                break;
                            }
                        }
                    }
                    else if (Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                    {
                        foreach (var item in HiraganaRomaji.WhitespacePunctuationDictionary)
                        {
                            if (item.Value == syllable)
                            {
                                result += item.Key;
                                syllable = "";
                            }
                        }
                    }
                }
                else
                    result += c;
            }
            return result;
        }


        public static string characterType(char c)
        {
            string letter = c.ToString();
            if (IsKanji(letter))
                return "kanji";
            else if (IsHiragana(letter))
                return "hiragana";
            else if (IsKatakana(letter))
                return "katakana";
            else if (Char.IsWhiteSpace(c))
                return "whitespace";
            else if (Char.IsLetter(c))
                return "en";
            else if (Char.IsDigit(c))
                return "english numeral";
            else if (Char.IsPunctuation(c))
                return "english punctuation";
            else if (c >= Constants.PunctuationMin && c <= Constants.PunctuationMax)
                return "japanese punctuation";
            else if (IsRomaji(letter))
                return "ja";
            else
                return "other";
        }

        public static string ConvertToKana(string token)
        {
            if (token.Length == 0)
                return string.Empty;
            if (char.IsLower(token.Last()))
                return ToHiragana(token);
            else
                return ToKatakana(token);
        }

        public static string ToKana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            string toBeConverted = string.Empty;
            bool isCurrentCharLowercase;
            bool isPreviousCharLowercase;
            foreach (char c in input)
            {
                if (IsKana(c.ToString()) || IsKanji(c.ToString()))
                {
                    result += ConvertToKana(toBeConverted) + c;
                    toBeConverted = string.Empty;
                }
                else if (char.IsPunctuation(c))
                {
                    result += ConvertToKana(toBeConverted) + HiraganaRomaji.WhitespacePunctuationDictionary[c.ToString()];
                    toBeConverted = string.Empty;
                }
                else
                {
                    if (toBeConverted.Length == 0)
                        toBeConverted += c;
                    else
                    {
                        isCurrentCharLowercase = char.IsLower(c);
                        isPreviousCharLowercase = char.IsLower(toBeConverted.Last());
                        if (isCurrentCharLowercase == isPreviousCharLowercase)
                            toBeConverted += c;
                        else
                        {
                            if (isPreviousCharLowercase)
                                result += ToHiragana(toBeConverted);
                            else
                                result += ToKatakana(toBeConverted);
                            toBeConverted = string.Empty;
                        }
                    }
                }
            }
            return result;
        }
    }
}
           /* bool currentType;
            bool previousType = char.IsLower(input.First());
            string toBeConverted = "";
            string result = "";
            foreach (char c in input)
            {
                currentType = char.IsLower(c);
                if (IsKana(c.ToString()))
                {
                    toBeConverted += c;
                    break;
                }
                if (currentType == previousType)
                    toBeConverted += c;
                else
                {
                    if (!currentType)
                        result += ToHiragana(toBeConverted);
                    else
                        result += ToKatakana(toBeConverted);
                    toBeConverted = "";
                    toBeConverted += c;
                }
                previousType = currentType;
            }
            return result;*/