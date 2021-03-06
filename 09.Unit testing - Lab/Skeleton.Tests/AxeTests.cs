﻿public class AxeTests
{
    [Test]
    public void AxeLooseDurabilityAfterAttack()

﻿namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");

            axe.Attack(dummy);
            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(9, axe.DurabilityPoints);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }
    }
}