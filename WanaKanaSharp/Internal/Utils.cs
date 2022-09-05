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
            if (WanaKana.IsJapanese(input))
                return false;

            if (input.Length == 2)
            {
                if (input.First() == input.Last())
                    return true;
            }
            return false;
        }

        internal static string ConvertChoonpu(string input, int i, bool isDestinationRomaji, [Optional] DefaultOptions options)
        {
            char charBeforeChoonpu = input[i - 1];

            if (isDestinationRomaji)
            {
                if (WanaKana.IsKatakana(charBeforeChoonpu.ToString()))
                    return "-";
                else
                {
                    string syllable = Constants.RomajiHiraganaDictionary.First(item => item.Value == charBeforeChoonpu.ToString()).Key;
                    string latinVowel = syllable.Last().ToString();
                    return latinVowel;
                }
            }
            if (WanaKana.IsHiragana(charBeforeChoonpu.ToString()))
            {
                if (options != null && !options.ConvertLongVowelMark)
                    return "ー";
                string syllable = Constants.RomajiHiraganaDictionary.First(item => item.Value == charBeforeChoonpu.ToString()).Key;
                string latinVowel = syllable.Last().ToString();
                string convertedVowel = Constants.RomajiHiraganaDictionary[latinVowel];
                return convertedVowel;
            }
            else if (WanaKana.IsKatakana(charBeforeChoonpu.ToString()))
            {
                if (options != null && options.ConvertLongVowelMark)
                {
                    string syllable = Constants.RomajiKatakanaDictionary.First(item => item.Value == charBeforeChoonpu.ToString()).Key;
                    string latinVowel = syllable.Last().ToString();
                    return latinVowel;
                }  
            }
            return "ー";
        }

        internal static string KatakanaToHiragana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (WanaKana.IsRomaji(c.ToString()))
                    result += c;
                else if (c == Constants.Choonpu)
                    result += ConvertChoonpu(result, i, false, options);
                else
                    result += (char)(c - 0x60);
            }
            return result;
        }

        internal static string RomajiToHiragana(string input, [Optional] DefaultOptions options)
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
                    if (WanaKana.IsJapanese(c.ToString()))
                        result += c;
                    if (char.IsPunctuation(c) || char.IsWhiteSpace(c))
                        result += Constants.WhitespacePunctuationDictionary[c.ToString()];
                    continue;
                }
                syllable = string.Empty;
            }
            return result;
        }

        internal static string RomajiToKatakana(string input, [Optional] DefaultOptions options)
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
                    if (WanaKana.IsJapanese(c.ToString()))
                        result += c;
                    if (char.IsPunctuation(c) || char.IsWhiteSpace(c))
                        result += Constants.WhitespacePunctuationDictionary[c.ToString()];
                    continue;
                }
                syllable = string.Empty;
            }
            return result;
        }

        internal static string RomajiToKana(string input, [Optional] DefaultOptions options)
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

        internal static string HiraganaToKatakana(string input, DefaultOptions options)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (WanaKana.IsRomaji(c.ToString()))
                    result += c;
                else if (c == Constants.Choonpu)
                    result += ConvertChoonpu(result, i, false, options);
                else
                    result += (char)(c + 0x60);
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
            else if (Char.IsPunctuation(c) || Constants.WhitespacePunctuationDictionary.ContainsKey(letter))
                return "englishPunctuation";
            else
                return "other";
        }

        internal static string ConvertPunctuation(string input)
        {
            string result = string.Empty;

            if (WanaKana.IsJapanese(input))
            {
                foreach (char c in input)
                {
                    result += Constants.WhitespacePunctuationDictionary.First(item => item.Value == c.ToString()).Key;
                }
            }
            else
            {
                foreach (char c in input)
                {
                    result += Constants.WhitespacePunctuationDictionary[c.ToString()];
                }
            }
            return result;
        }
    }
}