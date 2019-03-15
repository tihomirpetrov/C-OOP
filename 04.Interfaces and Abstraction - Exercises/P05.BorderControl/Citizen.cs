namespace P05.BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, long id)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
        }

       
        public long Id
        {
            get; private set;
        }
    }
}