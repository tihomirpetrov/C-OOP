namespace MilitaryElite
{
    using System.Collections.Generic;
    using System.Text;
    using MilitaryElite.Interfaces;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var privateSoldier in Privates)
            {
                sb.AppendLine("  " + privateSoldier.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}