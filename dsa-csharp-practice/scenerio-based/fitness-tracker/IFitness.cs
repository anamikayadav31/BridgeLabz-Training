using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.fitnessTracker
{
        internal interface IFitness
        {
            void AddUser();          // Add new user
            void ShowSteps();        // Show steps of all users
            void ShowLeaderBoard();  // Show sorted leaderboard
        }
    }


