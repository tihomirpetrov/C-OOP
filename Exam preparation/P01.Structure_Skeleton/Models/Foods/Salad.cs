namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    public class Salad : Food, IFood
    {
        public Salad(string name, int servingSize, decimal price) 
            : base(name, servingSize, price)
        {
            this.ServingSize = 300;
        }
    }
}