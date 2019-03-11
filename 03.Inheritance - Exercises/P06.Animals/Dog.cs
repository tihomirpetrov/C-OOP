namespace P06.Animals
{
    using System;
    public class Dog : Animal
    {
        private string name;
        private int age;
        private string gender;
        public Dog(string name, int age, string gender) : base(name, age, gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }        
    }
}