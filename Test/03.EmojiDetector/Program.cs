using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string patterntOne = @"\d";
            string patternTwo = @"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string input = Console.ReadLine();
            var tresholdMatches = Regex.Matches(input, patterntOne);
            var emoji = Regex.Matches(input, patternTwo);
            int emojiCount = emoji.Count;
            int coolTreshOldSum = 1;

            foreach (Match item in tresholdMatches)
            {
                coolTreshOldSum *= int.Parse(item.Value);
            }

            Console.WriteLine($"Cool threshold: {coolTreshOldSum}");
            Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");

            for (int i = 0; i < emoji.Count; i++)
            {
                long emojiCharsSum = emoji[i].Groups["emoji"].ToString().ToCharArray().Select(x => (int)x).ToArray().Sum();
                if (emojiCharsSum > coolTreshOldSum)
                {
                    Console.WriteLine(emoji[i]);
                }
            }


        }
    }
}
