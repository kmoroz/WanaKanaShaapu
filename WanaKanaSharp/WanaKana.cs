using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WanaKanaSharp
{
    public static class WanaKana
    {
        public static bool IsHiragana(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            foreach (char c in input)
            {
                if (Constants.HiraganaChars.IsCharacterWithinRange(c) || c == Constants.Choonpu)
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsKatakana(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            foreach (char c in input)
            {
                if (Constants.KatakanaChars.IsCharacterWithinRange(c))
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsKana(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            foreach (char c in input)
            {
                if (IsHiragana(c.ToString()) || IsKatakana(c.ToString()))
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsKanji(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            foreach (char c in input)
            {
                if (Constants.KanjiChars.IsCharacterWithinRange(c))
                    continue;
                else
                    return false;
            }
            return true;
        }

        private static bool IsMacron(char c)
        {
            foreach (var range in Constants.MacronChars)
            {
                if (range.IsCharacterWithinRange(c))
                    return true;
            }
            return false;
        }

        public static bool IsRomaji(string input, [Optional] string allowed)
        {
            if (string.IsNullOrEmpty(input))
                return false;
            if (allowed != null)
                input = Regex.Replace(input, allowed, string.Empty);

            foreach (char c in input)
            {
                if (Constants.RomajiChars.IsCharacterWithinRange(c) || IsMacron(c))
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
                var isInRange = Constants.JapaneseChars.Any(ranges => ranges.IsCharacterWithinRange(c));

                if (isInRange)
                    continue;
                else
                    return false;
            }
            return true;
        }

        public static bool IsMixed(string input, [Optional] bool? passKanji)
        {
            bool hasKanji = false;
            if (passKanji.HasValue && !passKanji.Value)
                hasKanji = input.Any(chars => IsKanji(chars.ToString()));
            return (input.Any(chars => IsHiragana(chars.ToString())) || input.Any(chars => IsKatakana(chars.ToString())))
                && input.Any(chars => IsRomaji(chars.ToString())) && !hasKanji;
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

        private static bool IsSokuon(string input)
        {
            if (IsJapanese(input))
                return false;
            if (input.Length == 2)
            {
                if (input.First() == input.Last())
                    return true;
            }
            return false;
        }

        private static string HandleChoonpuConversion(string input, int i, [Optional] DefaultOptions options)
        {
            char charBeforeChoonpu = input[i - 1];
            string syllable = string.Empty;
            string latinVowel = string.Empty;

            if (IsHiragana(charBeforeChoonpu.ToString()))
            {
                syllable = Constants.RomajiHiraganaDictionary.First(item => item.Value == charBeforeChoonpu.ToString()).Key;
                latinVowel = syllable.Last().ToString();
                return latinVowel;
            }
            else
            {
                if (options != null && !options.ConvertLongVowelMark)
                    return "ー";
                syllable = Constants.RomajiKatakanaDictionary.First(item => item.Value == charBeforeChoonpu.ToString()).Key;
                latinVowel = syllable.Last().ToString();
                string convertedVowel = Constants.RomajiHiraganaDictionary[latinVowel];
                return convertedVowel;
            }
        }

        private static string KatakanaToHiragana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (IsRomaji(c.ToString()))
                    result += c;
                else if (IsKatakana(c.ToString()) && c != Constants.Choonpu)
                    result += (char)(c - 0x60);
                else
                    result += HandleChoonpuConversion(input, i, options);
            }
            return result;
        }

        private static string RomajiToHiragana(string input, [Optional] DefaultOptions options)
        {
            string syllable = string.Empty;
            string result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                syllable += c;
                if (syllable == "n" && i + 1 < input.Length && Constants.EnglishVowels.Contains(input[i + 1]))
                    continue;
                if (IsSokuon(syllable))
                {
                    result += Constants.SokuonHiragana;
                    syllable = syllable.Remove(syllable.Length - 1);
                }
                if (options != null && options.CustomKanaMapping != null && options.CustomKanaMapping.ContainsKey(syllable))
                    result += options.CustomKanaMapping[syllable];
                else if (Constants.RomajiHiraganaDictionary.ContainsKey(syllable))
                {
                    if (options != null && options.UseObsoleteKana && Constants.RomajiObsoleteHiraganaDictionary.ContainsKey(syllable))
                        result += Constants.RomajiObsoleteHiraganaDictionary[syllable];
                    else
                        result += Constants.RomajiHiraganaDictionary[syllable];
                }
                else if (char.IsPunctuation(c) || char.IsWhiteSpace(c))
                    result += Constants.WhitespacePunctuationDictionary[c.ToString()];
                else
                {
                    if (IsJapanese(c.ToString()))
                        result += c;
                    if (char.IsPunctuation(c) || char.IsWhiteSpace(c))
                        result += Constants.WhitespacePunctuationDictionary[c.ToString()];
                    continue;
                }
                syllable = string.Empty;
            }
            return result;
        }

        private static string RomajiToKatakana(string input, [Optional] DefaultOptions options)
        {
            string syllable = string.Empty;
            string result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                syllable += c;
                if (syllable == "n" && i + 1 < input.Length && Constants.EnglishVowels.Contains(input[i + 1]))
                    continue;
                if (IsSokuon(syllable))
                {
                    result += Constants.SokuonKatakana;
                    syllable = syllable.Remove(syllable.Length - 1);
                }
                if (options != null && options.CustomKanaMapping != null && options.CustomKanaMapping.ContainsKey(syllable))
                    result += options.CustomKanaMapping[syllable];
                else if (Constants.RomajiKatakanaDictionary.ContainsKey(syllable))
                {
                    if (options != null && options.UseObsoleteKana && Constants.RomajiObsoleteKatakanaDictionary.ContainsKey(syllable))
                        result += Constants.RomajiObsoleteKatakanaDictionary[syllable];
                    else
                        result += Constants.RomajiKatakanaDictionary[syllable];
                }
                else
                {
                    if (IsJapanese(c.ToString()))
                        result += c;
                    if (char.IsPunctuation(c) || char.IsWhiteSpace(c))
                        result += Constants.WhitespacePunctuationDictionary[c.ToString()];
                    continue;
                }
                syllable = string.Empty;
            }
            return result;
        }

        private static string RomajiToKana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            string syllable = string.Empty;
            if (options != null && options.PassRomaji)
                return input;
            else if (input.All(chars => !char.IsUpper(chars)))
                return RomajiToHiragana(input, options);
            else if (input.All(chars => !char.IsLower(chars)))
                return RomajiToKatakana(input.ToLower(), options);
            return result;
        }

        private static string HiraganaToKatakana(string input, DefaultOptions options)
        {
            string result = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (IsRomaji(c.ToString()))
                    result += c;
                else if (IsHiragana(c.ToString()) && c != Constants.Choonpu)
                    result += (char)(c + 0x60);
                else
                    result += HandleChoonpuConversion(input, i, options);
            }
            return result;
        }

        public static string ToHiragana(string input, [Optional] DefaultOptions options)
        {
            if (options != null && options.PassRomaji)
                return KatakanaToHiragana(input, options);
            else if (IsKatakana(input))
                return KatakanaToHiragana(input, options);
            else if (IsRomaji(input))
                return RomajiToKana(input, options);
            else if (IsMixed(input))
            {
                string convertedKatakana = KatakanaToHiragana(input, options);
                return RomajiToKana(convertedKatakana.ToLower(), options);
            }
            return KatakanaToHiragana(input, options);
        }

        public static string ToKatakana(string input, [Optional] DefaultOptions options)
        {
            if (options != null && options.PassRomaji)
                return HiraganaToKatakana(input, options);
            else if (IsKatakana(input))
                return HiraganaToKatakana(input, options);
            else if (IsRomaji(input))
                return RomajiToKatakana(input.ToLower(), options);
            else if (IsMixed(input))
            {
                string convertedHiragana = HiraganaToKatakana(input, options);
                return RomajiToKatakana(convertedHiragana.ToLower(), options);
            }
            return HiraganaToKatakana(input, options);
        }

        private static string MapCharacterToTypeCompact(char c)
        {
            string letter = c.ToString();
            if (IsJapanese(letter) && (Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                return "ja";
            else if (Char.IsAscii(c) && (Char.IsLetter(c) || Char.IsWhiteSpace(c)))
                return "en";
            else
                return "other";
        }

        private static string MapCharacterToType(char c, bool compact)
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
            else if (Char.IsWhiteSpace(c))
                return "space";
            else if (Constants.ZenkakuNumbers.IsCharacterWithinRange(c))
                return "japaneseNumeral";
            else if (IsJapanese(letter) && Char.IsPunctuation(c))
                return "japanesePunctuation";
            else if (IsJapanese(letter))
                return "ja";
            else if (Char.IsAscii(c) && Char.IsLetter(c))
                return "en";
            else if (Char.IsDigit(c) && Char.IsAscii(c))
                return "englishNumeral";
            else if (Char.IsPunctuation(c) || Constants.WhitespacePunctuationDictionary.ContainsKey(letter))
                return "englishPunctuation";
            else
                return "other";
        }

        private static string ConvertToKana(string token, [Optional] DefaultOptions options)
        {
            if (token.Length == 0)
                return string.Empty;
            if (char.IsLower(token.Last()))
                return ToHiragana(token, options);
            else
                return ToKatakana(token, options);
        }

        private static string ConvertPunctuation(string input)
        {
            string result = string.Empty;
            foreach (char c in input)
            {
                result += Constants.WhitespacePunctuationDictionary[c.ToString()];
            }
            return result;
        }

        public static string ToKana(string input, [Optional] DefaultOptions options)
        {
            Tokenization inputTokens = Tokenize(input);
            string convertedString = string.Empty;

            foreach (var token in inputTokens.Tokens)
            {
                if (token.Type == "en")
                    convertedString += RomajiToKana(token.Value, options);
                else if (token.Type == "englishPunctuation")
                    convertedString += ConvertPunctuation(token.Value);
                else
                    convertedString += token.Value;
            }
            return convertedString;
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

        public static string ToRomaji(string kana, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            for (int i = 0; i < kana.Length; i++)
            {
                char c = kana[i];
                if (c == Constants.Choonpu && IsHiragana(kana[i - 1].ToString()))
                    result += HandleChoonpuConversion(kana, i);
                else if (Char.IsWhiteSpace(c) && IsJapanese(c.ToString()) || Char.IsPunctuation(c) || c == Constants.Choonpu)
                    result += Constants.WhitespacePunctuationDictionary.First(item => item.Value == c.ToString()).Key;
                else if (options != null && options.CustomRomajiMapping != null && options.CustomRomajiMapping.ContainsKey(c.ToString()))
                    result += options.CustomRomajiMapping[c.ToString()];
                else if (IsHiragana(c.ToString()))
                    result += Constants.RomajiHiraganaDictionary.First(item => item.Value == c.ToString()).Key;
                else if (IsKatakana(c.ToString()) && options != null && options.UpcaseKatakana)
                    result += Constants.RomajiKatakanaDictionary.First(item => item.Value == c.ToString()).Key.ToUpper();
                else if (IsKatakana(c.ToString()))
                    result += Constants.RomajiKatakanaDictionary.First(item => item.Value == c.ToString()).Key;
                else
                    result += c;
            }
            return result;
        }
    }
}