using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.scenerioBased.adharNumber
{


    // Interface defining methods for Aadhaar number operations
    internal interface IAadhaarService
    {
        void Input();         // Method to take Aadhaar numbers input from user
        void Display();       // Method to display all Aadhaar numbers
        void RadixSort();     // Method to sort Aadhaar numbers using Radix Sort
        void BinarySearch();  // Method to search a number using Binary Search
    }
}