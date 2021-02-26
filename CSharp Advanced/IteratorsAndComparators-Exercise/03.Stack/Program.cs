using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string comands = Console.ReadLine();
            Stack<string> stack = new Stack<string>();

            while (comands != "END")
            {
                string comand = comands.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];

                if (comand == "Pop")
                {
                    stack.Pop();
                }
                else if(comand == "Push")
                {
                    char[] splitBy = " ,".ToCharArray();
                    List<string> items = comands.Split(splitBy, StringSplitOptions.RemoveEmptyEntries).ToList();
                    items.RemoveAt(0);
                    stack.Push(items.ToArray());
                }

                comands = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
