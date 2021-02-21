using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"..\..\..\TestFolder");
            FileInfo[] filesInfo = dir.GetFiles();
            decimal filesLenght = 0;

            foreach (var file in filesInfo)
            {
                filesLenght += file.Length;
            }
            Console.WriteLine(filesLenght);
            File.WriteAllText("Output.txt", filesLenght.ToString());
            
        }
    }
}
