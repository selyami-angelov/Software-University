using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {

        public DateModifier(string first,string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }
        public string Second { get; set; }

        public void CalcDiferences()
        {
            DateTime first = DateTime.Parse(First);
            DateTime second = DateTime.Parse(Second);

            Console.WriteLine(Math.Abs((first - second).Days));
        }
    }

}
