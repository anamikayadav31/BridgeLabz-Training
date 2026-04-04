using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;
using System;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class BankAccountMSTest
    {
        private BankAccount account = null!;

        [TestInitialize]
        public void Setup()
        {
            account = new BankAccount();
        }

        [TestMethod]
        public void Deposit_UpdatesBalanceCorrectly()
        {
            // Act
            account.Deposit(1000);

            // Assert
            Assert.AreEqual(1000, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_UpdatesBalanceCorrectly()
        {
            account.Deposit(1000);

            account.Withdraw(400);

            Assert.AreEqual(600, account.GetBalance());
        }

        [TestMethod]
        public void Withdraw_InsufficientFunds_ThrowsException()
        {
            account.Deposit(200);

            Assert.ThrowsException<InvalidOperationException>(() =>
                account.Withdraw(500)
            );
        }
    }
}
