using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string locations = Console.ReadLine();
            string pattern = @"([=]|[/])(?<location>[A-Z][a-zA-Z]{2,})\1";
            var matches = Regex.Matches(locations, pattern);
            var validLocations = matches.Select(x => x.Groups["location"]).ToList();
            int travelPoints = 0;

            foreach (var item in validLocations)
            {
                travelPoints += item.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ",validLocations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
