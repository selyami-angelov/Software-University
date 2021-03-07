using _07.MilitaryElite.Contracts;

using System.Text;

namespace _07.MilitaryElite
{
    public class Spy :Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNum)
            : base(id, firstName, lastName)
        {
            this.CodeNum = codeNum;
        }

        public int CodeNum { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            result.AppendLine($"Code Number: {this.CodeNum}");

            return result.ToString().TrimEnd();
        }
    }
}
