using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class Bank
    {



        // Bank name
        public string bankTitle;

        // Constructor
        public Bank(string bankTitle)
        {
            this.bankTitle = bankTitle;
        }

        // Method to open account
        public void OpenAccount(Customer customerObj, double openingBalance)
        {
            customerObj.accountBalance = openingBalance;
            Console.WriteLine("Account opened for " + customerObj.customerName +
                              " in " + bankTitle);
        }

        // Customer class
        public class Customer
        {
            // Customer details
            public string customerName;
            public double accountBalance;

            // Constructor
            public Customer(string customerName)
            {
                this.customerName = customerName;
            }

            // Method to show balance
            public void ViewBalance()
            {
                Console.WriteLine(customerName + "'s Balance: " + accountBalance);
            }
        }

        // Main method
        public static void Main(string[] args)
        {
            // Take bank name from user
            Console.WriteLine("Enter Bank Name:");
            string inputBankName = Console.ReadLine();

            Bank userBank = new Bank(inputBankName);

            // Take number of customers
            Console.WriteLine("Enter number of customers:");
            int customerCount = int.Parse(Console.ReadLine());

            // Loop to create customers
            for (int i = 1; i <= customerCount; i++)
            {
                Console.WriteLine("\nEnter Customer Name:");
                string inputCustomerName = Console.ReadLine();

                Console.WriteLine("Enter Opening Balance:");
                double inputBalance = double.Parse(Console.ReadLine());

                // Create customer object
                Customer customerObj = new Customer(inputCustomerName);

                // Open account
                userBank.OpenAccount(customerObj, inputBalance);

                // Display balance
                customerObj.ViewBalance();
            }
        }
    }
}