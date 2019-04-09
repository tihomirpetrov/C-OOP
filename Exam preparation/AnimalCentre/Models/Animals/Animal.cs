namespace AnimalCentre.Models.Animals
{
    using AnimalCentre.Models.Contracts;
    using System;

    public abstract class Animal : IAnimal
    {
        private int energy;
        private int happiness;
        private const string defaultOwner = "Centre";

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = defaultOwner;
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; }
        public int Happiness
        {
            get
            {
                return happiness;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }
        //•	Happiness – int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid happiness")

        public int Energy
        {
            get
            {
                return energy;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }
        //•	Energy – int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid energy")


        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsAdopt { get; set; }
        public bool IsChipped { get; set; }
        public bool IsVaccinated { get; set; }
    }
}
