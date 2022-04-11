using Microsoft.VisualStudio.TestPlatform.ObjectModel;

using NUnit.Framework;

using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database dataBase;
        private readonly int[] initialArr = new int[] { 1, 2 };


        [SetUp]
        public void Setup()
        {
            dataBase = new Database(initialArr);
        }

        [Test]
        [TestCase(0)]
        [TestCase(6)]
        [TestCase(16)]
        public void TestIfCtorWorkProperly(int arrLenght)
        {
            int[] data = new int[arrLenght];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            Database database = new Database(data);
            int expectedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(17)]
        public void CtorThrowInvalidOperationExceptionWhenInitializeWithBiggerLenght(int length)
        {
            int[] arr = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dataBase = new Database(arr);
            });
        }

        [Test]
        public void AddShoudIncreaseCountWhenAddedSuccsesfuly()
        {
            this.dataBase.Add(3);

            int exppectedCount = 3;
            int actualCount = this.dataBase.Count;

            Assert.AreEqual(exppectedCount, actualCount);
        }
        [Test]
        public void AddShoudThrowExceptionWhenDatabaseFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.dataBase.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => 
            { 
                this.dataBase.Add(17); 
            });
        }

        [Test]
        public void TestIfRemoveWorkProperly()
        {
            this.dataBase.Remove();
            this.dataBase.Remove();

            int expectedCount = 0;
            int actualCount = this.dataBase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveFromEmtyDatabaseShoudThrowException()
        {
            this.dataBase.Remove();
            this.dataBase.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dataBase.Remove();
            });
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1,2,3})]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16 })]
        public void FetchShoudReturnArray(int[] expected)
        {
            this.dataBase = new Database(expected);

            int[] actualData = this.dataBase.Fetch();

            CollectionAssert.AreEqual(expected, actualData);

        }
    }
}