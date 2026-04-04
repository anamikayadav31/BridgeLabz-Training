using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.oopsKeywordsOperator
{
    internal class BankAccount
    {


        // static variable: shared by all accounts
        public static string BankName = "Campus Bank";

        // static variable to count total accounts
        private static int TotalAccounts = 0;

        // readonly: account number cannot be changed after creation
        public readonly int AccountNumber;

        // normal variables
        public string AccountHolder;
        private double Balance;

        // Constructor using 'this' keyword
        public BankAccount(int accountNumber, string accountHolder, double balance)
        {
            this.AccountNumber = accountNumber; // refers to current object
            this.AccountHolder = accountHolder;
            this.Balance = balance;

            TotalAccounts++; // increase total accounts count
        }

        // Show account details
        public void ShowDetails()
        {
            Console.WriteLine("\nAccount Information:");
            Console.WriteLine("Bank Name       : " + BankName);
            Console.WriteLine("Account Number  : " + AccountNumber);
            Console.WriteLine("Account Holder  : " + AccountHolder);
            Console.WriteLine("Balance         : " + Balance);
        }

        // Static method to show total accounts
        public static void ShowTotalAccounts()
        {
            Console.WriteLine("\nTotal accounts created: " + TotalAccounts);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Campus Bank System");

            // Ask how many accounts to create
            Console.Write("How many accounts do you want to create? : ");
            int numberOfAccounts = int.Parse(Console.ReadLine());

            // Array to store bank accounts
            BankAccount[] accountArray = new BankAccount[numberOfAccounts];

            // Take user input for each account
            for (int i = 0; i < numberOfAccounts; i++)
            {
                Console.WriteLine($"\nEnter details for Account {i + 1}:");

                Console.Write("Enter Account Number: ");
                int accNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter Account Holder Name: ");
                string accHolder = Console.ReadLine();

                Console.Write("Enter Opening Balance: ");
                double balance = double.Parse(Console.ReadLine());

                // Create BankAccount object and store in array
                accountArray[i] = new BankAccount(accNumber, accHolder, balance);
            }

            // Show details of all accounts using 'is' keyword
            Console.WriteLine("\nChecking Account Details...");
            for (int i = 0; i < numberOfAccounts; i++)
            {
                if (accountArray[i] is BankAccount)
                {
                    accountArray[i].ShowDetails();
                }
            }

            // Show total accounts created
            BankAccount.ShowTotalAccounts();

            Console.WriteLine("\nThank you for using Campus Bank System :)");
        }
    }
}
