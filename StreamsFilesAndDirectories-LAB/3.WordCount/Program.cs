using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] splitBy = new char[] { '-', ' ', '.', ',', '!', '?', '…' };
            string[] words = File.ReadAllText("words.txt").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] text = File.ReadAllText("text.txt").Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var item in words)
            {
                if (!wordsCount.ContainsKey(item))
                {
                    wordsCount.Add(item, 0);
                }
            }

            foreach (var item in text)
            {
                if (wordsCount.ContainsKey(item.ToLower()))
                {
                    wordsCount[item.ToLower()]++;
                }
            }

            var sortedWords = wordsCount.OrderByDescending(x => x.Value);
            using (var writer = new StreamWriter("output.txt"))
            {
                foreach (var item in sortedWords)
                {
                    writer.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }
    }
}
