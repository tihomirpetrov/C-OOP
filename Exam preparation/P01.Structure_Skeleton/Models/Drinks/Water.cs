namespace SoftUniRestaurant.Models.Drinks
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    public class Water : Drink, IDrink
    {
        public const decimal WaterPrice = 1.50M;

        public Water(string name, int servingSize, string brand)
             : base(name, servingSize, WaterPrice, brand)
        {
        }
    }
}