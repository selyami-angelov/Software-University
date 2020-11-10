using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse());

            while (stack.Count != 1)
            {
                int operandOne = int.Parse(stack.Pop());
                char operatorr = char.Parse(stack.Pop());
                int operandTwo = int.Parse(stack.Pop());
                int result = 0;

                if (operatorr == '+')
                {
                    result = operandOne + operandTwo;
                }
                else if (operatorr == '-')
                {
                    result = operandOne - operandTwo;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
