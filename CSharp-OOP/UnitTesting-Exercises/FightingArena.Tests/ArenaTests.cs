
using NUnit.Framework;
using NUnit.Framework.Internal;

using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void TestIfCtorWorkProperly()
        {
            List<Warrior> warriors = new List<Warrior>();
            CollectionAssert.AreEqual(warriors, this.arena.Warriors);

        }

        [Test]
        public void TestIfEnrolWorlProperly()
        {
            Warrior warrior = new Warrior("Pesho", 20, 100);
            this.arena.Enroll(warrior);
            int expectedCount = 1;
            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void EnrollShouldThrowInvalidOperationExceptionIfNameAlredyExist()
        {
            Warrior warrior = new Warrior("Pesho", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 10, 100);
            this.arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(warrior2);
            });

        }

        [Test]
        public void TestIfFightWorkProperly()
        {
            Warrior warrior = new Warrior("Stamat", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 10, 100);
            this.arena.Enroll(warrior);
            this.arena.Enroll(warrior2);

            int expWrrHp = 90;
            int expWrr2Hp = 80;
            this.arena.Fight("Stamat", "Pesho");
            int actualWarrHp = warrior.HP;
            int actualWarr2Hp = warrior2.HP;

            Assert.AreEqual(expWrrHp, actualWarrHp);
            Assert.AreEqual(expWrr2Hp, actualWarr2Hp);

        }

        [Test]
        public void FightShouldThrowInvalidOperationExceptionIfInvalidAttakerName()
        {
            Warrior warrior = new Warrior("Stamat", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 10, 100);
            this.arena.Enroll(warrior);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("invalidName", "Pesho");
            });
        }

        [Test]
        public void FightShouldThrowInvalidOperationExceptionIfInvalidDeffenderName()
        {
            Warrior warrior = new Warrior("Stamat", 20, 100);
            Warrior warrior2 = new Warrior("Pesho", 10, 100);
            this.arena.Enroll(warrior);
            this.arena.Enroll(warrior2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Stamat", "invalidDefender");
            });
        }
    }
}
