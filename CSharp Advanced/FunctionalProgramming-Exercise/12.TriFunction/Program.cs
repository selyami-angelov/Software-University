using System;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> charSum = (x, y) =>
              {
                  int sum = 0;
                  foreach (var charr in x)
                  {
                      sum += charr;
                  }

                  return sum >= y;
              };

            int lenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(FirstNameFind(charSum, names, lenght));
        }

        public static string FirstNameFind(Func<string, int, bool> charSum, string[] names, int lenght)
        {
            foreach (var name in names)
            {
                if (charSum(name, lenght))
                {
                    return name;
                }
            }
            return null;
        }
    }
}
