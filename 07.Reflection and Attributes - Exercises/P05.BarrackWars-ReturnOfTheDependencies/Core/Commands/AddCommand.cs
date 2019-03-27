namespace P05.BarrackWars_ReturnOfTheDependencies.Core.Commands
{
    using P05.BarrackWars_ReturnOfTheDependencies.Contracts;
    using P05.BarrackWars_ReturnOfTheDependencies.Attributes;

    public class AddCommand : Command
    {
        //[Inject]
        //private IRepository repository;

        //[Inject]
        //private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}