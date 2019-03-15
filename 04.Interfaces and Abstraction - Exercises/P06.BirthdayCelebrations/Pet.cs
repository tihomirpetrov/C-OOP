namespace P06.BirthdayCelebrations
{
    public class Pet : IIdentifiable
    {
        private string name;
        private string birthdate;
        
        public Pet(string name, string birthdate)
        {
            this.name = name;
            this.Birthdate = birthdate;
        }

        public string Birthdate
        {
            get; private set;
        }
    }
}