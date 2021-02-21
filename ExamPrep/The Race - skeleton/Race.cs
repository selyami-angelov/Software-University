using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count(); } }

        public void Add(Racer racer)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(racer);
            }
        }

        public  bool Remove(string name)
        {
            Racer curRac = data.Find(x => x.Name == name);

            return data.Remove(curRac);
        }

        public Racer GetOldestRacer()
        {
            return this.data.OrderBy(x => x.Age).Last();
        }

        public Racer GetRacer(string name)
        {
            return this.data.Find(x => x.Name == name);
        }
        public Racer GetFastestRacer()
        {
            return this.data.OrderBy(x => x.Car.Speed).Last();
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Racers participating at {this.Name}:");

            foreach (var item in this.data)
            {
                result.AppendLine(item.ToString());
            }

            return result.ToString().TrimEnd();

        }
    }
}
