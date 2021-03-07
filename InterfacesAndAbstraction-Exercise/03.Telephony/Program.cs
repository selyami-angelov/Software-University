using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Smartphone phone = new Smartphone();
            StationaryPhone statPhone = new StationaryPhone();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i].Any(x=> !char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    if (nums[i].Length == 7)
                    {
                        statPhone.Call(nums[i]);
                    }
                    else
                    {
                        phone.Call(nums[i]);
                    }
                }

                

            }

            for (int i = 0; i < urls.Length; i++)
            {
                if (urls[i].Any(x=> char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    phone.Browse(urls[i]);
                }
            }
        }
    }
}
