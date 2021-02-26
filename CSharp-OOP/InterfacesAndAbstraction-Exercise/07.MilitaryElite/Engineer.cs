using _07.MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<Repairs> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, ICollection<Repairs> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<Repairs> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                result.AppendLine("  "+repair.ToString());
            }


            return result.ToString().TrimEnd();
        }
    }
}
