using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.Collections.generics_problems
{



    //Base class for all course types
    abstract class CourseType
    {
        public string CourseName { get; set; } // Course name
    }

    // Different course types
    class ExamCourse : CourseType { }
    class AssignmentCourse : CourseType { }

    // Generic Course class with constraint
    class Course<T> where T : CourseType
    {
        public List<T> Courses = new List<T>(); // Stores courses
    }

    // CourseManagement class with a menu method
    class CourseManagement
    {
        // Menu method to manage courses
        public void RunCourseMenu()
        {
            var examCourses = new Course<ExamCourse>();
            var assignmentCourses = new Course<AssignmentCourse>();

            int choice;
            do
            {
                Console.WriteLine("\n===== Course Management Menu =====");
                Console.WriteLine("1. Add Exam Course");
                Console.WriteLine("2. Add Assignment Course");
                Console.WriteLine("3. Show Exam Courses");
                Console.WriteLine("4. Show Assignment Courses");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Exam Course name: ");
                        examCourses.Courses.Add(new ExamCourse { CourseName = Console.ReadLine() });
                        break;

                    case 2:
                        Console.Write("Enter Assignment Course name: ");
                        assignmentCourses.Courses.Add(new AssignmentCourse { CourseName = Console.ReadLine() });
                        break;

                    case 3:
                        Console.WriteLine("Exam Courses:");
                        foreach (var c in examCourses.Courses)
                            Console.WriteLine(c.CourseName);
                        break;

                    case 4:
                        Console.WriteLine("Assignment Courses:");
                        foreach (var c in assignmentCourses.Courses)
                            Console.WriteLine(c.CourseName);
                        break;
                }

            } while (choice != 0);
        }


        // Single project entry point


        static void Main()
        {
            // Create CourseManagement object and run menu
            CourseManagement cm = new CourseManagement();
            cm.RunCourseMenu();
        }
    }
}