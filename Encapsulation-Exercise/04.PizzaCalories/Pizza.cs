using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private ICollection<Toppings> toppings;
        private int toppingNum;
        private double totalCal;


        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.Toppings = new LinkedList<Toppings>();
            this.totalCal = dough.Calories;
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length>15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }
        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }
        public ICollection<Toppings> Toppings
        {
            get
            {
                return this.toppings;
            }
            private set
            {
                this.toppings = value;
            }
        }
        public int ToppingNum
        {
            get
            {
                return this.toppings.ToList().Count();
            }
        }

        public double TotalCal
        {
            get
            {
                return this.totalCal;
            }
        }

        //private void TotalCalCalc()
        //{
        //    totalCal = toppings.Select(x=>x.Calories).Sum()+ dough.Calories;
        //}

        public void AddTopping(Toppings toping)
        {
            if (this.ToppingNum > 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(toping);
            this.totalCal += toping.Calories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCal:f2} Calories.";
        }
    }
}
