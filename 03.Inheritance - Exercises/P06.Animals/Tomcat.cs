namespace P06.Animals
{
    public class Tomcat : Cat
    {
        private string name;
        private int age;
        public Tomcat(string name, int age, string gender = "Male") : base(name, age, gender)
        {
            this.name = name;
            this.age = age;
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}