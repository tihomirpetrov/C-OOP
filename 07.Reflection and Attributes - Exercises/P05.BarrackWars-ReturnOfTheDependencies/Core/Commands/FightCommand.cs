namespace P05.BarrackWars_ReturnOfTheDependencies.Core.Commands
{
    using P05.BarrackWars_ReturnOfTheDependencies.Contracts;
    using System;

    public class FightCommand : Command
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}