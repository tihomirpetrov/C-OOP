namespace P03.BarrackWars_ANewFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type classType = Type.GetType("P03.BarrackWars_ANewFactory.Models.Units." + unitType);
            return (IUnit)Activator.CreateInstance(classType);
        }
    }
}