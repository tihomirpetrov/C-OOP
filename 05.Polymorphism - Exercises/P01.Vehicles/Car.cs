namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + airConditionConsumption)
        {
        }
        public override void Refuel(double amount)
        {
            base.Refuel(amount);
        }
    }
}
