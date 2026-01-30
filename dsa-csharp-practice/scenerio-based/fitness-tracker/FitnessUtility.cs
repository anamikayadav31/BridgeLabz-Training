/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.fitnessTracker
{
    internal class FitnessUtility:IFitness
    {
            private User[] users;        // Array to store users
            private int userCount = 0;   // Tracks number of users added

            // Constructor: initializes array size
            public FitnessUtility()
            {
                Console.Write("Enter the maximum number of users: ");
                int size = int.Parse(Console.ReadLine());
                users = new User[size];
            }

            // Adds a new user with name and steps
            public void AddUser()
            {
                if (userCount == users.Length)
                {
                    Console.WriteLine(" User limit reached. Cannot add more users.");
                    return;
                }

                Console.Write("Enter user name: ");
                string name = Console.ReadLine();

                Console.Write("Enter steps taken: ");
                int steps = int.Parse(Console.ReadLine());

                users[userCount++] = new User(name, steps);
                Console.WriteLine(" User added successfully.");
            }

            // Displays steps of all users
            public void ShowSteps()
            {
                if (userCount == 0)
                {
                    Console.WriteLine(" No users available to display.");
                    return;
                }

                Console.WriteLine("\n--- User Steps Details ---");
                for (int i = 0; i < userCount; i++)
                {
                    Console.WriteLine(users[i]); 
                }
            }

            // Sorts users using Bubble Sort and displays leaderboard
            public void ShowLeaderBoard()
            {
                if (userCount == 0)
                {
                    Console.WriteLine(" No users available to display leaderboard.");
                    return;
                }

                // Bubble Sort 
                for (int i = 0; i < userCount - 1; i++)
                {
                    for (int j = 0; j < userCount - i - 1; j++)
                    {
                        if (users[j].Steps < users[j + 1].Steps)
                        {
                            User temp = users[j];
                            users[j] = users[j + 1];
                            users[j + 1] = temp;
                        }
                    }
                }

                Console.WriteLine("\n Daily Fitness Leaderboard");
                for (int i = 0; i < userCount; i++)
                {
                    Console.WriteLine($"{i + 1}. {users[i].Name} - {users[i].Steps} steps");
                }
            }
        }
    }*/

