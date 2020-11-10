using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> openBracketsIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openBracketsIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int openBracketIndex = openBracketsIndexes.Pop();
                    Console.WriteLine(expression.Substring(openBracketIndex, i - openBracketIndex + 1));
                }
            }
        }
    }
}
