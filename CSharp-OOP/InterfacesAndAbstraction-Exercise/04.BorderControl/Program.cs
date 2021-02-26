using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            int peopleNum = int.Parse(Console.ReadLine());
            List<IBuyer> people = new List<IBuyer>();

            for (int i = 0; i < peopleNum; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);

                if (peopleInfo.Length <= 3)
                {
                    string group = peopleInfo[2];
                    Rebel rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
                else
                {
                    string id = peopleInfo[2];
                    string birthDate = peopleInfo[3];
                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    people.Add(citizen);
                }
            }

            string buyingPerson = Console.ReadLine();

            while (buyingPerson != "End")
            {
                var person = people.FirstOrDefault(x => x.Name == buyingPerson);
                if (person != null)
                {
                    person.BuyFood();

                }

                buyingPerson = Console.ReadLine();
            }

            int total = people.Sum(x => x.Food);
            Console.WriteLine(total);
        }
    }
}
