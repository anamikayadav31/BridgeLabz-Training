using BridgeLabzTraining.oops.sceneriobased.fitnessTracker;
using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.employeeWage
{

    using System.Collections.Generic;

    // Stores user details
    public class UserProfile(string userName, int age)
    {
        public string UserName { get; set; } = userName;
        public int Age { get; set; } = age;

        private List<Workout> workouts = new();

        public void AddWorkout(Workout workout)
        {
            workouts.Add(workout);
        }

        public void ShowWorkoutHistory()
        {
            Console.WriteLine($"\nWorkout History of {UserName}");
            foreach (var workout in workouts)
            {
                workout.DisplayWorkoutDetails();
            }
        }
    }
}