using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;
            // Bread   25
            // Cake    50
            // Pastry  75
            // Fruit Pie   100

            while (liquids.Count>0 && ingredients.Count>0)
            {
                int liquid = liquids.Dequeue();
                int ingr = ingredients.Pop();
                int sum = liquid + ingr;


                if (sum == 25)
                {
                    bread++;
                }
                else if (sum == 50)
                {
                    cake++;
                }
                else if (sum == 75)
                {
                    pastry++;
                }
                else if (sum == 100)
                {
                    fruitPie++;
                }
                else
                {
                    ingr += 3;
                    ingredients.Push(ingr);
                }
            }

            if (bread >=1 && cake >= 1 && pastry >= 1 && fruitPie >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count!=0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Count != 0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");



        }
    }
}
