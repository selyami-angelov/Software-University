using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"!(?<comand>[A-Z][a-z]{2,})!:\[(?<message>[a-zA-Z]{8,})\]";
            int comandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < comandsNum; i++)
            {
                string curMessage = Console.ReadLine();

                if (Regex.IsMatch(curMessage, pattern))
                {
                    var match = Regex.Match(curMessage, pattern);
                    string name = match.Groups["comand"].ToString();
                    string mess = match.Groups["message"].ToString();

                    Console.Write($"{name}: ");
                    foreach (var item in mess)
                    {
                        Console.Write((int)item + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
