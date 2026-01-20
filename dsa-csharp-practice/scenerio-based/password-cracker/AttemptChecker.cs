using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.passwordCracker
{
    internal class AttemptChecker
    {




        // Checks each generated password
        public static void Check(string attempt, Vault vault, ref bool isFound)
        {
            Console.WriteLine("Trying: " + attempt);

            if (vault.IsUnlocked(attempt))
            {
                Console.WriteLine(" Password Found: " + attempt);
                isFound = true;
            }
        }
    }
}