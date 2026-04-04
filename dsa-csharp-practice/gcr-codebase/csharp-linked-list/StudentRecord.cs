using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{
        // Node class represents a single student record
        class StudentNode
        {
            public int RollNo;
            public string Name;
            public int Age;
            public string Grade;
            public StudentNode Next;

            // Constructor to initialize student details
            public StudentNode(int rollNo, string name, int age, string grade)
            {
                RollNo = rollNo;
                Name = name;
                Age = age;
                Grade = grade;
                Next = null;
            }
        }

        class StudentLinkedList
        {
            private StudentNode head;

            // Add student at the beginning
            public void AddAtBeginning()
            {
                Console.Write("Enter Roll Number: ");
                int roll = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine();

                StudentNode newNode = new StudentNode(roll, name, age, grade);
                newNode.Next = head;
                head = newNode;

                Console.WriteLine(" Student added at the beginning.\n");
            }

            // Add student at the end
            public void AddAtEnd()
            {
                Console.Write("Enter Roll Number: ");
                int roll = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine();

                StudentNode newNode = new StudentNode(roll, name, age, grade);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    StudentNode temp = head;
                    while (temp.Next != null)
                    {
                        temp = temp.Next;
                    }
                    temp.Next = newNode;
                }

                Console.WriteLine(" Student added at the end.\n");
            }

            // Add student at a specific position
            public void AddAtPosition()
            {
                Console.Write("Enter Position: ");
                int position = int.Parse(Console.ReadLine());

                if (position <= 0)
                {
                    Console.WriteLine(" Invalid position.\n");
                    return;
                }

                Console.Write("Enter Roll Number: ");
                int roll = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Grade: ");
                string grade = Console.ReadLine();

                StudentNode newNode = new StudentNode(roll, name, age, grade);

                if (position == 1)
                {
                    newNode.Next = head;
                    head = newNode;
                    Console.WriteLine(" Student added at position 1.\n");
                    return;
                }

                StudentNode temp = head;
                for (int i = 1; i < position - 1 && temp != null; i++)
                {
                    temp = temp.Next;
                }

                if (temp == null)
                {
                    Console.WriteLine(" Position out of range.\n");
                }
                else
                {
                    newNode.Next = temp.Next;
                    temp.Next = newNode;
                    Console.WriteLine(" Student added at given position.\n");
                }
            }

            // Delete student by roll number
            public void DeleteByRollNo()
            {
                Console.Write("Enter Roll Number to delete: ");
                int roll = int.Parse(Console.ReadLine());

                if (head == null)
                {
                    Console.WriteLine(" List is empty.\n");
                    return;
                }

                if (head.RollNo == roll)
                {
                    head = head.Next;
                    Console.WriteLine(" Student record deleted.\n");
                    return;
                }

                StudentNode temp = head;
                while (temp.Next != null && temp.Next.RollNo != roll)
                {
                    temp = temp.Next;
                }

                if (temp.Next == null)
                {
                    Console.WriteLine(" Student not found.\n");
                }
                else
                {
                    temp.Next = temp.Next.Next;
                    Console.WriteLine(" Student record deleted.\n");
                }
            }

            // Search student by roll number
            public void SearchByRollNo()
            {
                Console.Write("Enter Roll Number to search: ");
                int roll = int.Parse(Console.ReadLine());

                StudentNode temp = head;

                while (temp != null)
                {
                    if (temp.RollNo == roll)
                    {
                        Console.WriteLine("\n Student Found:");
                        Console.WriteLine($"Roll No: {temp.RollNo}");
                        Console.WriteLine($"Name: {temp.Name}");
                        Console.WriteLine($"Age: {temp.Age}");
                        Console.WriteLine($"Grade: {temp.Grade}\n");
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine(" Student not found.\n");
            }

            // Update student grade
            public void UpdateGrade()
            {
                Console.Write("Enter Roll Number: ");
                int roll = int.Parse(Console.ReadLine());

                StudentNode temp = head;

                while (temp != null)
                {
                    if (temp.RollNo == roll)
                    {
                        Console.Write("Enter new Grade: ");
                        temp.Grade = Console.ReadLine();
                        Console.WriteLine(" Grade updated successfully.\n");
                        return;
                    }
                    temp = temp.Next;
                }

                Console.WriteLine(" Student not found.\n");
            }

            // Display all students
            public void DisplayAll()
            {
                if (head == null)
                {
                    Console.WriteLine(" No student records available.\n");
                    return;
                }

                StudentNode temp = head;
                Console.WriteLine("\n Student Records:");
                while (temp != null)
                {
                    Console.WriteLine($"Roll No: {temp.RollNo}");
                    Console.WriteLine($"Name   : {temp.Name}");
                    Console.WriteLine($"Age    : {temp.Age}");
                    Console.WriteLine($"Grade  : {temp.Grade}");
                    temp = temp.Next;
                }
                Console.WriteLine();
            }
        }

       internal class StudentRecord
        {
            public static void Main(string[] args)
            {
                StudentLinkedList list = new StudentLinkedList();
                int choice;

                do
                {
                    Console.WriteLine(" Student Record Management ");
                    Console.WriteLine("1. Add Student at Beginning");
                    Console.WriteLine("2. Add Student at End");
                    Console.WriteLine("3. Add Student at Specific Position");
                    Console.WriteLine("4. Delete Student by Roll Number");
                    Console.WriteLine("5. Search Student by Roll Number");
                    Console.WriteLine("6. Update Student Grade");
                    Console.WriteLine("7. Display All Students");
                    Console.WriteLine("8. Exit");
                    Console.Write("Enter your choice: ");

                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1: list.AddAtBeginning(); break;
                        case 2: list.AddAtEnd(); break;
                        case 3: list.AddAtPosition(); break;
                        case 4: list.DeleteByRollNo(); break;
                        case 5: list.SearchByRollNo(); break;
                        case 6: list.UpdateGrade(); break;
                        case 7: list.DisplayAll(); break;
                        case 8: Console.WriteLine(" Thank you! Exiting program."); break;
                        default: Console.WriteLine(" Invalid choice. Try again.\n"); break;
                    }

                } while (choice != 8);
            }
        }
    }


