using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite_2
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
