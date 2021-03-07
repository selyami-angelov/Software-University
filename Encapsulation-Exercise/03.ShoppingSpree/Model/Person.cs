using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private ICollection<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }
        public ICollection<Product> BagOfProducts
        {
            get
            {
                return this.bagOfProducts;
            }
            private set
            {
                this.bagOfProducts = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.money<product.Price)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                this.bagOfProducts.Add(product);
                this.Money -= product.Price;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (!this.BagOfProducts.Any())
            {
                result.Append($"{this.Name} - Nothing bought ");
            }
            else
            {
                List<string> productsBouth = this.BagOfProducts.Select(x=>x.Name).ToList();
                result.Append($"{this.Name} - {string.Join(", ", productsBouth)}");
            }
            
                return result.ToString().TrimEnd();
        }


    }
}
