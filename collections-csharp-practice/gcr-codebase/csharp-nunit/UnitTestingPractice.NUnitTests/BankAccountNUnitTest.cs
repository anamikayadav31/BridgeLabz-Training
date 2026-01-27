using NUnit.Framework;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount account = null!;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount();
        }

        [Test]
        public void Deposit_UpdatesBalanceCorrectly()
        {
            account.Deposit(1000);

            Assert.That(account.GetBalance(), Is.EqualTo(1000));
        }

        [Test]
        public void Withdraw_UpdatesBalanceCorrectly()
        {
            account.Deposit(1000);

            account.Withdraw(400);

            Assert.That(account.GetBalance(), Is.EqualTo(600));
        }

        [Test]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            account.Deposit(200);

            Assert.Throws<InvalidOperationException>(() =>
                account.Withdraw(500)
            );
        }
    }
}
