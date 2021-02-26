using System;
using System.IO;

namespace _1.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var writer = new StreamWriter("Output.txt"))
            using (var reader = new StreamReader("Input.txt"))
            {
                int linesCounter = 0;
                string readLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    if (linesCounter % 2 != 0)
                    {
                        writer.WriteLine(readLine);
                    }

                    linesCounter++;
                    readLine = reader.ReadLine();

                }

            }
        }
    }
}
