using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("VW", 50, 50, 0.05);
        }

        [Test]
        public void TestCorrectlyGetterModel()
        {
            Assert.AreEqual("VW", car.Model);
        }

        [Test]
        public void TestCorrectlyGetterTankCapacity()
        {
            Assert.AreEqual(50, car.TankCapacity);
        }

        [Test]
        public void TestCorrectlyGetterTank()
        {
            Assert.AreEqual(50, car.FuelAmount);
        }

        [Test]
        public void TestCorrectlyGetterFuelConsumptionPerKm()
        {
            Assert.AreEqual(0.05, car.FuelConsumptionPerKm);
        }

        [Test]
        public void ConstructorShouldSetProperValues()
        {
            string model = "VW";
            double tankCapacity = 50;
            double tank = 50;
            double fuelConsumptionPerKm = 0.05;

            var car = new Car(model, tankCapacity, tank, fuelConsumptionPerKm);

            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(tankCapacity, car.TankCapacity);
            Assert.AreEqual(tank, car.FuelAmount);
            Assert.AreEqual(fuelConsumptionPerKm, car.FuelConsumptionPerKm);

            //test ctor setting proper values
        }

        [Test]
        [TestCase(" ")]
        [TestCase("")]
        public void ModelShouldThrowArgumentExceptionModelCanntBeEmptyOrWhitespace(string model)
        {
            //string model = " ";
            double tankCapacity = 50;
            double tank = 50;
            double fuelConsumptionPerKm = 0.05;

            Assert.That(() => new Car(model, tankCapacity, tank, fuelConsumptionPerKm), Throws.ArgumentException.With.Message.EqualTo($"Model is required"));

            //test model with empty or whitespace
        }

        [Test]
        public void FuelAmountCannotBeMoreThanTankCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", 50, 60, 0.05));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void FuelFuelConsumptionPerKmCannotBeZeroOrLess(double fuelConsumptionPerKm)
        {
            Assert.That(() => new Car("VW", 50, 50, fuelConsumptionPerKm), Throws.ArgumentException.With.Message.EqualTo($"Invalid {nameof(car.FuelConsumptionPerKm)}"));
        }

        [Test]
        [TestCase(1000)]
        [TestCase(0)]
        public void TripConsumptionIsMoreOrLessThanTravelDistance(double distance)
        {
            var fuelConsumptionPerKm = 0.05;
            double tripConsumotion = 20;

            Assert.AreNotEqual(tripConsumotion, distance * fuelConsumptionPerKm);
        }
    }
}