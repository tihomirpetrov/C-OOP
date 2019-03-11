namespace P06.Animals
{
    public class Kitten : Cat
    {
        private string name;
        private int age;
        public Kitten(string name, int age, string gender = "Female") : base(name, age, gender)
        {
            this.name = name;
            this.age = age;
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}