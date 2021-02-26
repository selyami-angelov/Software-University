using System;
using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("input.txt"))
            using (var writer = new StreamWriter("output.txt"))
            {
                string curLine = reader.ReadLine();
                int linesCounter = 1;

                while (!reader.EndOfStream)
                {
                    writer.WriteLine($"{linesCounter}. {curLine}");
                    linesCounter++;
                    curLine = reader.ReadLine();
                }
                writer.WriteLine($"{linesCounter}. {curLine}");
            }
        }
    }
}
