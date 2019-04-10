using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
                
        [Test]
        public void ConstructorShouldSetProperValues()
        {
            string name = "Gosho";
            decimal balance = 340.34M;
            var bankAccount = new BankAccount(name, balance);

            Assert.AreEqual(name, bankAccount.Name);
            Assert.AreEqual(balance, bankAccount.Balance);

            //test ctor setting proper values
        }

        [Test]
        [TestCase("1", 3450.34)]
        [TestCase("StringWithMoreThan25Symbols", 3450.34)]
        public void ConstructorShouldThrowArgumentException_InvalidNameLength(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
            //invalid name minLen/maxLen
        }

        [Test]
        [TestCase("Gosho", -1)]
        [TestCase("Pesho", -5)]
        public void ConstructorShouldThrowArgumentExceptionInvalidBalance(string name, decimal balance)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, balance));
            //invalid balance
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DepositShouldThrowInvalidOperationException_InvalidAmount(decimal amount)
        {
            string name = "Gosho";
            decimal balance = 340.34M;
            var bankAccount = new BankAccount(name, balance);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(0));
            //deposit invalid amount
        }

        [Test]
        public void DepositShouldInreaseBalance_ValidAmount()
        {
            string name = "Gosho";
            decimal balance = 340.34M;
            var bankAccount = new BankAccount(name, balance);

            bankAccount.Deposit(120);

            var expected = 460.34M;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
            //balance has increased
        }

        [Test]
        public void Withdraw_ShouldThrownvalidOperationException_InvalidBalance()
        {
            string name = "Gosho";
            decimal balance = 340.34M;
            var bankAccount = new BankAccount(name, balance);

            var invalidAmount = -5;

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(invalidAmount));
            //withdraw invalid amount -5
        }

        [Test]
        public void Withdraw_ShouldThrownvalidOperationException_InsufficientFunds()
        {
            string name = "Gosho";
            decimal balance = 340.34M;
            var bankAccount = new BankAccount(name, balance);

            var invalidAmount = 500;
            
            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(invalidAmount));
            //insufficient funds
            //withdraw invalid amount(500) more than balance
        }

        [Test]
        public void Withdraw_ShouldDecreaseBalanceCorrectly()
        {
            string name = "Gosho";
            decimal balance = 340.34M;
            var bankAccount = new BankAccount(name, balance);

            var validAmount = 40.34M;

            bankAccount.Withdraw(validAmount);

            var expected = 300;
            var actual = bankAccount.Balance;

            Assert.AreEqual(expected, actual);
            //balance has drecreased
        }       
    }
}