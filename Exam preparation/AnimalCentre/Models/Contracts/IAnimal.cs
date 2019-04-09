namespace AnimalCentre.Models.Contracts
{
    public interface IAnimal
    {
        string Name { get; } //private set ?
        int Happiness { get; set; }

        int Energy { get; set; }

        int ProcedureTime { get; set; }

        string Owner { get; set; }

        bool IsAdopt { get; set; }

        bool IsChipped { get; set; }

        bool IsVaccinated { get; set; }

//•	Name – string
//•	Happiness – int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid happiness")
//•	Energy – int (can’t be less than 0 or more than 100. In these cases throw ArgumentException with message "Invalid energy")
//•	ProcedureTime – int
//•	Owner – string (by default: "Centre")
//•	IsAdopt – bool (by default: false)
//•	IsChipped – bool (by default: false)
//•	IsVaccinated – bool (by default: false)

    }
}
