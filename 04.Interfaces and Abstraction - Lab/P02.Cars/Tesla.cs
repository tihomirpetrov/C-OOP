namespace Cars
{
    using System;
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery) : base()
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }

        public string Model { get; private set; }
        public string Color { get; private set; }
        public int Battery { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries\n{Start().ToString()}\n{Stop().ToString()}";
        }
    }
}