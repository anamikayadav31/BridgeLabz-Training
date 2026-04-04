using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class FindRotationPoint
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

                       // Binary search to find index of smallest element
                        while (low < high)
                        {
                            int mid = (low + high) / 2;

                    // Decide which half to search
                    if (arr[mid] > arr[high])
                    {
                        low = mid + 1;
                    }
                    else { 
                        high = mid;
                     }

                       Console.WriteLine("Index of smallest element (rotation point): " + low);
                    }
                }

            }
        }
    
