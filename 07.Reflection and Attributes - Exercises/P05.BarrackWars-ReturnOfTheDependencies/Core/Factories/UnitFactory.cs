namespace P05.BarrackWars_ReturnOfTheDependencies.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type classType = Type.GetType("P05.BarrackWars_ReturnOfTheDependencies.Models.Units." + unitType);
            return (IUnit)Activator.CreateInstance(classType);
        }
    }
}