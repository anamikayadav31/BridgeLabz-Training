using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{
          // node for process
        class ProcessNode
        {
            public int ProcessId;
            public int BurstTime;
            public int RemainingTime;
            public int Priority;
            public ProcessNode Next;

            // constructor
            public ProcessNode(int id, int burst, int priority)
            {
                ProcessId = id;
                BurstTime = burst;
                RemainingTime = burst;
                Priority = priority;
                Next = null;
            }
        }

        // round robin scheduler
        class RoundRobinScheduler
        {
            private ProcessNode tail;

            // add process at end
            public void AddProcess(int id, int burst, int priority)
            {
                ProcessNode newNode = new ProcessNode(id, burst, priority);

                if (tail == null)
                {
                    tail = newNode;
                    tail.Next = tail;
                    return;
                }

                newNode.Next = tail.Next;
                tail.Next = newNode;
                tail = newNode;
            }

            // remove process by id
            public void RemoveProcess(int id)
            {
                if (tail == null) return;

                ProcessNode curr = tail.Next;
                ProcessNode prev = tail;

                do
                {
                    if (curr.ProcessId.Equals(id))
                    {
                        if (curr.Equals(tail) && curr.Equals(tail.Next))
                        {
                            tail = null;
                        }
                        else
                        {
                            prev.Next = curr.Next;
                            if (curr.Equals(tail))
                                tail = prev;
                        }
                        return;
                    }

                    prev = curr;
                    curr = curr.Next;

                } while (!curr.Equals(tail.Next));
            }

            // display process queue
            public void DisplayQueue()
            {
                if (tail == null)
                {
                    Console.WriteLine("Queue is empty");
                    return;
                }

                ProcessNode temp = tail.Next;
                Console.Write("Queue: ");

                do
                {
                    Console.Write("P" + temp.ProcessId +
                                  "(Remaining " + temp.RemainingTime + ") ");
                    temp = temp.Next;

                } while (!temp.Equals(tail.Next));

                Console.WriteLine();
            }

            // run round robin scheduling
            public void StartScheduling(int timeQuantum)
            {
                if (tail == null)
                {
                    Console.WriteLine("No processes available");
                    return;
                }

                int currentTime = 0;
                int totalWaiting = 0;
                int totalTurnaround = 0;
                int processCount = CountProcesses();

                ProcessNode curr = tail.Next;

                while (tail != null)
                {
                    if (curr.RemainingTime > 0)
                    {
                        int executeTime = Math.Min(timeQuantum, curr.RemainingTime);
                        curr.RemainingTime -= executeTime;
                        currentTime += executeTime;

                        Console.WriteLine(
                            "Process P" + curr.ProcessId +
                            " executed for " + executeTime + " units");

                        DisplayQueue();

                        if (curr.RemainingTime == 0)
                        {
                            int turnaround = currentTime;
                            int waiting = turnaround - curr.BurstTime;

                            totalTurnaround += turnaround;
                            totalWaiting += waiting;

                            int finishedId = curr.ProcessId;
                            curr = curr.Next;
                            RemoveProcess(finishedId);
                            continue;
                        }
                    }

                    curr = curr.Next;
                }

                Console.WriteLine("Average Waiting Time: " +
                    (double)totalWaiting / processCount);

                Console.WriteLine("Average Turnaround Time: " +
                    (double)totalTurnaround / processCount);
            }

            // count processes
            private int CountProcesses()
            {
                if (tail == null) return 0;

                int count = 0;
                ProcessNode temp = tail.Next;

                do
                {
                    count++;
                    temp = temp.Next;

                } while (!temp.Equals(tail.Next));

                return count;
            }
        }

        // main class
        internal class RoundRobin
        {
            public static void Main(string[] args)
            {
                RoundRobinScheduler scheduler = new RoundRobinScheduler();
                int choice;

                do
                {
                    Console.WriteLine("\nRound Robin Menu");
                    Console.WriteLine("1 Add Process");
                    Console.WriteLine("2 Display Queue");
                    Console.WriteLine("3 Start Scheduling");
                    Console.WriteLine("0 Exit");
                    Console.Write("Enter choice: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Process ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Burst Time: ");
                            int burst = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Priority: ");
                            int priority = Convert.ToInt32(Console.ReadLine());

                            scheduler.AddProcess(id, burst, priority);
                            break;

                        case 2:
                            scheduler.DisplayQueue();
                            break;

                        case 3:
                            Console.Write("Time Quantum: ");
                            int tq = Convert.ToInt32(Console.ReadLine());
                            scheduler.StartScheduling(tq);
                            break;
                    }

                } while (!choice.Equals(0));
            }
        }
    }



