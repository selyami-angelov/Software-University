using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int personCount = int.Parse(Console.ReadLine());
            List<Person> members = new List<Person>();

            for (int i = 0; i < personCount; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                Person curPerson = new Person(name, age);
                members.Add(curPerson);
            }

            List<Person> sortedMembers = members.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var item in sortedMembers)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }

        }
    }
}
