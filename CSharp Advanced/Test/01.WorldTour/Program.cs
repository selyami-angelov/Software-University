using System;

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string allStops = Console.ReadLine();
            string[] comandsData = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (comandsData[0] != "Travel")
            {
                string comand = comandsData[0];

                if (comand == "Add Stop")
                {
                    int index = int.Parse(comandsData[1]);
                    string stop = comandsData[2];

                    if (index < allStops.Length && index >= 0)
                    {
                        allStops = allStops.Insert(index, stop);
                    }
                }
                else if (comand == "Remove Stop")
                {
                    int startIndex = int.Parse(comandsData[1]);
                    int endIndex = int.Parse(comandsData[2]);

                    if (startIndex < allStops.Length && startIndex >= 0 && endIndex < allStops.Length && endIndex >= 0)
                    {
                        allStops = allStops.Remove(startIndex, (endIndex - startIndex) + 1);
                    }
                }
                else if (comand == "Switch")
                {
                    string oldString = comandsData[1];
                    string newString = comandsData[2];

                    if (allStops.Contains(oldString))
                    {
                        allStops = allStops.Replace(oldString, newString);
                    }
                }

                Console.WriteLine(allStops);
                comandsData = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {allStops}");
        }
    }
}
