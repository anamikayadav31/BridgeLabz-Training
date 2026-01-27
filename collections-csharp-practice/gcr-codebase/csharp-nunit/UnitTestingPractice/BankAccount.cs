using System;

namespace UnitTestingPractice
{
    public class BankAccount
    {
        private double balance;

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
                throw new InvalidOperationException("Insufficient funds");

            balance -= amount;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}
