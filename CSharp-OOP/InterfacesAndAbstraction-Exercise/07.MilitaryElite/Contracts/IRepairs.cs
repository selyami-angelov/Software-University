using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Contracts
{
    public interface IRepairs
    {
        public string PartName { get; }
        public int HoursWork { get; }
    }
}
