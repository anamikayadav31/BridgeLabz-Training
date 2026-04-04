using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.passwordCracker
{
    internal class ComplexityVisualizer
    {
            public static void Show()
            {
                Console.WriteLine("\n--- Complexity Analysis ---");
                Console.WriteLine("Time Complexity: O(k^n)");
                Console.WriteLine("k = number of possible characters");
                Console.WriteLine("n = password length");
                Console.WriteLine("Space Complexity: O(n) due to recursion stack");
            }
        }

    }


