namespace MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}