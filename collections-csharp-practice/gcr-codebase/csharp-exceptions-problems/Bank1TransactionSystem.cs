using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.exceptions
{
    


// Custom exception
class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message)
        {
        }
    }

    class BankAccount
    {
        double balance = 5000; // Initial balance

        // Withdraw method
        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Invalid amount!");
            }

            if (amount > balance)
            {
                throw new InsufficientFundsException("Insufficient balance!");
            }

            balance -= amount;
            Console.WriteLine("Withdrawal successful, new balance: " + balance);
        }
    }

    internal class Bank1TransactionSystem
    {


        static void Main()
        {
            BankAccount account = new BankAccount();

            try
            {
                // Take withdrawal amount
                Console.Write("Enter withdrawal amount: ");
                double amount = double.Parse(Console.ReadLine());

                // Perform withdrawal
                account.Withdraw(amount);
            }
            catch (InsufficientFundsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
