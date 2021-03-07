using Stealer;
using System;
using System.Reflection;

namespace _01.Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);

            
        }
    }
}
