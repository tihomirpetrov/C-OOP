namespace P01.Vehicles
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] carInformation = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInformation[1]);
            double carFuelConsumption = double.Parse(carInformation[2]);

            Car car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInformation = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInformation[1]);
            double truckFuelConsumption = double.Parse(truckInformation[2]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Drive")
                {
                    double distance = double.Parse(input[2]);
                    if (input[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (input[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance)); 
                    }
                }
                else if (input[0] == "Refuel")
                {
                    double liters = double.Parse(input[2]);
                    if (input[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else if (input[1] == "Truck")
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}