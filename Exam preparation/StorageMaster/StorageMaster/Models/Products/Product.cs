namespace StorageMaster.Models.Products
{
    using StorageMaster.Models.Products.Contracts;
    using System;
    public abstract class Product : IProduct
    {
        private double price;
        private double weight;

        public Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }
        public double Weight { get; set; }

    }
}