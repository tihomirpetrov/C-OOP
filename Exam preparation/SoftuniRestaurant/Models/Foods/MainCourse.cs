namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        private const int InitialServingSize = 500;
        public MainCourse(string name, int servingSize, decimal price)
            : base(name, servingSize, price)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}