using System;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] token = Console.ReadLine()
                .Split();
            string fullName = $"{token[0]} {token[1]}";
            string adress = token[2];
            string town = token[3];

            if (token.Length-1>3)
            {
                town += $" {token[4]}";
            }
            Threeuple<string, string, string> personNameAdress = new Threeuple<string, string, string>(fullName, adress, town);


            string[] token1 = Console.ReadLine()
                .Split();
            string name = token1[0];
            int beerLitres = int.Parse(token1[1]);
            bool drunk = token1[2] == "drunk";
            Threeuple<string, int, bool> drunkOrNot = new Threeuple<string, int, bool>(name, beerLitres, drunk);


            string[] token2 = Console.ReadLine()
                .Split();
            string accOwner = token2[0];
            double balance = double.Parse(token2[1]);
            string bankName = token2[2];
            Threeuple<string, double, string> bankInfo = new Threeuple<string, double, string>(accOwner, balance,bankName);

            Console.WriteLine(personNameAdress.ToString());
            Console.WriteLine(drunkOrNot.ToString());
            Console.WriteLine(bankInfo.ToString());





        }
    }
}
