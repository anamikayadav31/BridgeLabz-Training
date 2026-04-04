using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.fitnessTracker
{
    internal class FitnessMenu
    {
       
            // Displays menu 
            public void DisplayMenu()
            {
                FitnessUtility utility = new FitnessUtility();

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("  Welcome to Fitness Tracker Application ");

                    Console.WriteLine("Please choose an option:");
                    Console.WriteLine("1. Add a new user");
                    Console.WriteLine("2. Display steps of all users");
                    Console.WriteLine("3. Display leaderboard ");
                    Console.WriteLine("4. Exit application");

                    Console.Write("\nEnter your choice (1-4): ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            utility.AddUser();
                            break;

                        case "2":
                            utility.ShowSteps();
                            break;

                        case "3":
                            utility.ShowLeaderBoard();
                            break;

                        case "4":
                            Console.WriteLine("\nThank you for using Fitness Tracker.");
                            return;

                        default:
                            Console.WriteLine(" Invalid choice.");
                            break;
                    }
                }
            }
        }
    }


