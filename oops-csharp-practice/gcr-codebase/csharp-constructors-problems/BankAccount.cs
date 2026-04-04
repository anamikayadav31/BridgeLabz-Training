using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class BankAccount
    {


        public long AccountNumber;       // public
        protected string AccountHolder;  // protected
        private double Balance;          // private

        // Constructor
        public BankAccount(long accNo, string holder, double bal)
        {
            AccountNumber = accNo;
            AccountHolder = holder;
            Balance = bal;
        }

        // Methods to access/modify balance
        public double GetBalance() => Balance;

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance)
                Balance -= amount;
            else
                Console.WriteLine("Insufficient balance!");
        }
    }

    // Derived class
    internal class SavingsAccount : BankAccount
    {
        public SavingsAccount(long accNo, string holder, double bal)
            : base(accNo, holder, bal)
        {
        }

        // Display account details
        public void ShowDetails()
        {
            Console.WriteLine("\n--- Account Details ---");
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Account Holder: " + AccountHolder);
            Console.WriteLine("Balance: " + GetBalance());
        }

        public static void Main(string[] args)
        {
            // User input for account creation
            Console.Write("Enter Account Number: ");
            long accNo = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Account Holder Name: ");
            string holder = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            double balance = Convert.ToDouble(Console.ReadLine());

            // Create SavingsAccount object
            SavingsAccount sa = new SavingsAccount(accNo, holder, balance);

            // Display account details
            sa.ShowDetails();

            // Deposit money
            Console.Write("\nEnter amount to deposit: ");
            double depositAmount = Convert.ToDouble(Console.ReadLine());
            sa.Deposit(depositAmount);
            Console.WriteLine("Balance after Deposit: " + sa.GetBalance());

            // Withdraw money
            Console.Write("\nEnter amount to withdraw: ");
            double withdrawAmount = Convert.ToDouble(Console.ReadLine());
            sa.Withdraw(withdrawAmount);
            Console.WriteLine("Balance after Withdrawal: " + sa.GetBalance());
        }
    }
}