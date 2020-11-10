using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>(Console.ReadLine().ToCharArray());
            Console.WriteLine(string.Join("", stack));
        }
    }
}
