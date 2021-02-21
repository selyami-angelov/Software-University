using System;

namespace _01.GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                int value = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(value);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
