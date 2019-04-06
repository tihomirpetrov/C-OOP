using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;

namespace StorageMester.Tests.Structure
{
    public class VehicleTests
    {
        private Type globalvehicle;

        [SetUp]
        public void SetUp()
        {
            this.globalvehicle = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Vehicle");
        }


        [Test]
        public void TestsIfAllVehicleTypesCanBeInstanced()
        {
            var allTypes = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
            };

            foreach (var type in allTypes)
            {
                var currentType = typeof(StartUp)
                    .Assembly
                    .GetTypes()
                    .FirstOrDefault(x => x.Name == type);

                Assert.That(currentType, Is.Not.Null, $"There is no such type as {type}");
            }
        }

        [Test]
        public void TestsIfThePropertiesAreValid()
        {
            //var vehicleType = typeof(StartUp)
            //    .Assembly
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == "Vehicle");

            var vehicleProperties = globalvehicle.GetProperties();

            var allProperties = new Dictionary<string, Type>
            {
                { "Capacity", typeof(int) },
                { "Trunk", typeof(IReadOnlyCollection<Product>) },
                { "IsFull", typeof(bool) },
                { "IsEmpty", typeof(bool) }
            };

            foreach (var property in vehicleProperties)
            {
                var isValid = allProperties.Any(x => x.Key == property.Name
                && property.PropertyType == x.Value);


                Assert.That(isValid, $"Vehicle type should contain {property.Name} property");
            }
        }

        [Test]
        public void TestsIfTrunkFieldExists()
        {
            var trunkField = globalvehicle.GetField("trunk", BindingFlags.Instance
                | BindingFlags.NonPublic);

            Assert.That(trunkField, Is.Not.Null, $"The trunk field does not exist!");
        }

        [Test]
        public void TestsIfVehicleClassIsAbstract()
        {
            Assert.That(globalvehicle.IsAbstract, "The Vehicle class must be abstract!");
        }

        [Test]
        public void TestsIfTheVehicleClassHasAvalidConstructor()
        {
            var currentConstructor = globalvehicle
                .GetConstructors(BindingFlags.Instance | 
                BindingFlags.NonPublic)
                .FirstOrDefault();

            Assert.That(currentConstructor, Is.Not.Null, "Constructor does not exist!");

            var constParameters = currentConstructor.GetParameters().FirstOrDefault();

            Assert.That(constParameters.ParameterType, Is.EqualTo(typeof(int))
                , "The parameter for the constructor should be of type int");
        }

        [Test]
        public void TestsIfAllMethodsExist()
        {
            var methodNames = new[]
            {
                "Unload",
                "LoadProduct"
            };

            var vehicleMethods = globalvehicle.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.Name == "Unload" || x.Name == "LoadProduct");
                
            foreach (var method in vehicleMethods)
            {
                bool methodIsPresent = methodNames.Contains(method.Name);

                Assert.That(methodIsPresent, $"{method.Name} does not exist!");
            }
        }

        [Test]
        public void TestsIfUnloadMethodReturnsProduct()
        {
            var vehicleMethods = globalvehicle.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                 .Where(x => x.Name == "Unload");

            var unload = vehicleMethods.FirstOrDefault(x => x.Name == "Unload");

            bool isCorrect = unload.ReturnType == typeof(Product);

            Assert.That(isCorrect, "Unload method should return Product!");
        }

        [Test]
        public void TestsIfLoadProductisofTypeVoid()
        {
            var vehicleMethods = globalvehicle.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.Name == "LoadProduct");

            var unload = vehicleMethods.FirstOrDefault(x => x.Name == "LoadProduct");

            bool isCorrect = unload.ReturnType == typeof(void);

            Assert.That(isCorrect, "LoadProduct method should be of type void!");
        }


        [Test]
        public void TestsIfTheSubClassesInheritTheVehicleClass()
        {
            var allChildTypes = typeof(StartUp)
                   .Assembly
                   .GetTypes()
                   .Where(x => x.Name == "Semi" ||
                   x.Name == "Truck" || x.Name == "Van");

            foreach (var child in allChildTypes)
            {
                Assert.That(child.BaseType, Is.EqualTo(typeof(Vehicle)), $"{child.Name} does not iherit Vehicle!");
            }
        }

        //AdditionalTestForVan
        [Test]
        public void TestsIfLoadProductThrowsAndExceptionWhenItsFullForVan()
        {
            var vehicleType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Van");

            var productType = typeof(StartUp)
              .Assembly
              .GetTypes()
              .FirstOrDefault(x => x.Name == "HardDrive");

            var vehicleInstance = (Van)Activator.CreateInstance(vehicleType);

            var productInstance = (HardDrive)Activator.CreateInstance(productType, new object[] { 1.5 });

            vehicleInstance.LoadProduct(productInstance);
            vehicleInstance.LoadProduct(productInstance);

            Assert.Throws<InvalidOperationException>(() => vehicleInstance.LoadProduct(productInstance))
                .Message
                .Equals("Vehicle is full!");
        }

        //AdditionalTestForTruck
        [Test]
        public void TestsIfLoadProductLoadsAProductForTruck()
        {
            var vehicleType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Truck");

            var productType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Gpu");

            var vehicleInstance = (Truck)Activator.CreateInstance(vehicleType);
            var productInstance = (Gpu)Activator.CreateInstance(productType, new object[] { 1.5 });

            vehicleInstance.LoadProduct(productInstance);

            bool actualResult = vehicleInstance.IsEmpty;
            bool expectedResult = vehicleInstance.IsEmpty;

            Assert.AreEqual(expectedResult, actualResult, "Truck does not load products properly!");
        }

    }

}
