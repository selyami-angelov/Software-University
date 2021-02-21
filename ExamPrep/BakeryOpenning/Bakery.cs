using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee findEmploye = this.data.Find(x => x.Name == name);
            return this.data.Remove(findEmploye);
        }

        public Employee GetOldestEmployee()
        {
            var sortedData = data.OrderBy(x => x.Age);
            return sortedData.Last();
        }

        public Employee GetEmployee(string name)
        {
            return data.Find(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in data)
            {
                result.AppendLine(employee.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
