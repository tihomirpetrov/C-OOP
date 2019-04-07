namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    public class Dessert : Food, IFood
    {
        public Dessert(string name, int servingSize, decimal price)
            : base(name, servingSize, price)
        {
            this.ServingSize = 200;
        }
    }
}