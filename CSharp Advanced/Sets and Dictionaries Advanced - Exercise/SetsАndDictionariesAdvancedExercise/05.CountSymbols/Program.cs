using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            char[] symbols = text.ToCharArray();
            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            for (int i = 0; i < symbols.Length; i++)
            {
                if (charsCount.ContainsKey(symbols[i]))
                {
                    charsCount[symbols[i]]++;
                }
                else
                {
                    charsCount.Add(symbols[i], 1);
                }
            }

            var sortedChars = charsCount.OrderBy(x => x.Key);

            foreach (var item in sortedChars)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
