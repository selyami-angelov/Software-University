using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string citiesData = Console.ReadLine();
            Dictionary<string, City> cities = new Dictionary<string, City>();

            while (citiesData != "Sail")
            {
                string city = citiesData.Split("||", StringSplitOptions.RemoveEmptyEntries)[0];
                int population = int.Parse(citiesData.Split("||", StringSplitOptions.RemoveEmptyEntries)[1]);
                int gold = int.Parse(citiesData.Split("||", StringSplitOptions.RemoveEmptyEntries)[2]);

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new City(population, gold));
                }
                else
                {
                    cities[city].Population += population;
                    cities[city].Gold += gold;
                }

                citiesData = Console.ReadLine();
            }

            citiesData = Console.ReadLine();

            while (citiesData != "End")
            {
                string action = citiesData.Split("=>", StringSplitOptions.RemoveEmptyEntries)[0];
                string town = citiesData.Split("=>", StringSplitOptions.RemoveEmptyEntries)[1];

                if (action == "Plunder")
                {
                    int people = int.Parse(citiesData.Split("=>", StringSplitOptions.RemoveEmptyEntries)[2]);
                    int gold = int.Parse(citiesData.Split("=>", StringSplitOptions.RemoveEmptyEntries)[3]);

                    cities[town].Population -= people;
                    cities[town].Gold -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[town].Population <= 0 || cities[town].Gold <= 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(citiesData.Split("=>", StringSplitOptions.RemoveEmptyEntries)[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        citiesData = Console.ReadLine();
                        continue;
                    }

                    cities[town].Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town].Gold} gold.");
                }

                citiesData = Console.ReadLine();
            }

            if (cities.Any())
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                var result = cities.OrderByDescending(x => x.Value.Gold).ThenBy(x => x.Key);

                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
                }
            }

        }

        class City
        {
            public int Population { get; set; }
            public int Gold { get; set; }

            public City(int population, int gold)
            {
                Population = population;
                Gold = gold;
            }
        }


    }
}
