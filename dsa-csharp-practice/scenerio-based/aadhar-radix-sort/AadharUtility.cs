using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.AadharNumber
{
    internal class AadharUtility:IAadhar
    {
        // Implements IAadhaarService to handle Aadhaar operations
        
            private long[] aadhaarNumbers; // Array to store Aadhaar numbers
            private int size;              // Number of Aadhaar records

            // Method to take input from user
            public void Input()
            {
                Console.Write("Enter number of Aadhaar records: ");
                size = int.Parse(Console.ReadLine());

                aadhaarNumbers = new long[size];

                // Take each Aadhaar number input
                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Enter Aadhaar {i + 1}: ");
                    aadhaarNumbers[i] = long.Parse(Console.ReadLine());
                }
            }

            // Method to display all Aadhaar numbers
            public void Display()
            {
                if (aadhaarNumbers == null)
                {
                    Console.WriteLine("No Aadhaar data available.");
                    return;
                }

                foreach (long num in aadhaarNumbers)
                    Console.WriteLine(num);
            }

            // Radix Sort implementation
            public void RadixSort()
            {
                long max = GetMax(); // Find maximum number to know number of digits

                // Sort for each digit place (1s, 10s, 100s,...)
                for (long i = 1; max / i > 0; i *= 10)
                    CountingSort(i);
            }

            // Get maximum Aadhaar number
            private long GetMax()
            {
                long max = aadhaarNumbers[0];
                foreach (long num in aadhaarNumbers)
                    if (num > max)
                        max = num;
                return max;
            }

            // Counting sort used as a subroutine for Radix Sort
            private void CountingSort(long exp)
            {
                int n = aadhaarNumbers.Length;
                long[] output = new long[n]; // Output array
                int[] count = new int[10];   // Count array for digits 0-9

                // Count occurrences of each digit
                for (int i = 0; i < n; i++)
                {
                    int digit = (int)((aadhaarNumbers[i] / exp) % 10);
                    count[digit]++;
                }

                // Update count[i] to store cumulative count
                for (int i = 1; i < 10; i++)
                    count[i] += count[i - 1];

                // Build output array in a stable manner
                for (int i = n - 1; i >= 0; i--)
                {
                    int digit = (int)((aadhaarNumbers[i] / exp) % 10);
                    output[count[digit] - 1] = aadhaarNumbers[i];
                    count[digit]--;
                }

                // Copy sorted values back to original array
                for (int i = 0; i < n; i++)
                    aadhaarNumbers[i] = output[i];
            }

            // Binary Search to find a specific Aadhaar number
            public void BinarySearch()
            {
                Console.Write("Enter Aadhaar number to search: ");
                long key = long.Parse(Console.ReadLine());
                int left = 0, right = aadhaarNumbers.Length - 1;

                while (left <= right)
                {
                    int mid = (left + right) / 2;

                    if (aadhaarNumbers[mid] == key)
                    {
                        Console.WriteLine($"Aadhaar found at index {mid}");
                        return;
                    }
                    else if (aadhaarNumbers[mid] < key)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

                Console.WriteLine("Aadhaar not found");
            }
        }
    }
