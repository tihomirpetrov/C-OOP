namespace SoftUniRestaurant.Models.Drinks
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    public class Juice : Drink, IDrink
    {
        public const decimal JuicePrice = 1.80M;

        public Juice(string name, int servingSize, string brand)
             : base(name, servingSize, JuicePrice, brand)
        {
        }
    }
}