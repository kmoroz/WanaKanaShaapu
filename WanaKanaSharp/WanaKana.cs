using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Linq;

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
                    || Char.IsPunctuation(c) || IsMacron(c) 
                    || (c >= Constants.RomajiMin && c <= Constants.RomajiMax))
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

        public static bool IsMixed(string input, [Optional] bool? passKanji)
        {
            bool containsRomaji = false;
            bool containsKana = false;
            foreach (char c in input)
            {
                if (IsKana(c.ToString()))
                    containsKana = true;
                else if (IsRomaji(c.ToString()))
                    containsRomaji = true;
                else if (passKanji.HasValue && !passKanji.Value && IsKanji(c.ToString()))
                    return false;
                if (containsRomaji && containsKana)
                    return true;
            }
            return false;
        }

        public static string StripOkurigana(string input, [Optional] bool leading, [Optional] string matchKanji)
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

        public static bool IsSokuon(string input)
        {
            if (input.Length == 2)
            {
                if (input.First() == input.Last())
                    return true;
            }
            return false;
        }

        public static string ToHiragana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            string syllable = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (IsKatakana(c.ToString()))
                    result += (char)(c - 0x60);
                else if (IsRomaji(c.ToString()) || IsRomaji(c.ToString()) && options != null && !options.PassRomaji)
                {
                    syllable += c;
                    if (options != null && options.PassRomaji)
                        result += c;
                    else if (Char.IsLetter(c))
                    {
                        if (syllable == "n" && i + 1 < input.Length && Constants.EnglishVowels.Contains(input[i + 1]))
                            continue;
                        if (IsSokuon(syllable))
                        {
                            result += 'っ';
                            syllable = syllable.Remove(syllable.Length - 1);
                        }
                        if (HiraganaRomaji.HiraganaRomajiDictionary.ContainsKey(syllable.ToLower()))
                        {
                            if (options != null && options.UseObsoleteKana && HiraganaRomaji.ObsoleteHiraganaDictionary.ContainsKey(syllable))
                                result += HiraganaRomaji.ObsoleteHiraganaDictionary[syllable.ToLower()];
                            else
                                result += HiraganaRomaji.HiraganaRomajiDictionary[syllable.ToLower()];
                            syllable = string.Empty;
                        }
                    }
                    else if (Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                        result += HiraganaRomaji.WhitespacePunctuationDictionary[c.ToString()];
                }
                else
                    result += c;
            }
            return result;
        }

        public static string ToKatakana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            string syllable = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (IsHiragana(c.ToString()))
                    result += (char)(c + 0x60);
                else if (IsRomaji(c.ToString()))
                {
                    syllable += c;
                    if (options != null && options.PassRomaji)
                        result += c;
                    else if (Char.IsLetter(c))
                    {
                        if ((syllable == "n" || syllable == "N") && Constants.EnglishVowels.Contains(input[i + 1]))
                            continue;
                        if (IsSokuon(syllable))
                        {
                            result += 'ッ';
                            syllable = syllable.Remove(syllable.Length - 1);
                        }
                        if (HiraganaRomaji.KatakanaRomajiDictionary.ContainsKey(syllable.ToLower()))
                        {
                            if (options != null && options.UseObsoleteKana && HiraganaRomaji.ObsoleteKatakanaDictionary.ContainsKey(syllable.ToLower()))
                                result += HiraganaRomaji.ObsoleteKatakanaDictionary[syllable.ToLower()];
                            else
                                result += HiraganaRomaji.KatakanaRomajiDictionary[syllable.ToLower()];
                            syllable = string.Empty;
                        }      
                    }
                    else if (Char.IsPunctuation(c) || Char.IsWhiteSpace(c))
                        result += HiraganaRomaji.WhitespacePunctuationDictionary[c.ToString()];
                }
                else
                    result += c;
            }
            return result;
        }

        public static string MapCharacterToTypeCompact(char c)
        {
            string letter = c.ToString();
            if (IsJapanese(letter) && (Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                return "ja";
            else if (Char.IsAscii(c) && (Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                return "en";
            else
                return "other";
        }
        public static string MapCharacterToType(char c, bool compact)
        {
            string letter = c.ToString();
            if (compact)
                return MapCharacterToTypeCompact(c);
            if (IsKanji(letter))
                return "kanji";
            else if (IsHiragana(letter))
                return "hiragana";
            else if (IsKatakana(letter))
                return "katakana";
            else if (IsJapanese(letter) && Char.IsPunctuation(c))
                return "japanesePunctuation";
            else if (Char.IsWhiteSpace(c))
                return "space";
            else if (Char.IsAscii(c) && Char.IsLetter(c))
                return "en";
            else if (Char.IsDigit(c) && Char.IsAscii(c))
                return "englishNumeral";
            else if (Char.IsDigit(c))
                return "japaneseNumeral";
            else if (Char.IsPunctuation(c))
                return "englishPunctuation";
            else if (IsRomaji(letter))
                return "ja";
            else
                return "other";
        }

        public static string ConvertToKana(string token, [Optional] DefaultOptions options)
        {
            if (token.Length == 0)
                return string.Empty;
            if (char.IsLower(token.Last()))
                return ToHiragana(token, options);
            else
                return ToKatakana(token, options);
        }

        public static string ToKana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            string toBeConverted = string.Empty;
            bool isCurrentCharLowercase;
            bool isPreviousCharLowercase;
            foreach (char c in input)
            {
                if (IsKana(c.ToString()) || IsKanji(c.ToString()) || char.IsWhiteSpace(c))
                {
                    result += ConvertToKana(toBeConverted, options) + c;
                    toBeConverted = string.Empty;
                }
                else if (char.IsPunctuation(c) || HiraganaRomaji.WhitespacePunctuationDictionary.ContainsKey(c.ToString()))
                {
                    result += ConvertToKana(toBeConverted, options) + HiraganaRomaji.WhitespacePunctuationDictionary[c.ToString()];
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
                            result += ConvertToKana(toBeConverted, options);
                            toBeConverted = string.Empty;
                        }
                    }
                }
            }
            return result + ConvertToKana(toBeConverted, options);
        }

        public static Tokenization Tokenize(string input, [Optional] bool compact)
        {
            string currentType = string.Empty;
            string previousType = string.Empty;
            string token = string.Empty;
            Tokenization tokenization = new Tokenization();
            foreach (char c in input)
            {
                currentType = MapCharacterToType(c, compact);
                if (string.IsNullOrEmpty(previousType) || currentType == previousType)
                    token += c;
                else
                {
                    if (compact && Char.IsWhiteSpace(c) && (previousType == "en" || previousType == "ja"))
                    {
                        token += c;
                        continue;
                    }
                    tokenization.Tokens.Add(new Token(previousType, token));
                    token = string.Empty;
                    token += c;
                }
                previousType = currentType;
            }
            tokenization.Tokens.Add(new Token(currentType, token));
            return tokenization;
        }
    }
}


