namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
    using P04.BarrackWars_TheCommandsStrikeBack.Attributes;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;

        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}