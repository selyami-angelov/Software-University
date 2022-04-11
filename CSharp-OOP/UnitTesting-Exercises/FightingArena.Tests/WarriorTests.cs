using NUnit.Framework;

using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        private string name = "Pesho";
        private int damage = 10;
        private int hp = 100;

        [SetUp]
        public void Setup()
        {

            warrior = new Warrior(this.name, this.damage, this.hp);
        }

        [Test]
        public void TestIfCtorWorkProperly()
        {
            Assert.AreEqual(this.name, warrior.Name);
            Assert.AreEqual(this.damage, warrior.Damage);
            Assert.AreEqual(this.hp, warrior.HP);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void NamePropSetterShoultThrowArgumentExcIfValueIsNull(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(value, this.damage, this.hp);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void DamagePropSetterShoultThrowArgumentExcIfValueIsNegativeOrZero(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(this.name, value, this.hp);
            });
        }

        [Test]
        [TestCase(-5)]
        public void HpPropSetterShoultThrowArgumentExcIfValueIsNegative(int value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(this.name, this.damage, value);
            });
        }

        [Test]
        public void TestIfAttackWorkProperly()
        {
            Warrior atkWarrior = new Warrior("Gosho", 20, 100);
            int expectedWarrHp = 80;
            int expectedAtkWarrHp = 90;
            this.warrior.Attack(atkWarrior);
            int actualWarrHp = this.warrior.HP;
            int actualAtkWarrHp = atkWarrior.HP;

            Assert.AreEqual(expectedWarrHp, actualWarrHp);
            Assert.AreEqual(expectedAtkWarrHp, actualAtkWarrHp);

        }

        [Test]
        public void AttackShoultThrowInvalidOperationExceptionIfWarrHpBelowOrEqual30()
        {
            this.warrior = new Warrior("Pesho", 20, 29);
            Warrior atkWarrior = new Warrior("Gosho", 20, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(atkWarrior);
            });

        }

        [Test]
        public void AttackShoultThrowInvalidOperationExceptionIfAtkWarrHpBelowOrEqual30()
        {
            Warrior atkWarrior = new Warrior("Gosho", 20, 29);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(atkWarrior);
            });

        }

        [Test]
        public void AttackShoultThrowInvalidOperationExceptionIfWarrHpBelowAtkWarrDmg()
        {
            Warrior atkWarrior = new Warrior("Gosho", 110, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.warrior.Attack(atkWarrior);
            });

        }

        [Test]
        public void EnemyHpShouldSetToZeroIfAtackerDmgIsGreaterTheEnemyHp()
        {
            this.warrior = new Warrior("Pesho", 100, 1000);
            Warrior atkWarrior = new Warrior("Gosho", 20, 90);

            int expectedHp = 0;
            this.warrior.Attack(atkWarrior);
            int actualHp = atkWarrior.HP;

            Assert.AreEqual(expectedHp, actualHp);

        }



    }
}