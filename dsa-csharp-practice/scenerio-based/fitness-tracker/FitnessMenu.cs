using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.fitnessTracker
{
    internal class FitnessMenu
    {
        

        public void ShowMenu()
        {
            FitnessUtility utility = new FitnessUtility();
            int choice;


            while (true)
            { // Display menu options
                Console.WriteLine("\n--- Fitness Tracker Menu ---");
                Console.WriteLine("1. Add User:");
                Console.WriteLine("2. Sort the user based on stepcounts ");
                Console.WriteLine("3.Display leaderboard ");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        utility.AddUserDetails();
                        break;
                    case 2:
                        utility.Sort();
                        break;
                    case 3:
                        utility.DisplayLeaderboard();
                        break;
                    case 4:
                        Console.WriteLine("Exiting SuccessFully");

                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            }

        }
    }
}
