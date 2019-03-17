namespace P08.MilitaryElite
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Commando : Private, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
            this.Missions = new HashSet<Mission>();
        }
        public string Corps { get; private set; }

        public HashSet<Mission> Missions { get; private set; }

        public void CompleteMission(Mission mission)
        {
            if (this.Missions.Any(x => x.Name == mission.Name))
            {
                Mission currentMission = this.Missions.FirstOrDefault(x => x.Name == mission.Name);
                if (currentMission.State == "inProgress" && mission.State == "finished" )
                {
                    currentMission.CorectState(mission.state);
                }
            }
            else
            {
                this.Missions.Add(mission);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            foreach (var item in this.Missions)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
