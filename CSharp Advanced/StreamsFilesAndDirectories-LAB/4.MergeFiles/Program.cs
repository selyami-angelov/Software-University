using System;
using System.IO;

namespace _4.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var readerOne = new StreamReader("FileOne.txt"))
            using (var readerTwo = new StreamReader("FileTwo.txt"))
            {
                File.WriteAllText("Output.txt", string.Empty);
                while (!(readerOne.EndOfStream && readerTwo.EndOfStream))
                {
                    using(var writer = new StreamWriter("Output.txt",append: true))
                    {
                        writer.WriteLine(readerOne.ReadLine());
                        writer.WriteLine(readerTwo.ReadLine());
                    }
                }
            }
        }
    }
}
