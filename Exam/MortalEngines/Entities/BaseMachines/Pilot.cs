namespace MortalEngines.Entities.BaseMachines
{
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;
        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }
        
        public void AddMachine(IMachine machine)
        {
            if (string.IsNullOrEmpty(machine.GetType().Name))
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in machines)
            {
                sb.AppendLine($"- {machine.Name}");
                sb.AppendLine($" *Type: {machine.GetType().Name}");
                sb.AppendLine($" *Health: {machine.HealthPoints}");
                sb.AppendLine($" *Attack: {machine.AttackPoints}");
                sb.AppendLine($" *Defense: {machine.DefensePoints}");
                sb.AppendLine($" *Targets: {machine.Targets}");
            }

            return sb.ToString();
        }
    }
}