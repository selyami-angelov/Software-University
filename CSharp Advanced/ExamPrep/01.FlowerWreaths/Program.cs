using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> lilies = new Queue<int>
                (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> roses = new Stack<int>
                (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int saved = 0;
            int wrath = 0;

            while (lilies.Count()!=0 && roses.Count()!=0)
            {
                int sum = lilies.Dequeue() + roses.Pop();

                if (sum == 15)
                {
                    wrath++;
                }
                else if (sum>15)
                {
                    if (sum%2==0)
                    {
                        saved += 14;
                    }
                    else
                    {
                        wrath++;
                    }
                }
                else if (sum<15)
                {
                    saved += sum;
                }
            }

            wrath += saved / 15;

            if (wrath>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wrath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wrath} wreaths more!");
            }


        }
    }
}
