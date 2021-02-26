using System;
using System.Text;
using System.Linq;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            StringBuilder pass = new StringBuilder();
            string comandsData = Console.ReadLine();

            while (comandsData != "Done")
            {
                string comand = comandsData.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

                if (comand == "TakeOdd")
                {
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0 && i != 0)
                        {
                            pass.Append(password[i]);
                        }
                    }
                    password = pass.ToString();
                    Console.WriteLine(password);
                }
                else if (comand == "Cut")
                {
                    int index = int.Parse(comandsData.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    int lenght = int.Parse(comandsData.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                    string sub = password.Substring(index, lenght);

                    password = password.Remove(password.IndexOf(sub),sub.Length);

                    Console.WriteLine(password);
                }
                else if (comand == "Substitute")
                {
                    string substringOne = comandsData.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                    string substringTwo = comandsData.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2];

                    if (password.IndexOf(substringOne) != -1)
                    {
                        password = password.Replace(substringOne, substringTwo);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }


                comandsData = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
