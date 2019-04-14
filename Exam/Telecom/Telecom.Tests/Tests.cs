namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorShouldSetProperValues()
        {
            string make = "Nokia";
            string model = "3310";
            Phone phone = new Phone(make, model);


            Assert.AreEqual(make, phone.Make);
            Assert.AreEqual(model, phone.Model);

            //test ctor setting proper values
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakeShouldThrowExceptionCanntBeEmptyOrNull(string make)
        {
            string model = "3310";

            Assert.That(() => new Phone(make, model), Throws.ArgumentException.With.Message.EqualTo($"Invalid {nameof(Phone.Make)}!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelShouldThrowExceptionCanntBeEmptyOrNull(string model)
        {
            string make = "Nokia";


            Assert.That(() => new Phone(make, model), Throws.ArgumentException.With.Message.EqualTo($"Invalid {nameof(Phone.Model)}!"));
        }


        //[Test]
        //public void ModelShouldThrowInvalidOperationExceptionPersonAlreadyExists()
        //{
        //    string name = "Ivan";
        //    string phone = "123456789";
            
        //    Dictionary<string, string> phonebook = new Dictionary<string, string>();
                       

        //    Phone phone2 = new Phone("nokia", "3310");

        //    phone2.AddContact(name, phone);
        //    phonebook.Add(name, phone);
            

        //    Assert.That(() => phonebook.ContainsKey(name), Throws.InvalidOperationException.With.Message.EqualTo("Person already exists!"));

        //    //test model with empty or whitespace
        //}
    }
}