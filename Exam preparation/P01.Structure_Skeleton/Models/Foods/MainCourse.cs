namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    public class MainCourse : Food, IFood
    {
        public const int servingSizeInitial = 500;

        public MainCourse(string name, decimal price)
            : base(name, servingSizeInitial, price)
        {
        }
    }
}