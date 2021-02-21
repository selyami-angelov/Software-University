using System;
using System.Linq;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string[] comandsData = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            while (comandsData[0] != "Decode")
            {
                string comand = comandsData[0];

                if (comand == "Move")
                {
                    int lenght = int.Parse(comandsData[1]);
                    string sub = message.Substring(0, lenght);
                    message = message.Remove(0, lenght);
                    message += sub;
                }
                else if (comand == "Insert")
                {
                    int index = int.Parse(comandsData[1]);
                    string value = comandsData[2];
                    message = message.Insert(index, value);
                }
                else if (comand == "ChangeAll")
                {
                    string substring = comandsData[1];
                    string replacement = comandsData[2];

                    message = message.Replace(substring, replacement);
                }

                comandsData = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
