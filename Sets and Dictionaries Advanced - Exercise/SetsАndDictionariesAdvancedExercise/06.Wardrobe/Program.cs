using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesNum = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < linesNum; i++)
            {
                string input = Console.ReadLine();
                string color = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[0];
                string[] clothes = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                    foreach (var item in clothes)
                    {
                        if (!wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color].Add(item, 1);
                        }
                        else
                        {
                            wardrobe[color][item]++;
                        }
                    }
                }
                else
                {
                    foreach (var item in clothes)
                    {
                        if (!wardrobe[color].ContainsKey(item))
                        {
                            wardrobe[color].Add(item, 1);
                        }
                        else
                        {
                            wardrobe[color][item]++;
                        }
                    }
                }
            }

            string[] lfCloth = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == lfCloth[0] && cloth.Key == lfCloth[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
