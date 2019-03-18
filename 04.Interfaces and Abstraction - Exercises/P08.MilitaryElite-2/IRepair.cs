using System;
using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite_2
{
    public interface IRepair
    {
        string Part { get; }

        int Hours { get; }
    }
}
