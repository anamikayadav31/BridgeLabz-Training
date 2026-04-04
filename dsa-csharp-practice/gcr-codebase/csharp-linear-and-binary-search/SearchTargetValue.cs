using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linearBinarySearch
{
    internal class SearchTargetValue
    {
               public static void Main(string[] args)
                {
                    // Read matrix dimensions
                    Console.Write("Enter number of rows: ");
                    int rows = int.Parse(Console.ReadLine());
                   Console.Write("Enter number of columns: ");
                    int cols = int.Parse(Console.ReadLine());

                    int[,] matrix = new int[rows, cols];

                    // Read matrix elements
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Console.Write($"Enter element at ({i},{j}): ");
                            matrix[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    // Read target value
                    Console.Write("Enter target value to search: ");
                    int target = int.Parse(Console.ReadLine());

                    bool found = false;

                    // Loop through each row 
                    for (int i = 0; i < rows; i++)
                    {
                        int low = 0;
                        int high = cols - 1;

                        // Binary search in the row
                        while (low <= high)
                        {
                            int mid = (low + high) / 2;
                            if (matrix[i, mid] == target)
                            {
                                found = true;
                                Console.WriteLine($"Target found at row {i}, column {mid}");
                                break;
                            }
                            else if (matrix[i, mid] < target)
                                low = mid + 1;
                            else
                                high = mid - 1;
                        }

                        if (found)
                            break;
                    }

                    if (!found)
                        Console.WriteLine("Target not found in the matrix");
                }
            }
        }
 

