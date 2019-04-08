namespace SoftUniRestaurant.Models.Drinks
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    public class Alcohol : Drink
    {
        public const decimal AlcoholPrice = 3.50M;

        public Alcohol(string name, int servingSize, string brand) 
            : base(name, servingSize, AlcoholPrice, brand)
        {
        }
    }
}
