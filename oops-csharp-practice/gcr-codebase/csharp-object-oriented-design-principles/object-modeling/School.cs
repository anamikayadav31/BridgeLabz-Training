using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class School
    {


        // Course class
        public class Course
        {
            public string courseTitle;
            public List<Student> enrolledStudents;

            // Constructor
            public Course(string courseTitle)
            {
                this.courseTitle = courseTitle;
                enrolledStudents = new List<Student>();
            }

            // Add student to this course (association)
            public void AddStudent(Student studentObj)
            {
                enrolledStudents.Add(studentObj);
            }

            // Show students in this course
            public void ShowStudents()
            {
                Console.WriteLine("\nCourse: " + courseTitle);
                Console.WriteLine("Enrolled Students:");

                for (int i = 0; i < enrolledStudents.Count; i++)
                {
                    Console.WriteLine("- " + enrolledStudents[i].studentName);
                }
            }
        }

        // Student class
        public class Student
        {
            public string studentName;
            public List<Course> studentCourses;

            // Constructor
            public Student(string studentName)
            {
                this.studentName = studentName;
                studentCourses = new List<Course>();
            }

            // Enroll student in a course (association)
            public void EnrollCourse(Course courseObj)
            {
                studentCourses.Add(courseObj);
                courseObj.AddStudent(this);
            }

            // View courses of the student
            public void ViewCourses()
            {
                Console.WriteLine("\nStudent: " + studentName);
                Console.WriteLine("Enrolled Courses:");

                for (int i = 0; i < studentCourses.Count; i++)
                {
                    Console.WriteLine("- " + studentCourses[i].courseTitle);
                }
            }
        }

        // School class (aggregation with students)
        public string schoolTitle;
        public List<Student> schoolStudents;

        // Constructor
        public School(string schoolTitle)
        {
            this.schoolTitle = schoolTitle;
            schoolStudents = new List<Student>();
        }

        // Add student to school
        public void AddStudent(Student studentObj)
        {
            schoolStudents.Add(studentObj);
        }

        // Main method
        public static void Main(string[] args)
        {
            // Take school name from user
            Console.WriteLine("Enter School Name:");
            string inputSchoolName = Console.ReadLine();

            School schoolObj = new School(inputSchoolName);

            // Take number of students
            Console.WriteLine("Enter Number of Students:");
            int studentCount = int.Parse(Console.ReadLine());

            Student[] studentArray = new Student[studentCount];

            // Create students
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("\nEnter Student Name:");
                string studentNameInput = Console.ReadLine();

                studentArray[i] = new Student(studentNameInput);

                // Add student to school
                schoolObj.AddStudent(studentArray[i]);
            }

            // Take number of courses
            Console.WriteLine("\nEnter Number of Courses:");
            int courseCount = int.Parse(Console.ReadLine());

            Course[] courseArray = new Course[courseCount];

            // Create courses
            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine("\nEnter Course Name:");
                string courseNameInput = Console.ReadLine();

                courseArray[i] = new Course(courseNameInput);
            }

            // Enroll students in courses
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("\nHow many courses to enroll for " + studentArray[i].studentName + "?");
                int enrollCount = int.Parse(Console.ReadLine());

                for (int j = 0; j < enrollCount; j++)
                {
                    Console.WriteLine("Enter Course Number (1 to " + courseCount + "):");
                    int courseIndex = int.Parse(Console.ReadLine()) - 1;

                    studentArray[i].EnrollCourse(courseArray[courseIndex]);
                }
            }

            // Display each student's courses
            for (int i = 0; i < studentCount; i++)
            {
                studentArray[i].ViewCourses();
            }

            // Display each course's enrolled students
            for (int i = 0; i < courseCount; i++)
            {
                courseArray[i].ShowStudents();
            }
        }
    }
}
  