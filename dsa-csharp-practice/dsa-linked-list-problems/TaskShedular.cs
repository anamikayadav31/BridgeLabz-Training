using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{



    // Node class
    class TaskNode
    {
        public int TaskId;
        public string TaskName;
        public string Priority;
        public string DueDate;
        public TaskNode Next;

        // Constructor
        public TaskNode(int id, string name, string priority, string date)
        {
            TaskId = id;
            TaskName = name;
            Priority = priority;
            DueDate = date;
            Next = null;
        }
    }

    // Circular Linked List class
    class TaskList
    {
        private TaskNode head;
        private TaskNode current;

        // Add task at beginning
        public void AddAtBeginning(int id, string name, string priority, string date)
        {
            TaskNode node = new TaskNode(id, name, priority, date);

            if (head == null)
            {
                head = node;
                node.Next = head;
            }
            else
            {
                TaskNode temp = head;
                while (temp.Next != head)
                    temp = temp.Next;

                node.Next = head;
                temp.Next = node;
                head = node;
            }
            Console.WriteLine("Task added at beginning.");
        }

        // Add task at end
        public void AddAtEnd(int id, string name, string priority, string date)
        {
            TaskNode node = new TaskNode(id, name, priority, date);

            if (head == null)
            {
                head = node;
                node.Next = head;
            }
            else
            {
                TaskNode temp = head;
                while (temp.Next != head)
                    temp = temp.Next;

                temp.Next = node;
                node.Next = head;
            }
            Console.WriteLine("Task added at end.");
        }

        // Add task at specific position
        public void AddAtPosition(int id, string name, string priority, string date, int pos)
        {
            if (pos <= 1)
            {
                AddAtBeginning(id, name, priority, date);
                return;
            }

            TaskNode temp = head;
            for (int i = 1; i < pos - 1 && temp.Next != head; i++)
                temp = temp.Next;

            TaskNode node = new TaskNode(id, name, priority, date);
            node.Next = temp.Next;
            temp.Next = node;

            Console.WriteLine("Task added at position " + pos);
        }

        // Remove task by Task ID
        public void RemoveById(int id)
        {
            if (head == null)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            TaskNode curr = head, prev = null;

            do
            {
                if (curr.TaskId == id)
                {
                    if (curr == head)
                    {
                        TaskNode temp = head;
                        while (temp.Next != head)
                            temp = temp.Next;

                        head = head.Next;
                        temp.Next = head;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                    }
                    Console.WriteLine("Task removed.");
                    return;
                }
                prev = curr;
                curr = curr.Next;

            } while (curr != head);

            Console.WriteLine("Task not found.");
        }

        // View current task and move to next
        public void ViewNextTask()
        {
            if (head == null)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            if (current == null)
                current = head;

            DisplayTask(current);
            current = current.Next;
        }

        // Display all tasks
        public void DisplayAll()
        {
            if (head == null)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            TaskNode temp = head;
            do
            {
                DisplayTask(temp);
                temp = temp.Next;
            } while (temp != head);
        }

        // Search task by priority
        public void SearchByPriority(string priority)
        {
            if (head == null)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            TaskNode temp = head;
            bool found = false;

            do
            {
                if (temp.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase))
                {
                    DisplayTask(temp);
                    found = true;
                }
                temp = temp.Next;
            } while (temp != head);

            if (!found)
                Console.WriteLine("No task found with this priority.");
        }

        // Display single task
        private void DisplayTask(TaskNode t)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("Task ID   : " + t.TaskId);
            Console.WriteLine("Task Name : " + t.TaskName);
            Console.WriteLine("Priority  : " + t.Priority);
            Console.WriteLine("Due Date  : " + t.DueDate);
        }
    }

    // MAIN CLASS
    class TaskShedular
    {
        static void Main()
        {
            TaskList list = new TaskList();
            int choice;

            do
            {
                Console.WriteLine("\n--- Task Scheduler ---");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Remove Task");
                Console.WriteLine("3. View Current & Next Task");
                Console.WriteLine("4. Display All Tasks");
                Console.WriteLine("5. Search by Priority");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Task ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Task Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Priority: ");
                        string priority = Console.ReadLine();
                        Console.Write("Due Date: ");
                        string date = Console.ReadLine();
                        Console.Write("Position (1-Begin, 2-End, else index): ");
                        int pos = int.Parse(Console.ReadLine());

                        if (pos == 1)
                            list.AddAtBeginning(id, name, priority, date);
                        else if (pos == 2)
                            list.AddAtEnd(id, name, priority, date);
                        else
                            list.AddAtPosition(id, name, priority, date, pos);
                        break;

                    case 2:
                        Console.Write("Enter Task ID: ");
                        list.RemoveById(int.Parse(Console.ReadLine()));
                        break;

                    case 3:
                        list.ViewNextTask();
                        break;

                    case 4:
                        list.DisplayAll();
                        break;

                    case 5:
                        Console.Write("Enter Priority: ");
                        list.SearchByPriority(Console.ReadLine());
                        break;
                }

            } while (choice != 0);
        }
    }

}