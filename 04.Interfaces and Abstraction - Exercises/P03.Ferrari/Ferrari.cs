namespace Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver) : base()
        {
            this.Driver = driver;
        }

        public string Driver { get; set; }

        public string UseBreaks()
        {
            return "Brakes!";
        }

        public string PushTheGasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"488-Spider/{UseBreaks().ToString()}/{PushTheGasPedal().ToString()}/{this.Driver}";
        }
    }
}