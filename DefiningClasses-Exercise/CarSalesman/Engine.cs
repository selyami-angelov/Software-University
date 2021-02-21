using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        public Engine()
        {

        }
        public Engine(string model,int power,int displacement,string efficienci)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficienci;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
