using System;
using System.Text;
using System.Linq;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string[] comandData = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            while (comandData[0] != "Reveal")
            {
                string comand = comandData[0];

                if (comand == "InsertSpace")
                {
                    int index = int.Parse(comandData[1]);
                    message = message.Insert(index, " ");
                }
                else if (comand == "Reverse")
                {
                    string sub = comandData[1];
                    if (message.Contains(sub))
                    {
                        int indexOfSub = message.IndexOf(sub);
                        message = message.Remove(indexOfSub, sub.Length);
                        var reverSub = sub.ToCharArray();
                        Array.Reverse(reverSub);
                        message += new string(reverSub);
                    }
                    else
                    {
                        Console.WriteLine("error");
                        comandData = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                }
                else if (comand == "ChangeAll")
                {
                    string sub = comandData[1];
                    string replacement = comandData[2];

                    message = message.Replace(sub, replacement);
                }

                Console.WriteLine(message);

                comandData = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
