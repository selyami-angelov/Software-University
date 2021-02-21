using _03.GenericScale;

using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> scale = new EqualityScale<string>("assd","asd");
            Console.WriteLine(scale.AreEqual());

        }
    }
}
