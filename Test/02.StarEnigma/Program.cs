using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int massagesNum = int.Parse(Console.ReadLine());
            string firstPpattern = @"[s,t,a,r,S,T,A,R]";
            string secondPattern = @".*@(?<planet>[A-Z][a-z]*)[^@\-,!,:,>]*:(?<population>\d+)[^@\-,!,:,>]*!(?<atack>[A,D])![^@\-,!,:,>]*->(?<soldiers>\d+).*";
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < massagesNum; i++)
            {
                string massage = Console.ReadLine();
                int lettersCount = Regex.Matches(massage, firstPpattern).Count;
                var encrypt = massage.ToCharArray();
                if (lettersCount > 0)
                {
                    encrypt = encrypt.Select(x => (char)(x - lettersCount)).ToArray();
                }

                string encryptString = new string(encrypt);
                var matches = Regex.Match(encryptString, secondPattern);
                if (matches.Success)
                {
                    if (matches.Groups["atack"].Value == "A")
                    {
                        attackedPlanets.Add(matches.Groups["planet"].Value);
                    }
                    else
                    {
                        destroyedPlanets.Add(matches.Groups["planet"].Value);
                    }
                }
                else
                {
                    continue;
                }
            }
            attackedPlanets.Sort();
            destroyedPlanets.Sort();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var item in attackedPlanets)
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var item in destroyedPlanets)
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
