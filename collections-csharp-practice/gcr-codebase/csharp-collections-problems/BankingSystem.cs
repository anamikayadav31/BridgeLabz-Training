using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.collections_problems
{
    internal class BankingSystem
    {
 

        static void Main()
        {
            // Dictionary to store account balances (AccountNumber -> Balance)
            Dictionary<int, double> accounts = new Dictionary<int, double>();

            // Queue to process withdrawal requests (AccountNumber -> Amount)
            Queue<Tuple<int, double>> withdrawalQueue = new Queue<Tuple<int, double>>();

            // Input accounts
            Console.WriteLine("Enter number of accounts to add:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter account number {i+1}: ");
                int accNo = int.Parse(Console.ReadLine());
                Console.Write("Enter initial balance: ");
                double balance = double.Parse(Console.ReadLine());

                accounts[accNo] = balance;
            }

            // Input withdrawal requests
            Console.WriteLine("\nEnter number of withdrawal requests:");
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                Console.Write($"Enter account number for withdrawal {i+1}: ");
                int accNo = int.Parse(Console.ReadLine());
                Console.Write("Enter withdrawal amount: ");
                double amount = double.Parse(Console.ReadLine());

                withdrawalQueue.Enqueue(Tuple.Create(accNo, amount));
            }

            // Process withdrawal queue
            Console.WriteLine("\nProcessing withdrawals:");
            while (withdrawalQueue.Count > 0)
            {
                var request = withdrawalQueue.Dequeue();
                int accNo = request.Item1;
                double amount = request.Item2;

                if (accounts.ContainsKey(accNo))
                {
                    if (accounts[accNo] >= amount)
                    {
                        accounts[accNo] -= amount;
                        Console.WriteLine($"Withdrawal of Rs {amount} from account {accNo} successful. New balance: Rs {accounts[accNo]}");
                    }
                    else
                    {
                        Console.WriteLine($"Account {accNo} has insufficient funds for withdrawal of Rs {amount}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Account {accNo} does not exist.");
                }
            }

            // Display accounts sorted by balance
            SortedDictionary<double, List<int>> sortedByBalance = new SortedDictionary<double, List<int>>();
            foreach (var kvp in accounts)
            {
                if (!sortedByBalance.ContainsKey(kvp.Value))
                    sortedByBalance[kvp.Value] = new List<int>();
                sortedByBalance[kvp.Value].Add(kvp.Key);
            }

            Console.WriteLine("\nAccounts sorted by balance:");
            foreach (var kvp in sortedByBalance)
            {
                foreach (var accNo in kvp.Value)
                    Console.WriteLine($"Account {accNo} - Rs{kvp.Key}");
            }
        }
    }

}
