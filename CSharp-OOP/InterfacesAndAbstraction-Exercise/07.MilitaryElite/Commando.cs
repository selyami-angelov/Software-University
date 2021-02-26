using _07.MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Commando :SpecialisedSoldier, ICommando
    {
        private ICollection<Missions> missions;

        public Commando(string id, string firstName, string lastName, decimal salary, string corps, ICollection<Missions> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<Missions> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine($"Missions:");

            foreach (var mission in this.Missions)
            {
                result.AppendLine("  "+mission.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
