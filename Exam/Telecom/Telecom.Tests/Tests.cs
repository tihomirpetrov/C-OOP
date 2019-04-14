namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Tests
    {
        private Phone phone;
        private Dictionary<string, string> contacts;

        [SetUp]
        public void SetUp()
        {
            phone = new Phone("Nokia", "3310");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Nokia", phone.Make);
            Assert.AreEqual("3310", phone.Model);
        }
        
        [Test]
        public void TestGetPhoneMakeCorrectly()
        {
            Assert.AreEqual("Nokia", phone.Make);
        }
        [Test]
        public void TestGetPhoneModelCorrectly()
        {
            Assert.AreEqual("3310", phone.Model);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestGetPhoneMakeThrowException(string make)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, "3310"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestGetPhoneModelThrowException(string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone("Nokia", model));
        }

        [Test]
        public void TestCountCorrectly()
        {
            phone.AddContact("Ivan", "0888123456");
            phone.AddContact("Pesho", "0989123456");

            Assert.AreEqual(2, phone.Count);
        }

        [Test]
        public void TestAddContactThrowException()
        {
            phone.AddContact("Ivan", "0888123456");
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Ivan", "0989123456"));
        }

        [Test]
        public void TestCallCorrectly()
        {
            phone.AddContact("Ivan", "0888");
            phone.AddContact("Pesho", "0999");
            Assert.AreEqual("Calling Ivan - 0888...", phone.Call("Ivan"));
        }

        [Test]
        public void TestCallThrowException()
        {
            phone.AddContact("Ivan", "0888");
            phone.AddContact("Pesho", "0999");
            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }
    }
}