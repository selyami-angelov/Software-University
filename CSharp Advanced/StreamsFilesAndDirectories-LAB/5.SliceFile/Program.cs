using System;
using System.IO;

namespace _5.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using(var reader = new StreamReader("sliceMe.txt"))
            {
                int newFileSize = (int)Math.Ceiling(reader.BaseStream.Length / 4.0);
                int filesCounter = 1;

                while (!reader.EndOfStream)
                {
                    char[] readChars = new char[newFileSize];
                    reader.Read(readChars);

                    using(var writer = new StreamWriter($"Part-{filesCounter}.txt"))
                    {
                        writer.Write(readChars);
                        filesCounter++;
                    }
                }
            }
        }
    }
}
