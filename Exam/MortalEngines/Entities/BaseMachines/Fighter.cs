namespace MortalEngines.Entities.BaseMachines
{
    using MortalEngines.Entities.Contracts;
    using System.Text;
    public class Fighter : BaseMachine, IFighter
    {

        private const double initialHealthPoints = 200;
        //private const bool AggressiveMode = true;
        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints +50, defensePoints -25, initialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else if (!AggressiveMode)
            {
                this.AggressiveMode = true;
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

            return sb.ToString().TrimEnd();
        }
    }
}