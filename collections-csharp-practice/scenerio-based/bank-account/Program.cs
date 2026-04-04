// See https://aka.ms/new-console-template for more information


using System;

namespace bank_account
{
    public class Program
    {
        // Property to store account balance
        public decimal Balance { get; private set; }

        // Constructor to set initial balance
        public Program(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        // Deposit method
        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Deposit amount cannot be negative");

            Balance += amount;
        }

        // Withdraw method
        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds.");

            Balance -= amount;
        }
    }
}