using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{

    // interface for loan operations
    interface ILoanOperations
    {
        void ApplyLoan();
        double ComputeLoanEligibility();
    }

    // abstract base class
    abstract class Account
    {
        // private fields for encapsulation
        private int accNumber;
        private string accHolder;
        private double accBalance;

        // Properties
        public int AccNumber
        {
            get { return accNumber; }
            set { accNumber = value; }
        }

        public string AccHolder
        {
            get { return accHolder; }
            set { accHolder = value; }
        }

        public double AccBalance
        {
            get { return accBalance; }
            protected set { accBalance = value; }
        }

        // Deposit money
        public void Deposit(double amount)
        {
            if (amount > 0)
                AccBalance += amount;
        }

        // Withdraw money
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= AccBalance)
                AccBalance -= amount;
            else
                Console.WriteLine("Insufficient balance");
        }

        // Abstract method for interest calculation
        public abstract double ComputeInterest();

        // Display account info
        public void DisplayAccountInfo()
        {
            Console.WriteLine("Account Number : " + AccNumber);
            Console.WriteLine("Account Holder : " + AccHolder);
            Console.WriteLine("Balance        : " + AccBalance);
        }
    }

    // Savings account
    class SavingsAcc : Account, ILoanOperations
    {
        public override double ComputeInterest()
        {
            return AccBalance * 0.04; // 4% interest
        }

        public void ApplyLoan()
        {
            Console.WriteLine("Loan requested from Savings Account");
        }

        public double ComputeLoanEligibility()
        {
            return AccBalance * 2;
        }
    }

    // Current account
    class CurrentAcc : Account, ILoanOperations
    {
        public override double ComputeInterest()
        {
            return AccBalance * 0.02; // 2% interest
        }

        public void ApplyLoan()
        {
            Console.WriteLine("Loan requested from Current Account");
        }

        public double ComputeLoanEligibility()
        {
            return AccBalance * 3;
        }
    }

    // Main class
    internal class BankApp
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter number of accounts: ");
            int numAccounts = int.Parse(Console.ReadLine());

            // Array for polymorphism
            Account[] accArray = new Account[numAccounts];

            for (int i = 0; i < numAccounts; i++)
            {
                Console.WriteLine($"\nEnter type of account #{i + 1} (1-Savings, 2-Current): ");
                int typeChoice = int.Parse(Console.ReadLine());

                Account acc;

                if (typeChoice == 1)
                    acc = new SavingsAcc();
                else
                    acc = new CurrentAcc();

                Console.Write("Enter account number: ");
                acc.AccNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter account holder name: ");
                acc.AccHolder = Console.ReadLine();

                Console.Write("Enter initial balance: ");
                acc.Deposit(double.Parse(Console.ReadLine()));

                accArray[i] = acc;
            }

            // Display all accounts with interest and loan info
            Console.WriteLine("\n--- Account Details ---");

            for (int i = 0; i < accArray.Length; i++)
            {
                accArray[i].DisplayAccountInfo();

                double interest = accArray[i].ComputeInterest();
                Console.WriteLine("Calculated Interest : " + interest);

                if (accArray[i] is ILoanOperations loanable)
                {
                    loanable.ApplyLoan();
                    Console.WriteLine("Loan Eligibility : " + loanable.ComputeLoanEligibility());
                }

                Console.WriteLine();
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}