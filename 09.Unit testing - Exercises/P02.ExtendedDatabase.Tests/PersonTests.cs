namespace P02.ExtendedDatabase.Tests
{
    using NUnit.Framework;
    using P02.ExtendedDatabase.Models;

    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void ConstructorInitializationWorks()
        {
            // Arrange
            var person = new Person(123, "Test");

            // Assert
            Assert.AreNotEqual(null, person);
            Assert.AreEqual(123, person.Id);
            Assert.AreEqual("Test", person.Username);
        }
    }
}
