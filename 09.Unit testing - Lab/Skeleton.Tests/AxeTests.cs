<<<<<<< HEAD:09.Unit testing - Lab/Skeleton/Tests/AxeTests.cs
﻿public class AxeTests
{
    [Test]
    public void AxeLooseDurabilityAfterAttack()
=======
﻿namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
>>>>>>> 7c4ca37dc35ce1260ae613ed25c7b28b2d5162ea:09.Unit testing - Lab/Skeleton.Tests/AxeTests.cs
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

<<<<<<< HEAD:09.Unit testing - Lab/Skeleton/Tests/AxeTests.cs
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
=======
            axe.Attack(dummy);
            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(9, axe.DurabilityPoints);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
>>>>>>> 7c4ca37dc35ce1260ae613ed25c7b28b2d5162ea:09.Unit testing - Lab/Skeleton.Tests/AxeTests.cs
    }
}