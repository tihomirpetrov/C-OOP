using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;

namespace StorageMester.BusinessLogic.Tests
{
    public class BusinessLogicTests
    {

        private Type globalStorageMaster;
        private Type globalVanVehicle;

        [SetUp]
        public void SetUp()
        {
            this.globalStorageMaster = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "StorageMaster");
            this.globalVanVehicle = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == "Van");
        }


        [Test]
        public void TestsIfStorageMasterConstructorIsImplementedCorrectly()
        {
            var constructor = globalStorageMaster
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault();

            Assert.That(constructor, Is.Not.Null, $"Constructor does not exist!");
        }

        [Test]
        public void TestsIfAddProductMethodIsInstancedAndReturnTheCorrectType()
        {
            var method = globalStorageMaster
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(x => x.Name == "AddProduct");

            Assert.That(method, Is.Not.Null, $"AddProduct method does not exist!");

            bool corretnReturnType = method.ReturnType == typeof(String);

            Assert.That(corretnReturnType, $"AddProduct should return string!");
        }

        [Test]
        public void TestsIfAddProductMethodAddsAProductCorrectly()
        {
            var method = globalStorageMaster
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(x => x.Name == "AddProduct");

            var instance = Activator.CreateInstance(globalStorageMaster);

            var actualResult = method.Invoke(instance, new object[] { "Ram", 12.5 });
            var expectedResult = $"Added Ram to pool";

            Assert.AreEqual(expectedResult, actualResult, $"Method does not add a product correctly");
        }

        [Test]
        public void TestsIfRegisterStorageWorksCorrectly()
        {
            var method = globalStorageMaster
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .FirstOrDefault(x => x.Name == "RegisterStorage");

            Assert.That(method, Is.Not.Null, "RegisterStorage method does not exist!");

            var parameters = method.GetParameters();

            var correctTypes = new Dictionary<string, Type>()
            {
                { "type", typeof(string)},
                { "name", typeof(string)}
            };

            foreach (var param in parameters)
            {
                var isValid = correctTypes.Any(x => x.Key == param.Name
                && param.ParameterType == x.Value);

                Assert.That(isValid, $"{param.Name} does not exist!");
            }

            var instance = Activator.CreateInstance(globalStorageMaster);

            var actualResult = method.Invoke(instance, new object[] { "Warehouse", "My" });
            var expectedResult = "Registered My";

            Assert.AreEqual(expectedResult, actualResult, "Method does not register correctly!");
        }

        [Test]
        public void TestsIfSelectVehicleWorksCorrectly()
        {
            var method = globalStorageMaster
           .GetMethods(BindingFlags.Instance | BindingFlags.Public)
           .FirstOrDefault(x => x.Name == "SelectVehicle");

            Assert.That(method, Is.Not.Null, "SelectVehicle method does not exist!");

            var parameters = method.GetParameters();

            var correctTypes = new Dictionary<string, Type>()
            {
                { "storageName", typeof(string)},
                { "garageSlot", typeof(int)}
            };

            foreach (var param in parameters)
            {
                var isValid = correctTypes.Any(x => x.Key == param.Name
                && param.ParameterType == x.Value);

                Assert.That(isValid, $"{param.Name} does not exist!");
            }

            var registerStorageMethod = globalStorageMaster.GetMethods()
                 .FirstOrDefault(x => x.Name == "RegisterStorage");

            var instance = (StorageMaster.Core.StorageMaster)Activator.CreateInstance(globalStorageMaster);

            string storageType = "Warehouse";
            string name = "Pesho";

            registerStorageMethod.Invoke(instance, new object[] { storageType, name });

            var selectVehicleMethod = globalStorageMaster.GetMethods()
                   .FirstOrDefault(x => x.Name == "SelectVehicle");

            var actualResult = instance.SelectVehicle(name, 1);
            var expectedResult = $"Selected Semi";

            Assert.AreEqual(expectedResult, actualResult, "The method should have selected Semi");

        }

        [Test]
        public void TestsIfLoadVehicleMethodWorksCorrectly()
        {
            var method = globalStorageMaster
           .GetMethods(BindingFlags.Instance | BindingFlags.Public)
           .FirstOrDefault(x => x.Name == "LoadVehicle");

            Assert.That(method, Is.Not.Null, "LoadVehicle method does not exist!");

            var parameter = method.GetParameters();

            var correctTypes = new KeyValuePair<string, Type>("productNames", typeof(IEnumerable<string>));


            bool valid = parameter[0].Name.Equals(correctTypes.Key)
                && parameter[0].ParameterType.Equals(correctTypes.Value);

            Assert.That(valid, $"{parameter[0].Name} does not exist!");
        }

        [Test]
        public void TestsIfLoadVehicleMethodLoadsCorrectlyAndReturnsTheCorrectString()
        {
            var method = globalStorageMaster
          .GetMethods(BindingFlags.Instance | BindingFlags.Public)
          .FirstOrDefault(x => x.Name == "LoadVehicle");

            var instance = Activator.CreateInstance(globalStorageMaster);

            var currVehicleField = globalStorageMaster.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "currentVehicle");

            currVehicleField.SetValue(instance, new Van());

            IEnumerable<string> products = new string[] { "Ram" };

            var addProduct = globalStorageMaster.GetMethods().FirstOrDefault(x => x.Name == "AddProduct");
            addProduct.Invoke(instance, new object[] { "Ram", 1 });

            var actual = method.Invoke(instance, new object[] { products });
            var expected = "Loaded 1/1 products into Van";

            Assert.AreEqual(expected, actual, "LoadVehicle does not load the products correctly!");
        }

        [Test]
        public void TestsIfSendVehicleToWorksCorrectly()
        {
            var instance = Activator.CreateInstance(globalStorageMaster);

            var registerStorage = globalStorageMaster.GetMethods().FirstOrDefault(x => x.Name == "RegisterStorage");

            registerStorage.Invoke(instance, new object[] { "DistributionCenter", "Stamat" });
            registerStorage.Invoke(instance, new object[] { "AutomatedWarehouse", "Jijo" });

            var sendVehicleTo = globalStorageMaster.GetMethods().FirstOrDefault(x => x.Name == "SendVehicleTo");

            var actual = sendVehicleTo.Invoke(instance, new object[] { "Stamat", 0, "Jijo" });
            var expected = $"Sent Van to Jijo (slot 1)";

            Assert.AreEqual(expected, actual, "Expected to send a van to Jijo at slot 1");
        }


        [Test]
        public void TestsIfUnloadVehicleWorkCorrectly()
        {
            var instance = Activator.CreateInstance(globalStorageMaster);
            var registerStorage = globalStorageMaster.GetMethods().FirstOrDefault(x => x.Name == "RegisterStorage");

            registerStorage.Invoke(instance, new object[] { "Warehouse", "Pesho" });

            var unloadVehicle = globalStorageMaster.GetMethods()
                .FirstOrDefault(x => x.Name == "UnloadVehicle");

            var actual = unloadVehicle.Invoke(instance, new object[] { "Pesho", 1 });
            var expected = "Unloaded 0/0 products at Pesho";

            Assert.AreEqual(expected, actual, "Method does not unload products properly!");
        }
    }
}
