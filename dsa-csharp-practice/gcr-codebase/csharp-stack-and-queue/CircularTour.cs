using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.stackAndQueue
{
    internal class CircularTour
    {
            public static int FindStartingPump(int[] petrol, int[] distance, int n)
            {
                Queue<int> queue = new Queue<int>();
                int balance = 0;
                int start = 0;

                for (int i = 0; i < n; i++)
                {
                    int surplus = petrol[i] - distance[i];
                    balance += surplus;
                    queue.Enqueue(i);

                    // If balance becomes negative, reset tour
                    while (balance < 0 && queue.Count > 0)
                    {
                        int removed = queue.Dequeue();
                        balance -= (petrol[removed] - distance[removed]);
                        start = removed + 1;
                    }
                }

                // If all pumps are considered
                if (queue.Count == n)
                {
                    return start;
                }

                return -1;
            }

            public static void Main(string[] args)
            {
                Console.Write("Enter number of petrol pumps: ");
                int n = int.Parse(Console.ReadLine());

                int[] petrol = new int[n];
                int[] distance = new int[n];

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter petrol at pump " + i + ": ");
                    petrol[i] = int.Parse(Console.ReadLine());

                    Console.Write("Enter distance from pump " + i + " to next pump: ");
                    distance[i] = int.Parse(Console.ReadLine());
                }

                int startIndex = FindStartingPump(petrol, distance, n);

                if (startIndex == -1)
                {
                    Console.WriteLine("No possible circular tour");
                }
                else
                {
                    Console.WriteLine("Start tour from petrol pump index: " + startIndex);
                }
            }
        }
    }



