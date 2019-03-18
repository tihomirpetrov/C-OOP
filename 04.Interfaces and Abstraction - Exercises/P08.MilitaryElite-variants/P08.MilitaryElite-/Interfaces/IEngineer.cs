namespace P08.MilitaryElite_.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyList<IRepair> Repairs { get; }
    }
}
