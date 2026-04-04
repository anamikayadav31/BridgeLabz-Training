using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{
    internal class BankManagementScenerio1
    {



        class Bank
        {
            public static void Main(string[] args)
            {
                BankManager bankManager = new BankManager();   // Manager object
                Client[] clientList = new Client[1000];        // Store clients
                int clientCount = 0;                           // Account index

                while (true)
                {
                    Console.WriteLine("\nEnter role: manager | user | exit");
                    string userRole = Console.ReadLine();

                    // Manager operations
                    if (userRole == "manager")
                    {
                        Console.WriteLine("1. Create Account");
                        Console.WriteLine("2. Update Balance");
                        int managerChoice = int.Parse(Console.ReadLine());

                        switch (managerChoice)
                        {
                            case 1:
                                Console.Write("Enter Name: ");
                                string clientName = Console.ReadLine();

                                Console.Write("Opening Balance: ");
                                int openingBalance = int.Parse(Console.ReadLine());

                                // Create new account
                                clientList[clientCount] =
                                    bankManager.CreateAccount(clientCount, clientName, openingBalance);

                                Console.WriteLine("Account Created Successfully");
                                Console.WriteLine("Account Number: " + clientCount);
                                Console.WriteLine("Opening Balance: " + openingBalance);

                                clientCount++; // Move to next index
                                break;

                            case 2:
                                Console.Write("Enter Account Number: ");
                                int accountNumber = int.Parse(Console.ReadLine());

                                Console.Write("Enter Amount to Add: ");
                                int addAmount = int.Parse(Console.ReadLine());

                                bankManager.UpdateBalance(clientList[accountNumber], addAmount);
                                break;
                        }
                    }
                    // User operations
                    else if (userRole == "user")
                    {
                        Console.WriteLine("1. Check Balance");
                        Console.WriteLine("2. Deposit");
                        Console.WriteLine("3. Withdraw");

                        int userChoice = int.Parse(Console.ReadLine());

                        Console.Write("Enter Account Number: ");
                        int userAccountNumber = int.Parse(Console.ReadLine());

                        switch (userChoice)
                        {
                            case 1:
                                Console.WriteLine("Balance: " +
                                    clientList[userAccountNumber].CheckBalance());
                                break;

                            case 2:
                                Console.Write("Enter Amount: ");
                                int depositAmount = int.Parse(Console.ReadLine());
                                clientList[userAccountNumber].Deposit(depositAmount);
                                break;

                            case 3:
                                Console.Write("Enter Amount: ");
                                int withdrawAmount = int.Parse(Console.ReadLine());
                                clientList[userAccountNumber].Withdraw(withdrawAmount);
                                break;
                        }
                    }
                    // Exit program
                    else
                    {
                        break;
                    }
                }
            }
        }

        // Base bank account class
        public class BankAccount
        {
            private double balance; // Account balance

            public void SetValue(double amount)
            {
                balance = amount;
            }

            public double CheckBalance()
            {
                return balance;
            }
        }

        // Client class inherits BankAccount
        public class Client : BankAccount
        {
            public string ClientName;    // Client name
            int accountNumber;           // Account number

            public Client(int number, string name, int openingAmount)
            {
                accountNumber = number;
                ClientName = name;
                SetValue(openingAmount);
            }

            public void Deposit(int amount)
            {
                SetValue(CheckBalance() + amount);
                Console.WriteLine("Deposit Successful");
            }

            public void Withdraw(int amount)
            {
                if (amount > CheckBalance())
                {
                    Console.WriteLine("Insufficient Balance");
                    return;
                }

                SetValue(CheckBalance() - amount);
                Console.WriteLine("Withdrawal Successful");
            }
        }

        // Bank manager class
        public class BankManager
        {
            public Client CreateAccount(int accountNo, string name, int openingAmount)
            {
                return new Client(accountNo, name, openingAmount);
            }

            public void UpdateBalance(Client client, int amount)
            {
                client.Deposit(amount);
                Console.WriteLine("Updated Balance: " + client.CheckBalance());
            }
        }
    }
}
            
