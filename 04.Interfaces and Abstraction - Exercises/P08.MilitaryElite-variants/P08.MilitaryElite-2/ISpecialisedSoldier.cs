using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite_2
{
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }
}
