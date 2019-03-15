namespace P06.BirthdayCelebrations
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.Birthdate = birthdate;
        }

        public string Birthdate
        {
            get; private set;
        }
    }
}