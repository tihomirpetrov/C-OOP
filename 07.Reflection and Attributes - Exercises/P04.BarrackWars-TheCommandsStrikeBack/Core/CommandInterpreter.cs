namespace P04.BarrackWars_TheCommandsStrikeBack.Core
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            throw new NotImplementedException();
        }
    }
}