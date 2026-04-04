using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.EduResults
{
        internal class ResultUtility : IResult
        {
            private Result[] results = new Result[50];
            private int count = 0;

            public void AddStudent()
            {
                if (count >= results.Length)
                {
                    Console.WriteLine(" Student limit reached.\n");
                    return;
                }

                results[count] = new Result();

                Console.Write(" Enter Student Name: ");
                results[count].StudentName = Console.ReadLine();

                Console.WriteLine(" Student added successfully.\n");
                count++;
            }

            public void AddDistrict()
            {
                if (count == 0)
                {
                    Console.WriteLine(" No students found. Please add student first.\n");
                    return;
                }

                Console.Write(" Enter Student Name to add District: ");
                string name = Console.ReadLine();

                for (int i = 0; i < count; i++)
                {
                    if (results[i].StudentName == name)
                    {
                        Console.Write(" Enter District Name: ");
                        results[i].DistrictName = Console.ReadLine();
                        Console.WriteLine(" District added successfully.\n");
                        return;
                    }
                }

                Console.WriteLine(" Student not found.\n");
            }

            public void AddScore()
            {
                if (count == 0)
                {
                    Console.WriteLine(" No students found. Please add student first.\n");
                    return;
                }

                Console.Write(" Enter Student Name to add Score: ");
                string name = Console.ReadLine();

                for (int i = 0; i < count; i++)
                {
                    if (results[i].StudentName == name)
                    {
                        Console.Write(" Enter Score: ");
                        results[i].Score = int.Parse(Console.ReadLine());
                        Console.WriteLine(" Score added successfully.\n");
                        return;
                    }
                }

                Console.WriteLine(" Student not found.\n");
            }

            public void ViewRank()
            {
                if (count == 0)
                {
                    Console.WriteLine(" No results available to rank.\n");
                    return;
                }

                // Apply Merge Sort
                MergeSort(results, 0, count - 1);

                Console.WriteLine("\n FINAL STATE-WISE RANK LIST \n");

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"Rank {i + 1} → {results[i]}");
                }

                Console.WriteLine();
            }

            //  MERGE SORT

            private void MergeSort(Result[] arr, int left, int right)
            {
                if (left < right)
                {
                    int mid = (left + right) / 2;

                    MergeSort(arr, left, mid);
                    MergeSort(arr, mid + 1, right);

                    Merge(arr, left, mid, right);
                }
            }

            private void Merge(Result[] arr, int left, int mid, int right)
            {
                int n1 = mid - left + 1;
                int n2 = right - mid;

                Result[] L = new Result[n1];
                Result[] R = new Result[n2];

                for (int i = 0; i < n1; i++)
                    L[i] = arr[left + i];

                for (int j = 0; j < n2; j++)
                    R[j] = arr[mid + 1 + j];

                int iIndex = 0, jIndex = 0, k = left;

                // Stable merge (descending by score)
                while (iIndex < n1 && jIndex < n2)
                {
                    if (L[iIndex].Score >= R[jIndex].Score)
                    {
                        arr[k++] = L[iIndex++];
                    }
                    else
                    {
                        arr[k++] = R[jIndex++];
                    }
                }

                while (iIndex < n1)
                    arr[k++] = L[iIndex++];

                while (jIndex < n2)
                    arr[k++] = R[jIndex++];
            }
        }
    }





