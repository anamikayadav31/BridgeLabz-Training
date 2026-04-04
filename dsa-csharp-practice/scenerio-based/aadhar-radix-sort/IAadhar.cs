using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.AadharNumber
{
    // Interface defining methods for Aadhaar number operations
    internal interface IAadhar
    {
        void Input();         // Method to take Aadhaar numbers input from user
        void Display();       // Method to display all Aadhaar numbers
        void RadixSort();     // Method to sort Aadhaar numbers using Radix Sort
        void BinarySearch();  // Method to search a number using Binary Search
    }
}
