using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{
    
         // Node class represents one task
        class TaskNode
        {
            public int TaskId;
            public string TaskName;
            public int Priority;
            public string DueDate;
            public TaskNode Next;

            // Constructor to initialize task details
            public TaskNode(int taskId, string taskName, int priority, string dueDate)
            {
                TaskId = taskId;
                TaskName = taskName;
                Priority = priority;
                DueDate = dueDate;
                Next = null;
            }
        }

        class TaskScheduler
        {
            private TaskNode head;
            private TaskNode current; // used to track current task

            // Add task at the beginning
            public void AddAtBeginning()
            {
                TaskNode newNode = CreateTask();

                if (head == null)
                {
                    head = newNode;
                    newNode.Next = head;
                    current = head;
                }
                else
                {
                    TaskNode temp = head;
                    while (temp.Next != head)
                    {
                        temp = temp.Next;
                    }

                    newNode.Next = head;
                    temp.Next = newNode;
                    head = newNode;
                }

                Console.WriteLine("Task added at the beginning.\n");
            }

            // Add task at the end
            public void AddAtEnd()
            {
                TaskNode newNode = CreateTask();

                if (head == null)
                {
                    head = newNode;
                    newNode.Next = head;
                    current = head;
                }
                else
                {
                    TaskNode temp = head;
                    while (temp.Next != head)
                    {
                        temp = temp.Next;
                    }

                    temp.Next = newNode;
                    newNode.Next = head;
                }

                Console.WriteLine("Task added at the end.\n");
            }

            // Add task at a specific position
            public void AddAtPosition()
            {
                Console.Write("Enter position: ");
                int position = int.Parse(Console.ReadLine());

                if (position <= 0)
                {
                    Console.WriteLine("Invalid position.\n");
                    return;
                }

                if (position == 1)
                {
                    AddAtBeginning();
                    return;
                }

                TaskNode newNode = CreateTask();
                TaskNode temp = head;

                for (int i = 1; i < position - 1 && temp.Next != head; i++)
                {
                    temp = temp.Next;
                }

                newNode.Next = temp.Next;
                temp.Next = newNode;

                Console.WriteLine("Task added at given position.\n");
            }

            // Remove task by Task ID
            public void RemoveByTaskId()
            {
                if (head == null)
                {
                    Console.WriteLine("No tasks available.\n");
                    return;
                }

                Console.Write("Enter Task ID to remove: ");
                int id = int.Parse(Console.ReadLine());

                TaskNode temp = head;
                TaskNode prev = null;

                do
                {
                    if (temp.TaskId == id)
                    {
                        if (temp == head)
                        {
                            TaskNode last = head;
                            while (last.Next != head)
                            {
                                last = last.Next;
                            }

                            head = head.Next;
                            last.Next = head;
                        }
                        else
                        {
                            prev.Next = temp.Next;
                        }

                        Console.WriteLine("Task removed successfully.\n");
                        return;
                    }

                    prev = temp;
                    temp = temp.Next;

                } while (temp != head);

                Console.WriteLine("Task not found.\n");
            }

            // View current task and move to next
            public void ViewCurrentAndNext()
            {
                if (current == null)
                {
                    Console.WriteLine("No tasks available.\n");
                    return;
                }

                Console.WriteLine("Current Task:");
                DisplayTask(current);

                current = current.Next;
                Console.WriteLine("Moved to next task.\n");
            }

            // Display all tasks
            public void DisplayAllTasks()
            {
                if (head == null)
                {
                    Console.WriteLine("No tasks available.\n");
                    return;
                }

                TaskNode temp = head;
                Console.WriteLine("All Tasks:\n");

                do
                {
                    DisplayTask(temp);
                    temp = temp.Next;
                } while (temp != head);
            }

            // Search task by priority
            public void SearchByPriority()
            {
                if (head == null)
                {
                    Console.WriteLine("No tasks available.\n");
                    return;
                }

                Console.Write("Enter priority to search: ");
                int priority = int.Parse(Console.ReadLine());

                TaskNode temp = head;
                bool found = false;

                do
                {
                    if (temp.Priority == priority)
                    {
                        DisplayTask(temp);
                        found = true;
                    }
                    temp = temp.Next;
                } while (temp != head);

                if (!found)
                {
                    Console.WriteLine("No task found with this priority.\n");
                }
            }

            // Helper method to create task using user input
            private TaskNode CreateTask()
            {
                Console.Write("Enter Task ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Task Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Priority: ");
                int priority = int.Parse(Console.ReadLine());

                Console.Write("Enter Due Date: ");
                string dueDate = Console.ReadLine();

                return new TaskNode(id, name, priority, dueDate);
            }

            // Helper method to display one task
            private void DisplayTask(TaskNode task)
            {
                Console.WriteLine("Task ID   : " + task.TaskId);
                Console.WriteLine("Task Name : " + task.TaskName);
                Console.WriteLine("Priority  : " + task.Priority);
                Console.WriteLine("Due Date  : " + task.DueDate);
                Console.WriteLine();
            }
        }

        internal class TaskSchedulers
        {
            public static void Main(string[] args)
            {
                TaskScheduler scheduler = new TaskScheduler();
                int choice;

                do
                {
                    Console.WriteLine(" Task Scheduler ");
                    Console.WriteLine("1. Add Task at Beginning");
                    Console.WriteLine("2. Add Task at End");
                    Console.WriteLine("3. Add Task at Specific Position");
                    Console.WriteLine("4. Remove Task by ID");
                    Console.WriteLine("5. View Current Task and Move Next");
                    Console.WriteLine("6. Display All Tasks");
                    Console.WriteLine("7. Search Task by Priority");
                    Console.WriteLine("8. Exit");
                    Console.Write("Enter your choice: ");

                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1: scheduler.AddAtBeginning(); break;
                        case 2: scheduler.AddAtEnd(); break;
                        case 3: scheduler.AddAtPosition(); break;
                        case 4: scheduler.RemoveByTaskId(); break;
                        case 5: scheduler.ViewCurrentAndNext(); break;
                        case 6: scheduler.DisplayAllTasks(); break;
                        case 7: scheduler.SearchByPriority(); break;
                        case 8: Console.WriteLine("Program closed."); break;
                        default: Console.WriteLine("Invalid choice.\n"); break;
                    }

                } while (choice != 8);
            }
        }
    }

