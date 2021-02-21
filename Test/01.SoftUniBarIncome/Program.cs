using System;
using System.Text.RegularExpressions;

namespace _01.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z]{1}[a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.\d]*(?<price>[-+]?[0-9]+\.?[0-9]*)\$";
            string input = Console.ReadLine();
            double totalIncome = 0;

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    double totalPrice = int.Parse(match.Groups["count"].Value) * double.Parse(match.Groups["price"].Value);
                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {totalPrice:f2}");
                    totalIncome += totalPrice;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {Math.Round(totalIncome, 2):f2}");
        }
    }
}
