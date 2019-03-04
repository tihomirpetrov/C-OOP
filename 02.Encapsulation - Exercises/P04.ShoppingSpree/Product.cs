namespace P04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        private string name;
        private double cost;
        

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public double Cost
        {
            get
            {
                return this.cost;
            }
            private set
            {
                this.cost = value;
            }
        }
    }
}