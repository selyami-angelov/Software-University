
using _07.MilitaryElite.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<ISoldier> soldiers = new List<ISoldier>();

            while (input[0] != "End")
            {
                string type = input[0];
                string id = input[1];
                string firstName = input[2];
                string lastName = input[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(input[4]);
                    Private curPrivate = new Private(id, firstName, lastName, salary);
                    soldiers.Add(curPrivate);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(input[4]);
                    List<Private> privates = new List<Private>();

                    for (int i = 5; i < input.Length; i++)
                    {
                        ISoldier findPrivate = soldiers.FirstOrDefault(x => x.Id == input[i]);

                        if (findPrivate != null)
                        {
                            privates.Add((Private)findPrivate);
                        }
                    }

                    LieutenantGeneral lg = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                    soldiers.Add(lg);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(input[4]);
                    string corps = input[5];

                    if (corps != "Marines" && corps != "Airforces")
                    {
                        input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); 
                        continue;
                    }

                    List<Repairs> repairs = new List<Repairs>();

                    for (int i = 6; i < input.Length; i+=2)
                    {
                        string repairPart = input[i];
                        int hours = int.Parse(input[i + 1]);
                        Repairs repair = new Repairs(repairPart, hours);
                        repairs.Add(repair);

                    }
                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    soldiers.Add(engineer);

                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(input[4]);
                    string corps = input[5];

                    if (corps != "Marines" && corps != "Airforces")
                    {
                        input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); 
                        continue;
                    }

                    List<Missions> missions = new List<Missions>();

                    for (int i = 6; i < input.Length; i += 2)
                    {
                        string missName = input[i];
                        string missState = input[i+1];

                        if (missState != "inProgress" && missState != "Finished")
                        {
                            continue;
                        }
                        Missions mission = new Missions(missName,missState);
                        missions.Add(mission);
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                    soldiers.Add(commando);
                }
                else if (type == "Spy")
                {
                    int codeNum = int.Parse(input[4]);
                    Spy spy = new Spy(id, firstName, lastName, codeNum);
                    soldiers.Add(spy);
                }

                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); 

            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }

        }
    }
}
