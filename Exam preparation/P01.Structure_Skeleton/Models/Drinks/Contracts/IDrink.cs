namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    public interface IDrink : IFood
    {
        string Brand { get; }
    }
}