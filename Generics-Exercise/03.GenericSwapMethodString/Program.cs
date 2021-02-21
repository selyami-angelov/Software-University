using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int elemNum = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();

            for (int i = 0; i < elemNum; i++)
            {
                double elem = double.Parse(Console.ReadLine());
                list.Add(elem);
            }

            double compareElem = double.Parse(Console.ReadLine());
            GenericList<double> gList = new GenericList<double>(list);
            Console.WriteLine(gList.Compare(list, compareElem));
        }
    }
}
