using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(" ").ToList();
            string comand = elements[0];
            elements.RemoveAt(0);
            var list = new ListyIterator<string>(elements.ToArray());


            while (comand != "END")
            {
                if (comand == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (comand == "Print")
                {
                    Console.WriteLine(list.Print()); 
                }
                else if (comand == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
                else if (comand == "PrintAll")
                {
                    list.PrintAll();
                }

                comand = Console.ReadLine();
            }
        }
    }
}
