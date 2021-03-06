﻿namespace P04.BarrackWars_TheCommandsStrikeBack.Core.Commands
{
    using P04.BarrackWars_TheCommandsStrikeBack.Contracts;
   
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        public IRepository Repository
        {
            get
            {
                return this.repository;
            }
            private set
            {
                this.repository = value;
            }
        }
        public IUnitFactory UnitFactory
        {
            get
            {
                return this.unitFactory;
            }
            private set
            {
                this.unitFactory = value;
            }
        }

        protected string[] Data
        {
            get
            {
                return this.data;
            }
            private set
            {
                this.data = value;
            }
        }

        public abstract string Execute();
    }
}