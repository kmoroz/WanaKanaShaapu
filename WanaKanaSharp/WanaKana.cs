﻿using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Linq;

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

        public static bool IsSokuon(string input)
        {
            if (input.Length == 2)
            {
                if (input.First() == input.Last())
                    return true;
            }
            return false;
        }

        public static string HandleChoonpuConversion(string input, int i, [Optional] DefaultOptions options)
        {
            char charBeforeChoonpu = input[i - 1];
            string syllable = string.Empty;
            string latinVowel = string.Empty;
            if (IsHiragana(charBeforeChoonpu.ToString()))
            {
                syllable = HiraganaRomaji.HiraganaRomajiDictionary.First(item => item.Value == charBeforeChoonpu.ToString()).Key;
                latinVowel = syllable.Last().ToString();
                return latinVowel;
            }
            else
            {
                if (options != null && !options.ConvertLongVowelMark)
                    return "ー";
                syllable = HiraganaRomaji.KatakanaRomajiDictionary.First(item => item.Value == charBeforeChoonpu.ToString()).Key;
                latinVowel = syllable.Last().ToString();
                string convertedVowel = HiraganaRomaji.HiraganaRomajiDictionary[latinVowel];
                return convertedVowel;
            }
        }

        public static string ToHiragana(string input, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            string syllable = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (IsKatakana(c.ToString()) && c != Constants.Choonpu)
                    result += (char)(c - 0x60);
                else if (c == Constants.Choonpu)
                    result += HandleChoonpuConversion(input, i, options);
                else if (IsRomaji(c.ToString()) || IsRomaji(c.ToString()) && options != null && !options.PassRomaji)
                {
                    syllable += c;
                    if (options != null && options.PassRomaji)
                        result += c;
                    else if (options != null && options.CustomKanaMapping != null && options.CustomKanaMapping.ContainsKey(syllable))
                    {
                        result += options.CustomKanaMapping[syllable];
                        syllable = string.Empty;
                    }
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
                    else if (options != null && options.CustomKanaMapping != null && options.CustomKanaMapping.ContainsKey(syllable))
                        result += options.CustomKanaMapping[syllable];
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
            else if (Char.IsPunctuation(c))
                return "englishPunctuation";
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

        public static string ToRomaji(string kana, [Optional] DefaultOptions options)
        {
            string result = string.Empty;
            for (int i = 0; i < kana.Length; i++)
            {
                char c = kana[i];
                if (c == Constants.Choonpu && IsHiragana(kana[i - 1].ToString()))
                    result += HandleChoonpuConversion(kana, i);
                else if (Char.IsWhiteSpace(c) && IsJapanese(c.ToString()) || Char.IsPunctuation(c) || c == Constants.Choonpu)
                    result += HiraganaRomaji.WhitespacePunctuationDictionary.First(item => item.Value == c.ToString()).Key;
                else if (options != null && options.CustomRomajiMapping != null && options.CustomRomajiMapping.ContainsKey(c.ToString()))
                    result += options.CustomRomajiMapping[c.ToString()];
                else if (IsHiragana(c.ToString()))
                    result += HiraganaRomaji.HiraganaRomajiDictionary.First(item => item.Value == c.ToString()).Key;
                else if (IsKatakana(c.ToString()) && options != null && options.UpcaseKatakana)
                    result += HiraganaRomaji.KatakanaRomajiDictionary.First(item => item.Value == c.ToString()).Key.ToUpper();
                else if (IsKatakana(c.ToString()))
                    result += HiraganaRomaji.KatakanaRomajiDictionary.First(item => item.Value == c.ToString()).Key;
                else
                    result += c;
            }
            return result;
        }
    }
}