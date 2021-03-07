using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Contracts
{
    public interface IEngineer
    {
        public ICollection<Repairs> Repairs { get; }
    }
}
