using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.passwordCracker
{
    internal class Vault
    {
        
            private string secretPassword;

            public Vault(string password)
            {
                secretPassword = password;
            }

            // Checks if guessed password is correct
            public bool IsUnlocked(string attempt)
            {
                return secretPassword.Equals(attempt);
            }
        }

    }

