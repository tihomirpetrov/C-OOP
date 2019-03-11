namespace P06.Animals
{
    public class Frog : Animal
    {
        private string name;
        private int age;
        private string gender;
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}