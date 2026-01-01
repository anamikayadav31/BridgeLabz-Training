using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.constructor
{
    internal class OnlineCourse
    {


        // Instance variables
        public string Name;        // Course name
        public int DurationMonths; // Duration in months
        public double Fee;         // Course fee

        // Class variable
        public static string Institute = "BridgeLabz";

        // Constructor
        public OnlineCourse(string name, int duration, double fee)
        {
            Name = name;
            DurationMonths = duration;
            Fee = fee;
        }

        // Instance method to display course details
        public void ShowDetails()
        {
            Console.WriteLine("\nCourse Name: " + Name);
            Console.WriteLine("Duration: " + DurationMonths + " months");
            Console.WriteLine("Fee: " + Fee);
            Console.WriteLine("Institute: " + Institute);
        }

        // Static method to update institute name
        public static void ChangeInstitute(string newName)
        {
            Institute = newName;
        }

        public static void Main(string[] args)
        {
            Console.Write("How many courses do you want to enter? ");
            int count = Convert.ToInt32(Console.ReadLine());

            OnlineCourse[] courses = new OnlineCourse[count];

            // Input course details from user
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\nEnter details for course {i + 1}:");

                Console.Write("Course Name: ");
                string name = Console.ReadLine();

                Console.Write("Duration (months): ");
                int duration = Convert.ToInt32(Console.ReadLine());

                Console.Write("Fee: ");
                double fee = Convert.ToDouble(Console.ReadLine());

                courses[i] = new OnlineCourse(name, duration, fee);
            }

            // Display all courses
            Console.WriteLine("\n--- Course Details ---");
            foreach (OnlineCourse course in courses)
            {
                course.ShowDetails();
            }

            // Update institute name
            Console.Write("\nEnter new institute name (or press Enter to skip): ");
            string newInstitute = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newInstitute))
            {
                OnlineCourse.ChangeInstitute(newInstitute);

                Console.WriteLine("\n--- Updated Course Details ---");
                foreach (OnlineCourse course in courses)
                {
                    course.ShowDetails();
                }
            }

            Console.WriteLine("\nProgram finished.");
        }
    }
}
