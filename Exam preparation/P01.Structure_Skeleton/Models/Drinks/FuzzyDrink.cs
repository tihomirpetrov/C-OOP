namespace SoftUniRestaurant.Models.Drinks
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    public class FuzzyDrink : Drink
    {
        public const decimal FuzzyDrinkPrice = 2.50M;

        public FuzzyDrink(string name, int servingSize, string brand)
             : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
