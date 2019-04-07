namespace SoftUniRestaurant
{
    using SoftUniRestaurant.Models.Foods;
    using System;
    public class StartUp
    {
        public static void Main()
        {
            Dessert dessert = new Dessert("cake", 300, 5);

            try
            {
                Console.WriteLine(dessert);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
