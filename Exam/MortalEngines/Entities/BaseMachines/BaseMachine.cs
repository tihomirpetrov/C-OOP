namespace MortalEngines.Entities.BaseMachines
{
    using System;
    using System.Collections.Generic;
    using MortalEngines.Entities.Contracts;
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.Name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.Name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.Pilot;
            private set
            {
                if (string.IsNullOrEmpty(Pilot.Name))
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.Pilot = value;
            }
        }
        public double HealthPoints { get; private set; }

        public double AttackPoints { get; private set; }

        public double DefensePoints { get; private set; }

        public IList<string> Targets { get; private set; }

    public void Attack(IMachine target)
        {
            throw new System.NotImplementedException();
        }
    }
}