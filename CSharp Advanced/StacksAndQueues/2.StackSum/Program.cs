using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            string comandData = Console.ReadLine();

            while (comandData?.ToLower() != "end")
            {
                string comand = comandData.Split()[0];
                int firstNum = int.Parse(comandData.Split()[1]);

                if (comand?.ToLower() == "remove")
                {
                    if (firstNum < stack.Count)
                    {
                        for (int i = 0; i < firstNum; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else if (comand?.ToLower() == "add")
                {
                    int secondNum = int.Parse(comandData.Split()[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }

                comandData = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");

        }
    }
}
