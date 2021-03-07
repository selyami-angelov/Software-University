using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public class Pet : IBirthable
    {
        private string name;
        private string birthDate;
        public Pet(string name,string  birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }

        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}
