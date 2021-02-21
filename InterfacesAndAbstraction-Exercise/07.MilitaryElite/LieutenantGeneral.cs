using _07.MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class LieutenantGeneral :Private, ILieutenantGeneral
    {
        private ICollection<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, ICollection<Private> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public ICollection<Private> Privates
        {
            get
            {
                return this.privates;
            }
            private set
            {
                this.privates = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine("Privates:");

            foreach (var curPrivate in this.Privates)
            {
                result.AppendLine("  "+curPrivate.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
