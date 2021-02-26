using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class Threeuple<Tfirst, Tsecond,Tthird>
    {
        public Tfirst FirstItem { get; set; }
        public Tsecond SecondItem { get; set; }
        public Tthird ThirdItem { get; set; }

        public Threeuple(Tfirst first, Tsecond second,Tthird third)
        {
            this.FirstItem = first;
            this.SecondItem = second;
            this.ThirdItem = third;
            
        }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
        }
    }
}
