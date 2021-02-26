using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Citizen : IIdentifiable,IBirthable,IBuyer
    {
        private const int BUY_FOOD = 10;
        private const int START_FOOD = 0;
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name,int age, string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthdate;
            this.Food = START_FOOD;

        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += BUY_FOOD;
        }
    }
}
