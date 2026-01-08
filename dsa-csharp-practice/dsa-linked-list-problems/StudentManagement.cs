/*using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{

    // Node class
    class StudentNode
    {
        public int RollNo;
        public string Name;
        public int Age;
        public string Grade;
        public StudentNode Next;

        public StudentNode(int rollNo, string name, int age, string grade)
        {
            RollNo = rollNo;
            Name = name;
            Age = age;
            Grade = grade;
            Next = null;
        }
    }

    // Linked List class
    class StudentLinkedList
    {
        private StudentNode head;

        // Add at beginning
        public void AddAtBeginning(int rollNo, string name, int age, string grade)
        {
            StudentNode newNode = new StudentNode(rollNo, name, age, grade);
            newNode.Next = head;
            head = newNode;
        }

        // Add at end
        public void AddAtEnd(int rollNo, string name, int age, string grade)
        {
            StudentNode newNode = new StudentNode(rollNo, name, age, grade);

            if (head == null)
            {
                head = newNode;
                return;
            }

            StudentNode temp = head;
            while (temp.Next != null)
                temp = temp.Next;

            temp.Next = newNode;
        }

        // Add at position
        public void AddAtPosition(int pos, int rollNo, string name, int age, string grade)
        {
            if (pos == 1)
            {
                AddAtBeginning(rollNo, name, age, grade);
                return;
            }

            StudentNode newNode = new StudentNode(rollNo, name, age, grade);
            StudentNode temp = head;

            for (int i = 1; i < pos - 1 && temp != null; i++)
                temp = temp.Next;

            if (temp == null)
            {
                Console.WriteLine("Invalid position");
                return;
            }

            newNode.Next = temp.Next;
            temp.Next = newNode;
        }

        // Delete by roll number
        public void DeleteByRollNo(int rollNo)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            if (head.RollNo == rollNo)
            {
                head = head.Next;
                Console.WriteLine("Record deleted");
                return;
            }

            StudentNode temp = head;
            while (temp.Next != null && temp.Next.RollNo != rollNo)
                temp = temp.Next;

            if (temp.Next == null)
                Console.WriteLine("Student not found");
            else
            {
                temp.Next = temp.Next.Next;
                Console.WriteLine("Record deleted");
            }
        }

        // Search
        public void SearchByRollNo(int rollNo)
        {
            StudentNode temp = head;

            while (temp != null)
            {
                if (temp.RollNo == rollNo)
                {
                    Console.WriteLine($"RollNo: {temp.RollNo}, Name: {temp.Name}, Age: {temp.Age}, Grade: {temp.Grade}");
                    return;
                }
                temp = temp.Next;
            }

            Console.WriteLine("Student not found");
        }

        // Update grade
        public void UpdateGrade(int rollNo, string grade)
        {
            StudentNode temp = head;

            while (temp != null)
            {
                if (temp.RollNo == rollNo)
                {
                    temp.Grade = grade;
                    Console.WriteLine("Grade updated");
                    return;
                }
                temp = temp.Next;
            }

            Console.WriteLine("Student not found");
        }

        // Display
        public void DisplayAll()
        {
            if (head == null)
            {
                Console.WriteLine("No records found");
                return;
            }

            StudentNode temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.RollNo} {temp.Name} {temp.Age} {temp.Grade}");
                temp = temp.Next;
            }
        }
    }

    // Main class
    class StudentManagement
    {
        static void Main()
        {
            StudentLinkedList list = new StudentLinkedList();
            int choice;

            do
            {
                Console.WriteLine("\n--- Student Management Menu ---");
                Console.WriteLine("1. Add at Beginning");
                Console.WriteLine("2. Add at End");
                Console.WriteLine("3. Add at Position");
                Console.WriteLine("4. Delete by Roll No");
                Console.WriteLine("5. Search by Roll No");
                Console.WriteLine("6. Update Grade");
                Console.WriteLine("7. Display All");
                Console.WriteLine("8. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.Write("Roll No: ");
                        int r = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name: ");
                        string n = Console.ReadLine();
                        Console.Write("Age: ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Grade: ");
                        string g = Console.ReadLine();

                        if (choice == 1)
                            list.AddAtBeginning(r, n, a, g);
                        else if (choice == 2)
                            list.AddAtEnd(r, n, a, g);
                        else
                        {
                            Console.Write("Position: ");
                            int p = Convert.ToInt32(Console.ReadLine());
                            list.AddAtPosition(p, r, n, a, g);
                        }
                        break;

                    case 4:
                        Console.Write("Enter Roll No to delete: ");
                        list.DeleteByRollNo(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 5:
                        Console.Write("Enter Roll No to search: ");
                        list.SearchByRollNo(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 6:
                        Console.Write("Enter Roll No: ");
                        int rn = Convert.ToInt32(Console.ReadLine());
                        Console.Write("New Grade: ");
                        string ng = Console.ReadLine();
                        list.UpdateGrade(rn, ng);
                        break;

                    case 7:
                        list.DisplayAll();
                        break;

                    case 8:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 8);
        }
    }

}*/