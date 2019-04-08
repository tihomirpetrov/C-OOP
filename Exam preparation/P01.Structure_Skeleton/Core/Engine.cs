namespace SoftUniRestaurant.Core
{
    using System;
    public class Engine
    {
        private RestaurantController restaurantController;

        public Engine()
        {
            this.restaurantController = new RestaurantController();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "END")
                {
                    break;
                }

                try
                {
                    switch (input[0])
                    {
                        case "AddFood": Console.Write(this.restaurantController.AddFood(input[1], input[2], decimal.Parse(input[3]))); break;
                        case "AddDrink": Console.Write(this.restaurantController.AddDrink(input[1], input[2], int.Parse(input[3]), input[4])); break;
                        case "AddTable": Console.Write(this.restaurantController.AddTable(input[1], int.Parse(input[2]), int.Parse(input[3]))); break;
                        case "ReserveTable": Console.Write(this.restaurantController.ReserveTable(int.Parse(input[1]))); break;
                        case "OrderFood": Console.Write(this.restaurantController.OrderFood(int.Parse(input[1]), input[2])); break;
                        case "OrderDrink": Console.Write(this.restaurantController.OrderDrink(int.Parse(input[1]), input[2], input[3])); break;
                        case "LeaveTable": Console.Write(this.restaurantController.LeaveTable(int.Parse(input[1]))); break;
                        case "GetFreeTablesInfo": Console.Write(this.restaurantController.GetFreeTablesInfo()); break;
                        case "GetOccupiedTablesInfo": Console.Write(this.restaurantController.GetOccupiedTablesInfo()); break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(this.restaurantController.GetSummary());
        }
    }
}