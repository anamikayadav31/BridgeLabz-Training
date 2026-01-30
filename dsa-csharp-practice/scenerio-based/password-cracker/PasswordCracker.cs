using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.passwordCracker
{
    internal class PasswordCracker
    {
        private Vault vault;
            private bool isFound = false;

            // Possible characters for password
            private char[] chars = { 'a', 'b', 'c' };

            public PasswordCracker(Vault vault)
            {
                this.vault = vault;
            }

            // Starts cracking process
            public void StartCracking(int length)
            {
                Generate("", length);
            }

            // Recursive backtracking function
            private void Generate(string current, int maxLength)
            {
                if (isFound) return; // Stop if password found

                if (current.Length == maxLength)
                {
                    AttemptChecker.Check(current, vault, ref isFound);
                    return;
                }

                foreach (char c in chars)
                {
                    Generate(current + c, maxLength);
                }
            }
        }

    }

