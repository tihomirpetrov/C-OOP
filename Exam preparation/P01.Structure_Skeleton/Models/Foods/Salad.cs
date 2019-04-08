namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    public class Salad : Food
    {
        public const int servingSizeInitial = 300;

        public Salad(string name, decimal price)
            : base(name, servingSizeInitial, price)
        {
        }
    }
}