namespace MortalEngines.Entities.BaseMachines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MortalEngines.Entities.Contracts;
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        //private double healthPoints;
        //private double attackPoints;
        //private double defensePoints;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.pilot = null;
            this.Targets = new List<string>();
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
            get => this.pilot;
            set
            {
                if (this.pilot == null) //value
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public IList<string> Targets { get; set; }

        public void Attack(IMachine target)
        {
            if (target == null)
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
            sb.Append(" *Targets: ");
            if (Targets.Count == 0)
            {
                sb.AppendLine("None");
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