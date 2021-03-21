
using NUnit.Framework;

using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("VW", "Golf", 10, 100);
        }

        [Test]
        public void TestIfConstructorWorkProperly()
        {
            car = new Car("VW", "Golf", 10, 100);

            Assert.AreEqual("VW", car.Make);
            Assert.AreEqual("Golf", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakePropShouldThrowArgException(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(make, "Golf", 10, 100);
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ModelPropShouldThrowArgException(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("VW", model, 10, 100);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5.5)]
        public void FuelConsumptPropShouldThrowArgExceptionIfAmountIsNegative(double consumpt)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("VW", "Golf", consumpt, 100);
            });
        }

        [Test]
        public void FuelCapacityPropShouldThrowArgExceptionIfAmountIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("VW", "Golf", 10, -10);
            });
        }

        [Test]
        [TestCase(1)]
        [TestCase(50)]
        [TestCase(100)]
        public void TestIfRefuelWorkProperly(double refuelAmount)
        {
            double expectedAmount = this.car.FuelAmount+refuelAmount;
            this.car.Refuel(refuelAmount);
            double actualAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowArgumentException(double refuelAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(refuelAmount);
            });
        }

        [Test]
        [TestCase(101)]
        [TestCase(200)]
        public void RefuelWithMoreThanCapacityShouldSetFullAmount(double refuelAmount)
        {
            this.car.Refuel(refuelAmount);
            double expectedAmount = this.car.FuelCapacity;
            double actualAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        public void TestIfDriveWorkProperly(double distance)
        {
            this.car.Refuel(100);
            double expectedFuelAmount = this.car.FuelAmount-((distance / 100) * this.car.FuelConsumption);
            this.car.Drive(distance);
            double actualAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualAmount);

        }

        [Test]
        public void DriveShouldThrowExceptionWhenNotEnoughtFuel()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(100);
            });
        }
    }
}