namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;
    public abstract class Food : IFood
    {
        public Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }

        public string Name
        {   get
            {
                return this.Name;
            }
            set
            {
                if (string.IsNullOrEmpty(Name) && string.IsNullOrWhiteSpace(Name))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                this.Name = value;
            }
        }

        public int ServingSize
        {
            get
            {
                return this.ServingSize;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }
                this.ServingSize = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.Price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                this.Price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}