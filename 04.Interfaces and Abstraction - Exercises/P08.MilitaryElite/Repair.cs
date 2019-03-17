namespace P08.MilitaryElite
{
    public class Repair
    {
        private string name;

        private int workedHours;

        public Repair(string name, int workedHours)
        {
            this.name = name;
            this.workedHours = workedHours;
        }


        public override string ToString()
        {
            return $"Part Name: {this.name} Hours Worked: {this.workedHours}";
        }
    }
}
