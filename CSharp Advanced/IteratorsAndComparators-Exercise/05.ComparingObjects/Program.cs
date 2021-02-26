using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();

            while (personInfo[0] != "END")
            {
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];
                Person person = new Person(name, age, town);
                persons.Add(person);
                personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int comparePersonIndex = int.Parse(Console.ReadLine());
            Person comparePerson = persons[comparePersonIndex - 1];
            int countOfMatches = 0;

            foreach (var item in persons)
            {
                if (item.CompareTo(comparePerson) == 0)
                {
                    countOfMatches++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {

                Console.WriteLine($"{countOfMatches} {persons.Count - countOfMatches} {persons.Count}");
            }


        }
    }
}
