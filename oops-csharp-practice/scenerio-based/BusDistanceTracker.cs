using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{
    internal class BusDistanceTracker
    {



        // Instance variables
        string busId;
        string routeTitle;
        int totalDistanceCovered = 0;

        // Constructor to initialize bus details
        public BusDistanceTracker(string busId, string routeTitle)
        {
            this.busId = busId;
            this.routeTitle = routeTitle;
        }

        // Adds distance for each stop
        public void AddDistanceForStop()
        {
            Console.Write("Enter distance for this stop (in km): ");
            int stopDistance = int.Parse(Console.ReadLine());

            totalDistanceCovered += stopDistance;

            Console.WriteLine("Total Distance Covered: " +
                              totalDistanceCovered + " km");
        }

        // Checks if passenger wants to get off
        public bool IsPassengerGettingOff()
        {
            Console.Write("Do you want to get off? (yes/no): ");
            string userResponse = Console.ReadLine();

            return userResponse == "yes" || userResponse == "Yes";
        }

        // Displays journey summary
        public void DisplayJourneySummary()
        {
            Console.WriteLine("\nBus Number   : " + busId);
            Console.WriteLine("Route Name  : " + routeTitle);
            Console.WriteLine("Total Distance Travelled: " +
                              totalDistanceCovered + " km");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Take bus details from user
            Console.Write("Enter Bus Number: ");
            string busId = Console.ReadLine();

            Console.Write("Enter Route Name: ");
            string routeTitle = Console.ReadLine();

            // Create tracker object
            BusDistanceTracker busTracker =
                new BusDistanceTracker(busId, routeTitle);

            int menuChoice;

            while (true)
            {
                // Menu options
                Console.WriteLine("\n--- Bus Route Distance Tracker ---");
                Console.WriteLine("1. Add Stop Distance");
                Console.WriteLine("2. End Journey");
                Console.Write("Enter your choice: ");

                menuChoice = int.Parse(Console.ReadLine());

                if (menuChoice == 1)
                {
                    busTracker.AddDistanceForStop();

                    // Ask passenger decision
                    if (busTracker.IsPassengerGettingOff())
                    {
                        busTracker.DisplayJourneySummary();
                        break;
                    }
                }
                else if (menuChoice == 2)
                {
                    busTracker.DisplayJourneySummary();
                    Console.WriteLine("Passenger got off.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid menu choice.");
                }
            }

            Console.WriteLine("Journey Ended.");
            Console.ReadLine();
        }
    }
}