namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    using System;
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
    using P04.BarrackWars_TheCommandsStrikeBack.Attributes;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            this.repository.RemoveUnit(unitType);
            return $"{unitType} retired!";
        }
    }
}
