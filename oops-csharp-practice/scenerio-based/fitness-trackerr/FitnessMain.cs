using BridgeLabzTraining.oops.sceneriobased.employeeWage;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.fitnessTracker
{
    internal class FitnessMain
    {


        static void Main()
        {
            // Take user details
            Console.Write("Enter User Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            // Create user profile
            UserProfile user = new UserProfile(name, age);

            // Number of workouts
            Console.Write("How many workouts do you want to add? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\n1. Cardio Workout");
                Console.WriteLine("2. Strength Workout");
                Console.Write("Choose workout type: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Write("Enter Workout Name: ");
                string workoutName = Console.ReadLine();

                Console.Write("Enter Duration (minutes): ");
                int duration = int.Parse(Console.ReadLine());

                // Cardio workout
                if (choice == 1)
                {
                    Console.Write("Enter Distance (km): ");
                    double distance = double.Parse(Console.ReadLine());

                    user.AddWorkout(new CardioWorkout(workoutName, duration, distance));
                }
                // Strength workout
                else if (choice == 2)
                {
                    Console.Write("Enter Sets: ");
                    int sets = int.Parse(Console.ReadLine());

                    Console.Write("Enter Reps per Set: ");
                    int reps = int.Parse(Console.ReadLine());

                    user.AddWorkout(new StrengthWorkout(workoutName, duration, sets, reps));
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    i--; // retry
                }
            }

            // Display workout history
            user.ShowWorkoutHistory();
        }
    }
}