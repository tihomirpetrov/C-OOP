﻿namespace P01.RawData
{
    using System.Collections.Generic;
    public class CarCatalog
    {
        private List<Car> cars;

        public CarCatalog()
        {
            this.cars = new List<Car>();
        }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tires = new Tire[4];

            int tireIndex = 0;
            for (int j = 5; j <= 12; j += 2)
            {
                double tirePressure = double.Parse(parameters[j]);
                int tireAge = int.Parse(parameters[j + 1]);

                Tire tire = new Tire(tirePressure, tireAge);
                tires[tireIndex] = tire;

                tireIndex++;
            }

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);
        }
        public List<Car> GetCars()
        {
            return this.cars;
        }
    }
}