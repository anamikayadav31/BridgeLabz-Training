using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{
   

    // Node class
    class ProcessNode
    {
        public int ProcessId;
        public int BurstTime;
        public int RemainingTime;
        public int Priority;
        public int WaitingTime;
        public int TurnAroundTime;
        public ProcessNode Next;

        // Constructor
        public ProcessNode(int id, int burst, int priority)
        {
            ProcessId = id;
            BurstTime = burst;
            RemainingTime = burst;
            Priority = priority;
            Next = null;
        }
    }

    // Circular Linked List class
    class RoundRobinList
    {
        private ProcessNode head = null;
        private ProcessNode tail = null;

        // Add process at end
        public void AddProcess(int id, int burst, int priority)
        {
            ProcessNode node = new ProcessNode(id, burst, priority);

            if (head == null)
            {
                head = tail = node;
                node.Next = head;
            }
            else
            {
                tail.Next = node;
                node.Next = head;
                tail = node;
            }
            Console.WriteLine("Process added.");
        }

        // Display all processes
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("No processes.");
                return;
            }

            ProcessNode temp = head;
            do
            {
                Console.WriteLine($"PID: {temp.ProcessId}, Remaining: {temp.RemainingTime}");
                temp = temp.Next;
            } while (temp != head);
        }

        // Round Robin Scheduling
        public void Schedule(int timeQuantum)
        {
            if (head == null) return;

            int time = 0;
            int count = CountProcesses();
            int completed = 0;

            while (completed < count)
            {
                ProcessNode temp = head;
                do
                {
                    if (temp.RemainingTime > 0)
                    {
                        int execTime = Math.Min(timeQuantum, temp.RemainingTime);
                        temp.RemainingTime -= execTime;
                        time += execTime;

                        // If process completes
                        if (temp.RemainingTime == 0)
                        {
                            temp.TurnAroundTime = time;
                            temp.WaitingTime = temp.TurnAroundTime - temp.BurstTime;
                            completed++;
                        }
                    }
                    temp = temp.Next;
                } while (temp != head);

                Console.WriteLine("\nProcesses after this round:");
                Display();
            }

            CalculateAverageTime();
        }

        // Count processes
        private int CountProcesses()
        {
            if (head == null) return 0;
            int count = 0;
            ProcessNode temp = head;
            do
            {
                count++;
                temp = temp.Next;
            } while (temp != head);
            return count;
        }

        // Calculate average waiting & turnaround time
        private void CalculateAverageTime()
        {
            double totalWT = 0, totalTAT = 0;
            int count = CountProcesses();

            ProcessNode temp = head;
            do
            {
                totalWT += temp.WaitingTime;
                totalTAT += temp.TurnAroundTime;
                temp = temp.Next;
            } while (temp != head);

            Console.WriteLine("\nAverage Waiting Time: " + (totalWT / count));
            Console.WriteLine("Average Turnaround Time: " + (totalTAT / count));
        }
    }

    // MAIN CLASS
    class RoundRobinSchedulingAlgorithm
    {
        static void Main()
        {
            RoundRobinList list = new RoundRobinList();

            Console.Write("Enter number of processes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("\nProcess ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Burst Time: ");
                int burst = int.Parse(Console.ReadLine());
                Console.Write("Priority: ");
                int priority = int.Parse(Console.ReadLine());

                list.AddProcess(id, burst, priority);
            }

            Console.Write("\nEnter Time Quantum: ");
            int tq = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Round Robin Scheduling Start ---");
            list.Schedule(tq);
        }
    }

}
