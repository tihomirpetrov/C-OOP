namespace P02.CarsSalesman
{
    using System;
    
    public class Startup
    {
        static void Main(string[] args)
        {
            CarSalesman carSalesman = new CarSalesman();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddEngine(parameters);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                carSalesman.AddCar(parameters);
            }

            foreach (var car in carSalesman.GetCars())
            {
                Console.WriteLine(car);
            }
        }
    }
}