using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class UniversityManagement
    {
        public int RollNumber;       // public
        protected string Name;       // protected
        private double CGPA;         // private
                                     // Constructor
        public UniversityManagement(int roll, string studentName, double cgpa)
        {
            RollNumber = roll;
            Name = studentName;
            CGPA = cgpa;
        }

        // Methods to access private variable
        public double GetCGPA()
        {
            return CGPA;
        }

        public void SetCGPA(double newCGPA)
        {
            CGPA = newCGPA;
        }

        public static void Main(string[] args)
        {
            // Taking user input
            Console.Write("Enter Roll Number: ");
            int roll = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter CGPA: ");
            double cgpa = Convert.ToDouble(Console.ReadLine());

            // Create PostgraduateStudent object
            PostgraduateStudent student = new PostgraduateStudent(roll, name, cgpa);

            // Display student details
            student.ShowDetails();

            // Update CGPA
            Console.Write("\nEnter new CGPA to update: ");
            double newCGPA = Convert.ToDouble(Console.ReadLine());
            student.SetCGPA(newCGPA);

            Console.WriteLine("Updated CGPA: " + student.GetCGPA());
        }
    }







    // Derived class
    internal class PostgraduateStudent : UniversityManagement
    {
        public PostgraduateStudent(int roll, string studentName, double cgpa)
            : base(roll, studentName, cgpa)
        {
        }

        // Display student details
        public void ShowDetails()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine("Roll Number: " + RollNumber);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("CGPA: " + GetCGPA());
        }



    }
    
}