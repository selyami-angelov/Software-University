using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Rebel : IBuyer
    {
        private const int BUY_FOOD = 5;
        private const int START_FOOD = 0;
        private int food;

        public Rebel(string name, int age , string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = START_FOOD;

        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Group { get; private set; }
        public int Food
        {
            get
            {
                return this.food;
            }
            private set
            {
                this.food = value;
            }
        }

        public void BuyFood()
        {
            this.Food += BUY_FOOD;
        }
    }
}
