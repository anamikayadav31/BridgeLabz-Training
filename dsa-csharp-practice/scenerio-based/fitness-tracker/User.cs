using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.fitnessTracker
{
        internal class User
        {
            private string name;   // User name
            private int steps;     // Step count

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Steps
            {
                get { return steps; }
                set { steps = value; }
            }

            // Constructor to initialize user data
            public User(string name, int steps)
            {
                Name = name;
                Steps = steps;
            }

            // Displays user information
            public override string ToString()
            {
                return "Name: " + Name + ", Steps: " + Steps;
            }
        }
    }



