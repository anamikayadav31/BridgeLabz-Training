using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.fitnessTracker
{

    internal class FitnessUtility : IFitness
    {
        private string[] usernames;
        private int[] stepscount;
        private int numberofUser;

      
        public FitnessUtility()
        {
            Console.WriteLine("Enter the number of users:");
            numberofUser = int.Parse(Console.ReadLine());

            usernames = new string[numberofUser];
            stepscount = new int[numberofUser];
        }

        // method to add user names and step count
        public void AddUserDetails()
        {
            for (int i = 0; i < numberofUser; i++)
            {
                Console.WriteLine($"Enter the name of user {i + 1}:");
                string name= Console.ReadLine();
                usernames[i] = name;

                Console.WriteLine($"Enter steps count for user {i + 1}:");
               

                    int steps= int.Parse(Console.ReadLine());
                stepscount[i] = steps;
            }
        }

        // sort users based on steps count (Descending order)
        public void Sort()
        {
            for (int i = 0; i < numberofUser - 1; i++)
            {
                for (int j = 0; j < numberofUser - i - 1; j++)
                {
                    if (stepscount[j] < stepscount[j + 1])
                    {
                        // swap steps
                        int tempSteps = stepscount[j];
                        stepscount[j] = stepscount[j + 1];
                        stepscount[j + 1] = tempSteps;

                        // swap corresponding usernames
                        string tempName = usernames[j];
                        usernames[j] = usernames[j + 1];
                        usernames[j + 1] = tempName;
                    }
                }
            }

            Console.WriteLine("Sort Successfully");
        }

        // display leaderboard
        public void DisplayLeaderboard()
        {
            Console.WriteLine("\n--- Fitness Leaderboard ---");
            Console.WriteLine("Rank\tUsername\tSteps");

            for (int i = 0; i < numberofUser; i++)
            {
                Console.WriteLine($"{i + 1}\t{usernames[i]}\t\t{stepscount[i]}");
            }
        }
    }
}
