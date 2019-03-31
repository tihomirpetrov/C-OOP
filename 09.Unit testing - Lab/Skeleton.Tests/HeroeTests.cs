using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class HeroeTests
    {
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            FakeDeadTarget fakeDeadTarget = new FakeDeadTarget();
            FakeWeapon fakeWeapon = new FakeWeapon();
            Hero hero = new Hero("FakeHero", fakeWeapon);

            hero.Attack(fakeDeadTarget);
            int gainExperience = fakeDeadTarget.GiveExperience();

            Assert.AreEqual(gainExperience, hero.Experience);
        }
    }
}