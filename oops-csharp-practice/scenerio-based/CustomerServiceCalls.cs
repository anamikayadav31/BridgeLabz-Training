using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{



    // Represents a single customer call record
    class CustomerCall
    {
        public string CustomerPhoneNumber;
        public string IssueMessage;
        public DateTime CallTime;

        // Constructor to initialize call details
        public CustomerCall(string phoneNumber, string message, DateTime callTime)
        {
            CustomerPhoneNumber = phoneNumber;
            IssueMessage = message;
            CallTime = callTime;
        }

        // Display call details
        public void DisplayCallDetails()
        {
            Console.WriteLine("Phone Number : " + CustomerPhoneNumber);
            Console.WriteLine("Issue        : " + IssueMessage);
            Console.WriteLine("Call Time    : " + CallTime);
        }
    }

    // Manages multiple customer call records
    class CustomerCallManager
    {
        private CustomerCall[] callRecords;
        private int recordCount = 0;

        // Initialize call log size
        public CustomerCallManager(int capacity)
        {
            callRecords = new CustomerCall[capacity];
        }

        // Add a new call record
        public void AddCustomerCall(CustomerCall call)
        {
            if (recordCount < callRecords.Length)
            {
                callRecords[recordCount] = call;
                recordCount++;
                Console.WriteLine("Call record added successfully.\n");
            }
            else
            {
                Console.WriteLine("Call log storage is full.\n");
            }
        }

        // Search calls using keyword
        public void SearchCallsByKeyword(string keyword)
        {
            Console.WriteLine("\nSearch Results for keyword: " + keyword);

            for (int i = 0; i < recordCount; i++)
            {
                if (callRecords[i].IssueMessage.Contains(keyword))
                {
                    callRecords[i].DisplayCallDetails();
                    Console.WriteLine();
                }
            }
        }

        // Filter calls within a time range
        public void FilterCallsByTime(DateTime startTime, DateTime endTime)
        {
            Console.WriteLine($"\nCalls between {startTime} and {endTime}");

            for (int i = 0; i < recordCount; i++)
            {
                if (callRecords[i].CallTime >= startTime &&
                    callRecords[i].CallTime <= endTime)
                {
                    callRecords[i].DisplayCallDetails();
                    Console.WriteLine();
                }
            }
        }
    }

    // Main execution class
    internal class CustomerServiceCalls
    {
        public static void Main(string[] args)
        {
            CustomerCallManager callManager = new CustomerCallManager(10);

            while (true)
            {
                // Display menu
                Console.WriteLine("\n--- Customer Service Call Log ---");
                Console.WriteLine("1. Add Call Record");
                Console.WriteLine("2. Search Calls by Keyword");
                Console.WriteLine("3. Filter Calls by Time");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string menuInput = Console.ReadLine();

                if (menuInput == "1")
                {
                    // Take call details from user
                    Console.Write("Enter phone number: ");
                    string phoneNumber = Console.ReadLine();

                    Console.Write("Enter issue description: ");
                    string issueMessage = Console.ReadLine();

                    Console.Write("Enter call time (yyyy-MM-dd HH:mm): ");
                    DateTime callTime = DateTime.Parse(Console.ReadLine());

                    CustomerCall newCall =
                        new CustomerCall(phoneNumber, issueMessage, callTime);

                    callManager.AddCustomerCall(newCall);
                }
                else if (menuInput == "2")
                {
                    Console.Write("Enter keyword to search: ");
                    string keyword = Console.ReadLine();

                    callManager.SearchCallsByKeyword(keyword);
                }
                else if (menuInput == "3")
                {
                    Console.Write("Enter start time (yyyy-MM-dd HH:mm): ");
                    DateTime fromTime = DateTime.Parse(Console.ReadLine());

                    Console.Write("Enter end time (yyyy-MM-dd HH:mm): ");
                    DateTime toTime = DateTime.Parse(Console.ReadLine());

                    callManager.FilterCallsByTime(fromTime, toTime);
                }
                else if (menuInput == "4")
                {
                    Console.WriteLine("Exiting application...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}