using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class FindPeakElement
    {
           public static void Main(string[] args)
                {
                    // Read array size from user
                   Console.Write("Enter size of array: ");
                    int n = int.Parse(Console.ReadLine());
                    int[] arr = new int[n];

                    // Read array elements
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Enter element " + (i + 1) + ": ");
                        arr[i] = int.Parse(Console.ReadLine());
                    }

                    int low = 0;
                    int high = n - 1;

                    // Binary search for peak element
                    while (low < high)
                    {
                        int mid = (low + high) / 2;

                        // If mid element is smaller than next, peak is on right
                        if (arr[mid] < arr[mid + 1])
                            low = mid + 1;
                        else
                            high = mid; // Peak is on left or mid
                    }

                    Console.WriteLine("Peak element is: " + arr[low]);
                }
            }

        }
 

