namespace MilitaryElite
{
    using System.Collections.Generic;
    using System.Text;
    using MilitaryElite.Enums;
    using MilitaryElite.Interfaces;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
        : base (id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; set ; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine("  " + $"{repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}