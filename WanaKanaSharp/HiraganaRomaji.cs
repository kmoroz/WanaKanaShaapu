﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanaKanaSharp
{
    public class HiraganaRomaji
    {
        public static readonly Dictionary<string, string> HiraganaRomajiDictionary = new Dictionary<string, string>()
        {
            {"a", "あ"},
            {"i", "い"},
            {"u", "う"},
            {"e", "え"},
            {"o", "お"},

            {"ka", "か"},
            {"ki", "き"},
            {"ku", "く"},
            {"ke", "け"},
            {"ko", "こ"},

            {"sa", "さ"},
            {"si", "し"},
            {"su", "す"},
            {"se", "せ"},
            {"so", "そ"},

            {"ta", "た"},
            {"ti", "ち"},
            {"tu", "つ"},
            {"tsu", "つ"},
            {"te", "て"},
            {"to", "と"},

            {"na", "な"},
            {"ni", "に"},
            {"nu", "ぬ"},
            {"ne", "ね"},
            {"no", "の"},
            {"n", "ん"},

            {"ha", "は"},
            {"hi", "ひ"},
            {"hu", "ふ"},
            {"he", "へ"},
            {"ho", "ほ"},

            {"ma", "ま"},
            {"mi", "み"},
            {"mu", "む"},
            {"me", "め"},
            {"mo", "も"},

            {"ya", "や"},
            {"yu", "ゆ"},
            {"yo", "よ"},

            {"ra", "ら"},
            {"ri", "り"},
            {"ru", "る"},
            {"re", "れ"},
            {"ro", "ろ"},

            {"wa", "わ"},
            {"wo", "を"},

            {"ga", "が"},
            {"gi", "ぎ"},
            {"gu", "ぐ"},
            {"ge", "げ"},
            {"go", "ご"},


            {"za", "ざ"},
            {"zi", "じ"},
            {"ji", "じ"},
            {"zu", "ず"},
            {"ze", "ぜ"},
            {"zo", "ぞ"},

            {"da", "だ"},
            {"di", "ぢ"},
            {"du", "づ"},
            {"de", "で"},
            {"do", "ど"},

            {"ba", "ば"},
            {"bi", "び"},
            {"bu", "ぶ"},
            {"be", "べ"},
            {"bo", "ぼ"},

            {"pa", "ぱ"},
            {"pi", "ぴ"},
            {"pu", "ぷ"},
            {"pe", "ぺ"},
            {"po", "ぽ"},

            {"kya", "きゃ"},
            {"kyu", "きゅ"},
            {"kyo", "きょ"},

            {"sya", "しゃ"},
            {"syu", "しゅ"},
            {"syo", "しょ"},

            {"tya", "ちゃ"},
            {"tyu", "ちゅ"},
            {"tyo", "ちょ"},

            {"nya", "にゃ"},
            {"nyu", "にゅ"},
            {"nyo", "にょ"},

            {"hya", "ひゃ"},
            {"hyu", "ひゅ"},
            {"hyo", "ひょ"},

            {"mya", "みゃ"},
            {"myu", "みゅ"},
            {"myo", "みょ"},

            {"rya", "りゃ"},
            {"ryu", "りゅ"},
            {"ryo", "りょ"},

            {"gya", "ぎゃ"},
            {"gyu", "ぎゅ"},
            {"gyo", "ぎょ"},

            {"zya", "じゃ"},
            {"zyu", "じゅ"},
            {"zyo", "じょ"},

            {"dya", "ぢゃ"},
            {"dyu", "ぢゅ"},
            {"dyo", "ぢょ"},

            {"bya", "びゃ"},
            {"byu", "びゅ"},
            {"byo", "びょ"},

            {"pya", "ぴゃ"},
            {"pyu", "ぴゅ"},
            {"pyo", "ぴょ"},

            {"kwa", "くゎ"},
            {"gwa", "ぐゎ"},

/*          {"a", "ぁ"},
            {"i", "ぃ"},
            {"u", "ぅ"},
            {"e", "ぇ"},
            {"o", "ぉ"},
            {"ya", "ゃ"},
            {"yu", "ゅ"},
            {"yo", "ょ"},
            {"wa", "ゎ"},*/

            {"ye", "いぇ"},
            {"wi", "うぃ"},
            {"we", "うぇ"},
/*          {"wo", "うぉ"},*/
            {"kye", "きぇ"},
/*          {"kwa", "くぁ"},*/
            {"kwi", "くぃ"},
            {"kwe", "くぇ"},
            {"kwo", "くぉ"},
/*          {"gwa", "ぐぁ"},*/
            {"gwi", "ぐぃ"},
            {"gwe", "ぐぇ"},
            {"gwo", "ぐぉ"},

            {"she", "しぇ"},
            {"je", "じぇ"},
            {"che", "ちぇ"},
            {"tsa", "つぁ"},
            {"tsi", "つぃ"},
            {"tse", "つぇ"},
            {"tso", "つぉ"},
            {"thi", "てぃ"},
            {"thu", "てゅ"},
            {"dhi", "でぃ"},
            {"dhu", "でゅ"},
            {"two", "とぅ"},
            {"dwu", "どぅ"},
            {"nye", "にぇ"},
            {"hye", "ひぇ"},
            {"fa", "ふぁ"},
            {"fi", "ふぃ"},
            {"fe", "ふぇ"},
            {"fo", "ふぉ"},
            {"fyu" , "ふゅ"},
            {"fyo", "ふょ" }
        };

        public static readonly Dictionary<string, string> KatakanaRomajiDictionary = new Dictionary<string, string>()
        {
            {"a", "ア"},
            {"i", "イ"},
            {"u", "ウ"},
            {"e", "エ"},
            {"o", "オ"},

            {"ka", "カ"},
            {"ki", "キ"},
            {"ku", "ク"},
            {"ke", "ケ"},
            {"ko", "コ"},

            {"sa", "サ"},
            {"si", "シ"},
            {"su", "ス"},
            {"se", "セ"},
            {"so", "ソ"},

            {"ta", "タ"},
            {"ti", "チ"},
            {"tu", "ツ"},
            {"tsu", "ツ"},
            {"te", "テ"},
            {"to", "ト"},

            {"na", "ナ"},
            {"ni", "ニ"},
            {"nu", "ヌ"},
            {"ne", "ネ"},
            {"no", "ノ"},
            {"n", "ン" },

            {"ha", "ハ"},
            {"hi", "ヒ"},
            {"hu", "フ"},
            {"he", "ヘ"},
            {"ho", "ホ"},

            {"ma", "マ"},
            {"mi", "ミ"},
            {"mu", "ム"},
            {"me", "メ"},
            {"mo", "モ"},

            {"ya", "ヤ"},
            {"yu", "ユ"},
            {"yo", "ヨ"},

            {"ra", "ラ"},
            {"ri", "リ"},
            {"ru", "ル"},
            {"re", "レ"},
            {"ro", "ロ"},

            {"wa", "ワ"},
            {"wo", "ヲ"},

            {"ga", "ガ"},
            {"gi", "ギ"},
            {"gu", "グ"},
            {"ge", "ゲ"},
            {"go", "ゴ"},


            {"za", "ザ"},
            {"zi", "ジ"},
            {"ji", "ジ"},
            {"zu", "ズ"},
            {"ze", "ゼ"},
            {"zo", "ゾ"},

            {"da", "ダ"},
            {"di", "ヂ"},
            {"du", "ヅ"},
            {"de", "デ"},
            {"do", "ド"},

            {"ba", "バ"},
            {"bi", "ビ"},
            {"bu", "ブ"},
            {"be", "ベ"},
            {"bo", "ボ"},

            {"pa", "パ"},
            {"pi", "ピ"},
            {"pu", "プ"},
            {"pe", "ペ"},
            {"po", "ポ"},

            {"kya", "キャ"},
            {"kyu", "キュ"},
            {"kyo", "キョ"},

            {"sya", "シャ"},
            {"syu", "シュ"},
            {"syo", "ショ"},

            {"tya", "チャ"},
            {"tyu", "チュ"},
            {"tyo", "チョ"},

            {"nya", "ニャ"},
            {"nyu", "ニュ"},
            {"nyo", "ニョ"},

            {"hya", "ヒャ"},
            {"hyu", "ヒュ"},
            {"hyo", "ヒョ"},

            {"mya", "ミャ"},
            {"myu", "ミュ"},
            {"myo", "ミョ"},

            {"rya", "リャ"},
            {"ryu", "リュ"},
            {"ryo", "リョ"},

            {"gya", "ギャ"},
            {"gyu", "ギュ"},
            {"gyo", "ギョ"},

            {"zya", "ジャ"},
            {"zyu", "ジュ"},
            {"zyo", "ジョ"},

            {"dya", "ヂャ"},
            {"dyu", "ヂュ"},
            {"dyo", "ヂョ"},

            {"bya", "ビャ"},
            {"byu", "ビュ"},
            {"byo", "ビョ"},

            {"pya", "ピャ"},
            {"pyu", "ピュ"},
            {"pyo", "ピョ"},

            {"kwa", "クヮ"},
            {"gwa", "グヮ"},

/*            {"ァ", "a"},
            {"ィ", "i"},
            {"ゥ", "u"},
            {"ェ", "e"},
            {"ォ", "o"},
            {"ャ", "ya"},
            {"ュ", "yu"},
            {"ョ", "yo"},
            {"ヮ", "wa"},
            {"ヵ", "ka"},
            {"ヶ", "ke"},*/

            {"ye","イェ"}, 
            {"wi","ウィ"}, 
            {"whe","ウェ"}, 
            {"who","ウォ"}, 
            {"vu","ヴ"}, 
            {"va","ヴァ"}, 
            {"vi","ヴィ"}, 
            {"ve","ヴェ"}, 
            {"vo","ヴォ"}, 
            {"vyu","ヴュ"}, 
            {"vyo","ヴョ"}, 
            {"kye","キェ"}, 
            {"qa","クァ"}, 
            {"qi","クィ"}, 
            {"qe","クェ"}, 
            {"qo","クォ"}, 
            {"gua","グァ"}, 
            {"gui", "グィ"}, 
            {"gue", "グェ"}, 
            {"guo", "グォ"}, 

            {"she", "シェ"},
            {"je", "ジェ"},
            {"che", "チェ"},
            {"tsa", "ツァ"},
            {"tsi", "ツィ"},
            {"tse", "ツェ"},
            {"tso", "ツォ"},
            {"thi", "ティ"},
            {"thu", "テュ"},
            {"dhi", "ディ"},
            {"dhu", "デュ"},
            {"two", "トゥ"},
            {"dwu", "ドゥ"},
            {"nye", "ニェ"},
            {"hye", "ヒェ"},
            {"fa", "ファ"},
            {"fi", "フィ"},
            {"fe", "フェ"},
            {"fo", "フォ"},
            {"fyu", "フュ"},
            {"fyo", "フョ"}
        };

        public static readonly Dictionary<string, string> WhitespacePunctuationDictionary = new Dictionary<string, string>()
        {
            {" ", "　"},
            {"!", "！"},
            { "\"", "“”"},
            { "#", "＃"},
            { "$", "＄"},
            { "%", "％"},
            { "&", "＆"},
            { "'", "’"},
            { "(", "（"},
            { ")", "）"},
            { "=", "＝"},
            { "~", "～"},
            { "|", "｜"},
            { "@", "＠"},
            { "`", "‘"},
            { "+", "＋"},
            { "*", "＊"},
            { ";", "；"},
            { ":", "："},
            { "<", "＜"},
            { ">", "＞"},
            { ",", "、"},
            { ".", "。"},
            { "/", "／"},
            { "?", "？"},
            { "_", "＿"},
            { "･", "・"},
            { "‘", "「"},
            { "’", "」"},
            { "{", "｛"},
            { "}", "｝"},
            { "^", "＾"}
        };

/*          {" ", "　"},
            {"!", "！"},
            { "\"", "“”"},
            { "#", "＃"},
            { "$", "＄"},
            { "%", "％"},
            { "&", "＆"},
            { "'", "’"},
            { "(", "（"},
            { ")", "）"},
            { "=", "＝"},
            { "~", "～"},
            { "|", "｜"},
            { "@", "＠"},
            { "`", "‘"},
            { "+", "＋"},
            { "*", "＊"},
            { ";", "；"},
            { ":", "："},
            { "<", "＜"},
            { ">", "＞"},
            { ",", "、"},
            { ".", "。"},
            { "/", "／"},
            { "?", "？"},
            { "_", "＿"},
            { "･", "・"},
            { "\'", "「」"},
            { "{", "｛"},
            { "}", "｝"},
            { "^", "＾"},*/

        public static readonly Dictionary<string, string> ObsoleteHiraganaDictionary = new Dictionary<string, string>()
        {
            {"wi", "ゐ"},
            {"we", "ゑ" }
        };

        public static readonly Dictionary<string, string> ObsoleteKatakanaDictionary = new Dictionary<string, string>()
        {
            {"wi", "ヰ"},
            {"we", "ヱ" }
        };
    }
}