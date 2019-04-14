namespace MortalEngines.Entities.BaseMachines
{
    using System.Text;
    public class Tank : BaseMachine
    {
        private const double initialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else if (!DefenseMode)
            {
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

            return sb.ToString();
        }
    }
}