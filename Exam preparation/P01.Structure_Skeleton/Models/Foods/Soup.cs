namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    public class Soup : Food, IFood
    {
        public const int servingSizeInitial = 245;

        public Soup(string name, decimal price)
            : base(name, servingSizeInitial, price)
        {
        }
    }
}
