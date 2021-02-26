using _07.MilitaryElite.Contracts;
namespace _07.MilitaryElite
{

    public class Missions : IMission
    {
        public Missions(string name, string state)
        {
            this.Name = name;
            this.State = state;
        }
        public string Name { get; private set; }
        public string State { get; private set; }


        public override string ToString()
        {


            return $"Code Name: {this.Name} State: {this.State}";
        }

        private void CompleteMission()
        {

        }
    }
}
