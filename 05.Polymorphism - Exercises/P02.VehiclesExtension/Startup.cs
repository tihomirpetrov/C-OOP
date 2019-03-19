namespace P02.VehiclesExtension
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            string[] carInformation = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(carInformation[1]);
            double carFuelConsumption = double.Parse(carInformation[2]);
            int carTankCapacity = int.Parse(carInformation[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckInformation = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(truckInformation[1]);
            double truckFuelConsumption = double.Parse(truckInformation[2]);
            int truckTankCapacity = int.Parse(truckInformation[3]);

            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busInformation = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busInformation[1]);
            double busFuelConsumption = double.Parse(busInformation[2]);
            int busTankCapacity = int.Parse(busInformation[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

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
                    else
                    {
                        Console.WriteLine(bus.Drive(distance));
                    }
                }
                else if (input[0] == "Refuel")
                {
                    double liters = double.Parse(input[2]);

                    try
                    {
                        if (input[1] == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else
                        {
                            bus.Refuel(liters);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                   
                }
                else
                {
                    double distance = double.Parse(input[2]);
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}