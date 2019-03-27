namespace P05.BarrackWars_ReturnOfTheDependencies.Core.Commands
{
    using System;
    using P05.BarrackWars_ReturnOfTheDependencies.Contracts;
    using P05.BarrackWars_ReturnOfTheDependencies.Attributes;

    public class RetireCommand : Command
    {
        //[Inject]
        //private IRepository repository;

        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.Repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
