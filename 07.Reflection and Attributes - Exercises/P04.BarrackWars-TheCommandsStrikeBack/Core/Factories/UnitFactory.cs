namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type classType = Type.GetType("P04.BarrackWars_TheCommandsStrikeBack.Models.Units." + unitType);
            return (IUnit)Activator.CreateInstance(classType);
        }
    }
}