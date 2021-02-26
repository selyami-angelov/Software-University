using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([@]|[#]{1})(?<firstword>[a-zA-z]{3,})\1\1(?<secondword>[a-zA-z]{3,})\1";
            List<MirrorWordss> mirrorWords = new List<MirrorWordss>();

            var matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["firstword"].Value;
                string secondWord = match.Groups["secondword"].Value;
                var arr = secondWord.ToCharArray();
                Array.Reverse(arr);
                string reversedWord = new string(arr);

                if (firstWord == reversedWord)
                {
                    MirrorWordss word = new MirrorWordss(firstWord, secondWord);
                    mirrorWords.Add(word);
                }
            }

            if (!mirrorWords.Any())
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                List<string> result = new List<string>();
                Console.WriteLine("The mirror words are:");

                foreach (var item in mirrorWords)
                {
                    result.Add($"{item.FirstWord} <=> {item.SecondWord}");
                }

                Console.WriteLine(string.Join(", ", result));
            }


        }
    }

}
class MirrorWordss
{
    public string FirstWord { get; set; }
    public string SecondWord { get; set; }
    public MirrorWordss(string firstWord, string secondWord)
    {
        FirstWord = firstWord;
        SecondWord = secondWord;
    }
}
