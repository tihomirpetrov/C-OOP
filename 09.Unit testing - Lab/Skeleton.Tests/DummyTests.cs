namespace Skeleton.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
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
            Hero hero = new Hero("Ivan");
            Dummy dummy = new Dummy(10, 50);

            hero.Attack(dummy);

            Assert.That(hero.Experience, Is.EqualTo(50));
        }
    }
}
