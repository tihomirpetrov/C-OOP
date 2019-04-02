namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int AttackPoints = 10;
        private int DummyHealth = 10;
        private int DummyExperience = 10;

        [SetUp]
        public void TestInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 15);
            dummy.TakeAttack(5);

            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void DeadDummyThrowExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.That(() => dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyGiveExpirience()
        {
            while (!this.dummy.IsDead())
            {
                this.dummy.TakeAttack(AttackPoints);
            }

            int gotExperience = this.dummy.GiveExperience();

            Assert.AreEqual(10, gotExperience, "Dead dummy doesn't give experience.");
        }

        [Test]
        public void AliveDummyCannotGiveExperience()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() => this.dummy.GiveExperience());
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}