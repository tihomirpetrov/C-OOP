namespace MortalEngines.Entities.BaseMachines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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
            set
            {
                if (string.IsNullOrEmpty(Pilot.Name))
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.Pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (string.IsNullOrEmpty(Targets.ToString()))
            {
                throw new NullReferenceException("Target cannot be null");
            }
            target.HealthPoints -= this.AttackPoints - target.DefensePoints;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            if (Targets.Count == 0)
            {
                sb.AppendLine($" *Targets: None");
            }
            else
            {
                foreach (var target in this.Targets)
                {
                    sb.Append(string.Join(",", target));
                }
            }

            return sb.ToString();
        }
    }
}