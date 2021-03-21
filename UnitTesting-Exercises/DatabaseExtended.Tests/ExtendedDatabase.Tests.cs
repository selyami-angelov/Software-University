
using NUnit.Framework;

using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private readonly Person[] initialCap = new Person[] { new Person(0000,"Pesho"), new Person(1111, "Gosho") };
        ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase(initialCap);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(16)]
        public void TestIfCtorWorkProperly(int databaseLenght)
        {
            Person[] persons = new Person[databaseLenght];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }
            this.database = new ExtendedDatabase(persons);
            int expectedCount = databaseLenght;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(17)]
        public void CtorThrowInvalidOperationExceptionWhenInitializeWithBiggerLenght(int length)
        {
            Person[] persons = new Person[length];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            Assert.Throws<ArgumentException>(() =>
            {
                this.database = new ExtendedDatabase(persons);
            });
        }

        [Test]
        public void AddShoudIncreaseCountWhenAddedSuccsesfuly()
        {
            this.database.Add(new Person(1, "1"));

            int exppectedCount = 3;
            int actualCount = this.database.Count;

            Assert.AreEqual(exppectedCount, actualCount);
        }

        [Test]
        public void AddShoudThrowExceptionWhenAddOverCapacity()
        {

            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(new Person(i, i.ToString()));
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(17, "17th"));
            });
        }

        [Test]
        public void AddShoudThrowExceptionWhenAddExistingUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(32345, "Pesho"));
            });
        }

        [Test]
        public void AddShoudThrowExceptionWhenAddExistingId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(0000, "OtherPeshoWithSameId"));
            });
        }

        [Test]
        public void TestIfRemoveWorkProperly()
        {
            this.database.Remove();
            this.database.Remove();

            int expectedCount = 0;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveShoudThrowInvalidOperationExceptionWhenDatabaseIsEmty()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        [TestCase("Pesho")]
        [TestCase("Gosho")]
        public void TestIfFindByNameWorkProperly(string name)
        {
            Person person = this.database.FindByUsername(name);
            string actualName = person.UserName;

            Assert.AreEqual(name, actualName);
        }

        [Test]
        public void FindByNameShoudThrowExceptionIfNameNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = this.database.FindByUsername("NotExistingGuy");
            });
        }

        [Test]
        public void FindByNameShoudThrowExceptionIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Person person = this.database.FindByUsername(null);
            });
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1111)]
        public void TestIfFindByIdWorkProperly(long id)
        {
            Person person = this.database.FindById(id);
            long actualName = person.Id;

            Assert.AreEqual(id, actualName);
        }

        [Test]
        public void FindByIdShoudThrowExceptionIfIdNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(6546);
            });
        }

        [Test]
        public void FindByIdShoudThrowExceptionIfIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(-11111);
            });
        }
    }
}