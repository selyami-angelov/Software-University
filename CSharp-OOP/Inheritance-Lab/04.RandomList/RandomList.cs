using System;
using System.Collections.Generic;
using System.Text;

namespace _04.RandomList
{
    class RandomList : List<string>
    {
        Random rand;

        public RandomList()
        {
            rand = new Random();
        }
        public string RandomString()
        {
            int index = rand.Next(0, this.Count - 1);
            string removed = this[index];
            this.RemoveAt(index);
            return removed;
        }
    }
}
