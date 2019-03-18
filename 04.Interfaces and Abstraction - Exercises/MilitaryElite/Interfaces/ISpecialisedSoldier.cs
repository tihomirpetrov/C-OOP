namespace MilitaryElite.Interfaces
{
    using Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}