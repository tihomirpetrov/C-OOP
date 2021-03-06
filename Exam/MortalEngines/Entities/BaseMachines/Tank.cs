﻿namespace MortalEngines.Entities.BaseMachines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;
    public class Tank : BaseMachine, ITank
    {
        private const double initialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints -40, defensePoints +30, initialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else if (!DefenseMode)
            {
                this.DefenseMode = true;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            if (DefenseMode)
            {
                sb.AppendLine($" *Defense: ON");
            }
            else
            {
                sb.AppendLine($" *Defense: OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}