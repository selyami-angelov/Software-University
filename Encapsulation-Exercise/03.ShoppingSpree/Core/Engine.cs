using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _03.ShoppingSpree.Core
{
    class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {

            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                var personData = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in personData)
                {
                    string name = item.Split("=")[0];
                    decimal money = decimal.Parse(item.Split("=", StringSplitOptions.RemoveEmptyEntries)[1]);
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
                return;
            }
            try
            {
                var productData = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in productData)
                {
                    string name = item.Split("=")[0];
                    decimal price = decimal.Parse(item.Split("=")[1]);
                    Product product = new Product(name, price);
                    products.Add(product);

                }
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
                return;
            }




            string productsToBuy = Console.ReadLine();

            while (productsToBuy != "END")
            {
                string personName = productsToBuy.Split()[0];
                string buy = productsToBuy.Split()[1];
                Product curProduct = products.FirstOrDefault(x => x.Name == buy);
                Person curPerson = persons.FirstOrDefault(x => x.Name == personName);

                if (curPerson != null && curProduct != null)
                {
                    curPerson.BuyProduct(curProduct);
                }

                productsToBuy = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                
                Console.WriteLine(person);
            }


        }
    }
}
