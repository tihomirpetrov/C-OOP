namespace P06.Animals
{
    public class Cat : Animal
    {
        private string name;
        private int age;
        private string gender;
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }
}