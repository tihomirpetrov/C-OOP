namespace P07.FoodShortage
{
    public class Citizen : IIdentifiable, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.id = id;
            this.Birthdate = birthdate;
        }

        public string Birthdate
        {
            get; private set;
        }
        public int Food
        {
            get; private set;
        }

        public string Name
        {
            get; private set;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
