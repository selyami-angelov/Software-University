using _07.MilitaryElite.Contracts;

using System.Text;

namespace _07.MilitaryElite
{
    public class Repairs : IRepairs
    {
        private string partName;
        private int hoursWork;

        public Repairs(string partName,int hoursWork)
        {
            this.PartName = partName;
            this.HoursWork = hoursWork;
        }
        public string PartName { get; private set; }
        public int HoursWork { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Part Name: {this.PartName} Hours Worked: {this.HoursWork}");


            return result.ToString().TrimEnd();
        }
    }
}
