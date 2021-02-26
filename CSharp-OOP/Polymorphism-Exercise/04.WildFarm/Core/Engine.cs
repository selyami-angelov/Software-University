using _04.WildFarm.Core.Contracts;
using _04.WildFarm.Factories;
using _04.WildFarm.Models;

using System;
using System.Collections.Generic;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();

            int i = 0;
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Animal curAnimal = null;
            Food curFood = null;

            while (input[0] != "End")
            {

                if (i == 0 || i % 2 == 0)
                {
                    curAnimal = ProcesseAnimal(input);
                }
                else
                {
                    curFood = ProcesseFood(input);
                    curAnimal.ImHungry();
                    try
                    {
                        curAnimal.Feed(curFood);
                    }
                    catch (Exception ioe)
                    {

                        Console.WriteLine(ioe.Message);
                    }
                    
                    animals.Add(curAnimal);
                }

                i++;
                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            animals.ForEach(x => Console.WriteLine(x.ToString()));

        }

        public Animal ProcesseAnimal(string[] parms)
        {
            return AnimalFactori.CreateAnimal(parms);
        }
        public Food ProcesseFood(string[] parms)
        {
            return FoodFactori.CreateFood(parms);
        }
    }
}
