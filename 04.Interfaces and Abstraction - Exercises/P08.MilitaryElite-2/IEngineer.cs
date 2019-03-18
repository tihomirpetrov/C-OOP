using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite_2
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
