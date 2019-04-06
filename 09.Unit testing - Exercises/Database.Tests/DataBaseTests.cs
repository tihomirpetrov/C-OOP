using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace DataBase.Tests
{
    public class DataBaseTests
    {
        [Test]
        public void TestsParamConstructorStoringDbCapacityShouldBe16()
        {
            var arr = new int[17];

            Assert.Throws<InvalidOperationException>(() => new DataBaseClass(arr))
                .Message
                .Equals("Size should be maximum 16 elements!");
        }

        [Test]
        public void EmptyConstructorShouldInitializeDbWithExactly16Elements()
        {

            var db = new DataBaseClass();

            var type = typeof(DataBaseClass);

            var field = (int[])type.GetFields(BindingFlags.Instance |
                 BindingFlags.NonPublic)
                 .FirstOrDefault(x => x.Name == "intStorage")
                 .GetValue(db);

            var actualResult = field.Length;
            var expectedResult = 16;

            Assert.AreEqual(expectedResult, actualResult, "Array should be initlized with exactly 16 length");
        }

        [Test]
        public void TestsIfAddMethodAddsAnElementToTheCorrectCell()
        {
            var db = new DataBaseClass(new int[5]);

            var type = typeof(DataBaseClass);

            db.Add(1);
            db.Add(2);
            db.Add(2);
            db.Add(2);

            var actualIndex = (int)type.GetFields(BindingFlags.Instance |
              BindingFlags.NonPublic)
              .FirstOrDefault(x => x.Name == "currentIndex")
              .GetValue(db);

            int expectedIndex = 4;

            Assert.AreEqual(expectedIndex,actualIndex, "Add command does not set the number on the correct index");
        }

        [Test]
        public void ChecksIfAddMethodThrowsExceptionWhenOverloadsTheArray()
        {
            var db = new DataBaseClass(new int[] { 1,2,3,4});

            Assert.Throws<InvalidOperationException>(() => db.Add(5))
                .Message
                .Equals($"Can`t add more than {db.IntStorage.Length} elements!");            
        }

        [Test]
        public void TestsIfRemoveMethodRemovesTheCorrectNumber()
        {
            var db = new DataBaseClass(new int[] { 1, 2, 3, 4 });

            db.Remove();

            var actualResult = db.IntStorage[3];
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult, "Remove method does not remove at the correct index properly.");           
        }

        [Test]
        public void TestsIfRemoveMethodThrowsExceptionWhenTryingToRemoveFromEmptyArray()
        {
            var db = new DataBaseClass();

            Assert.Throws<InvalidOperationException>(() => db.Remove())
                .Message
                .Equals("Database is empty!");
        }

        [Test]
        public void TestsIfFetchMethodReturnsTheElementsFromTheArray()
        {
            var db = new DataBaseClass();
            db.Add(1);
            db.Add(2);
            db.Add(3);
            db.Add(4);
            db.Add(5);

            var expectedResult = new int[] { 1, 2, 3, 4, 5 };
            var actualResult = db.Fetch();

            Assert.AreEqual(expectedResult, actualResult, "Fetch method does not return all of the elements properly!");

        }
    }
}
