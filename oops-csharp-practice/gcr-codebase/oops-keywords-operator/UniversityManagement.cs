using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.oopsKeywordsOperator
{
    internal class UniversityManagement
    {


        // Static variable: shared by all students
        public static string UniversityName;

        // Static variable to keep track of total students
        private static int TotalStudents = 0;

        // Read-only roll number: cannot be changed after creation
        public readonly int RollNumber;

        // Student details
        public string StudentName;
        public char Grade;

        // Constructor to initialize student details
        public UniversityManagement(int rollNumber, string studentName, char grade)
        {
            this.RollNumber = rollNumber;   // 'this' refers to current object
            this.StudentName = studentName;
            this.Grade = grade;

            // Increase total student count
            TotalStudents++;
        }

        // Static method to display total number of students
        public static void ShowTotalStudents()
        {
            Console.WriteLine("Total Students: " + TotalStudents);
        }

        // Method to display student details
        public void ShowStudentDetails()
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine("University Name : " + UniversityName);
            Console.WriteLine("Roll Number     : " + RollNumber);
            Console.WriteLine("Student Name    : " + StudentName);
            Console.WriteLine("Grade           : " + Grade);
        }

        // Method to update student's grade
        public void UpdateGrade(char newGrade)
        {
            Grade = newGrade;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Ask user for university name
            Console.Write("Enter University Name: ");
            UniversityManagement.UniversityName = Console.ReadLine();

            Console.WriteLine();

            // Ask user for student details
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Grade: ");
            char grade = char.Parse(Console.ReadLine());

            // Create a student object
            UniversityManagement student = new UniversityManagement(roll, name, grade);

            Console.WriteLine();

            // Check object type using 'is' keyword
            if (student is UniversityManagement)
            {
                Console.WriteLine("Valid Student Object");
                student.ShowStudentDetails();

                // Ask for new grade to update
                Console.Write("\nEnter New Grade to Update: ");
                char newGrade = char.Parse(Console.ReadLine());

                // Update student's grade
                student.UpdateGrade(newGrade);

                Console.WriteLine("\nUpdated Student Details:");
                student.ShowStudentDetails();
            }
            else
            {
                Console.WriteLine("Invalid Object");
            }

            Console.WriteLine();

            // Display total number of students
            UniversityManagement.ShowTotalStudents();

            Console.ReadLine();
        }
    }
}