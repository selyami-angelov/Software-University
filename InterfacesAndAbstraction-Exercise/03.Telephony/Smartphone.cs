using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string num)
        {
            Console.WriteLine($"Calling... {num}");
        }
    }
}
