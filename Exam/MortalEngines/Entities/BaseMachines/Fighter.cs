using System.Text;

namespace MortalEngines.Entities.BaseMachines
{
    public class Fighter : BaseMachine
    {
        private const double initialHealthPoints = 200;
        //private const bool AggressiveMode = true;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else if (!AggressiveMode)
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            if (AggressiveMode)
            {
                sb.AppendLine($" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine($" *Aggressive: OFF");
            }

            return sb.ToString();
        }
    }
}