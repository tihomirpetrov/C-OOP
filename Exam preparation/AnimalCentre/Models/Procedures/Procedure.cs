namespace AnimalCentre.Models.Procedures
{
    using AnimalCentre.Models.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IAnimal> procedureHistory;
        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }
        

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (procedureTime > animal.ProcedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }

            animal.ProcedureTime -= procedureTime;

            procedureHistory.Add(animal);
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");

            foreach (var animal in procedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            string result = sb.ToString().TrimEnd();

            return result;
        }
    }
}
