namespace P05.BarrackWars_ReturnOfTheDependencies.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
