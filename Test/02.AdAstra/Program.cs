using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([\|]|[#])(?<product>[a-zA-Z\s]+)\1(?<date>([0-2][0-9]|[3][0-1])\/([0][0-9]|[1][0-2])\/\d{2})\1(?<calories>[0-9]+)\1";
            string text = Console.ReadLine();
            var productMatches = Regex.Matches(text, pattern);
            int caloriesSum = 0;

            foreach (Match item in productMatches)
            {
                caloriesSum += int.Parse(item.Groups["calories"].ToString());
            }

            int daysSurvive = caloriesSum / 2000;

            Console.WriteLine($"You have food to last you for: {daysSurvive} days!");
            foreach (Match item in productMatches)
            {
                Console.WriteLine($"Item: {item.Groups["product"]}, Best before: {item.Groups["date"]}, Nutrition: {item.Groups["calories"]}");
            }


        }
    }
}
