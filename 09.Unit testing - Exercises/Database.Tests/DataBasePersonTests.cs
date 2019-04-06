using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DataBase.Tests
{
    public class DataBasePersonTests
    {

        [Test]
        public void TestsIfAddPersonMethodWorksCorrectly()
        {
            var db = new DataBaseClass(new List<Person>());
            var person = new Person("Gosho", 1);
            db.AddPerson(person);

            bool actualResult = db.People[0] == null;
            bool expectedResult = db.People[0] == null;

            Assert.AreEqual(expectedResult, actualResult, "AddPerson method does not add a person correctly");
        }

        [Test]
        public void TestsIfAddMethodThrowsExceptionOfAndExistingPersonName()
        {
            var db = new DataBaseClass(new List<Person>());
            var person = new Person("Gosho", 1);
            db.AddPerson(person);

            Assert.Throws<InvalidOperationException>(() => db.AddPerson(person))
                .Message
                .Equals("A person with that name is already registered!");
        }

        [Test]
        public void TestsIfAddMethodThrowsExceptionOfAndExistingPersonId()
        {
            var db = new DataBaseClass(new List<Person>());
            var person = new Person("Gosho", 1);
            db.AddPerson(person);

            Assert.Throws<InvalidOperationException>(() => db.AddPerson(person))
                .Message
                .Equals("A person with that Id is already registered!");
        }

        [Test]
        [TestCase("pEpI")]
        [TestCase("PEPI")]
        public void TestsIfFindByUserNameThrowsExceptionOfNonExistentPerson(string userName)
        {
            var db = new DataBaseClass(new List<Person>());
            db.AddPerson(new Person("Pepi", 11));

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(userName))
                .Message
                .Equals($"Person with name {userName} does not exist in the database!");
        }

        [Test]
        public void TestsIfFindByUserNameThrowsExceptionOfUserNameThatIsNull()
        {
            var db = new DataBaseClass(new List<Person>());
            string userName = null;

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(userName))
                .Message
                .Equals($"Invalid username!");
        }
        [Test]
        public void TestsIfFindByIdThrowsExceptionOfUserNameWithNonExistingId()
        {
            var db = new DataBaseClass(new List<Person>());
            long id = 11;

            Assert.Throws<InvalidOperationException>(() => db.FindById(id))
                .Message
                .Equals($"Person with Id {id} does not exist in the database!");
        }

        [Test]
        public void TestsIfFindByIdThrowsExceptionOfUserNameWithNegativeId()
        {
            var db = new DataBaseClass(new List<Person>());
            var person = new Person("Kyrti", -10);
            db.AddPerson(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-10))
                .Message
                .Equals("Id should be a possitive number!");
        }
    }
}
