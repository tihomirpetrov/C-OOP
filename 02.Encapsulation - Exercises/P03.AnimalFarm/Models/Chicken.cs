namespace AnimalFarm.Models
{
    using System;
    public class Chicken
    {
        public const int MinAge = 0;
        public const int MaxAge = 15;

        protected string name;
        internal int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            internal set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                this.name = value;
            }
        }


        public int Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                this.ValidateAge(value);
                this.age = value;
            }
        }

        private void ValidateAge(int value)
        {
            if (value < 0 || value > 15)
            {
                throw new ArgumentException($"Age should be between 0 and 15.");
            }
        }

        public double GetProductPerDay()
        {
            return this.CalculateProductPerDay();
        }

        public double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
