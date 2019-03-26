namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
    using System;

    public class FightCommand : Command
    {
        public FightCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}