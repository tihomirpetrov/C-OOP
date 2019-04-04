namespace P02.ExtendedDatabase.Tests
{
    using System;
    using NUnit.Framework;
    using P02.ExtendedDatabase.Interfaces;
    using P02.ExtendedDatabase.Models;
    using P02.ExtendedDatabase.Repository;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void TestInitialization()
        {
            this.database = new Database();
        }

        [Test]
        public void DatabaseInitializationConstructorWithCollectionOfPeople()
        {
            var firstPerson = new Person(123L, "Pesho");
            var secondPerson = new Person(456L, "Ivan");
            var collectionOfPeople = new IPerson[] { firstPerson, secondPerson };

            this.database = new Database(collectionOfPeople);

            Assert.AreEqual();
        }
    }
}