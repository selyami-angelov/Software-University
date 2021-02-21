using _07.MilitaryElite.Contracts;

namespace _07.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private const string CORPS_TYPE = "Airforces";
        private const string CORPS_TYPE_TWO = "Marines";

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps { get; set; }
    }
}
