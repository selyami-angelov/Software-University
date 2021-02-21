using System;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string[] comandsData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (comandsData[0] != "Complete")
            {
                string comand = comandsData[0];

                if (comand == "Make")
                {
                    string make = comandsData[1];
                    if (make == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (make == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);
                    }
                }
                else if (comand == "GetDomain")
                {
                    int count = int.Parse(comandsData[1]);
                    string sub = email.Substring(email.Length - count);
                    Console.WriteLine(sub);
                }
                else if (comand == "GetUsername")
                {

                    if (email.Contains('@'))
                    {
                        string[] user = email.Split('@', StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(user[0]);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (comand == "Replace")
                {
                    char replacement = char.Parse(comandsData[1]);
                    email = email.Replace(replacement, '-');
                    Console.WriteLine(email);
                }
                else if (comand == "Encrypt")
                {
                    foreach (var item in email)
                    {
                        Console.Write((int)item+" ");
                    }
                }
                comandsData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
