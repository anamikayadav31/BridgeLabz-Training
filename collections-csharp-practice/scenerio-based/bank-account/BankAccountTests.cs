using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;

namespace bank_account
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            Program account = new Program(1000m);
            account.Deposit(500m);
            ClassicAssert.AreEqual(1500m, account.Balance);
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Program account = new Program(1000m);
            var ex = Assert.Throws<Exception>(() => account.Deposit(-100m));
            ClassicAssert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            Program account = new Program(1000m);
            account.Withdraw(400m);
            ClassicAssert.AreEqual(600m, account.Balance);
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Program account = new Program(1000m);
            var ex = Assert.Throws<Exception>(() => account.Withdraw(2000m));
            ClassicAssert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}