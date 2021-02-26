using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Car car)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            return this.data.Remove(this.data.Find(x => x.Manufacturer == manufacturer && x.Model == model));
        }

        public Car GetLatestCar()
        {
            if (this.Count == 0)
            {
                return null;
            }
            return this.data.OrderBy(x => x.Year).Last();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return this.data.Find(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in this.data)
            {
                result.AppendLine(car.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
