using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class UniversityManagement
    {


        public class Student
        {
            public string studentName;
            public List<Course> enrolledCourses;

            // Constructor
            public Student(string studentName)
            {
                this.studentName = studentName;
                enrolledCourses = new List<Course>();
            }

            // Enroll student in a course
            public void EnrollCourse(Course courseObj)
            {
                enrolledCourses.Add(courseObj);
                courseObj.AddStudent(this); // add student to course
                Console.WriteLine(studentName + " enrolled in " + courseObj.courseName);
            }

            // View courses enrolled by student
            public void ViewCourses()
            {
                Console.WriteLine("\nStudent: " + studentName);
                Console.WriteLine("Enrolled Courses:");
                for (int i = 0; i < enrolledCourses.Count; i++)
                {
                    Console.WriteLine("- " + enrolledCourses[i].courseName);
                }
            }
        }

        // Professor class
        public class Professor
        {
            public string professorName;

            // Constructor
            public Professor(string professorName)
            {
                this.professorName = professorName;
            }

            // Assign professor to a course
            public void AssignToCourse(Course courseObj)
            {
                courseObj.SetProfessor(this);
                Console.WriteLine(professorName + " assigned to " + courseObj.courseName);
            }
        }

        // Course class
        public class Course
        {
            public string courseName;
            public Professor courseProfessor;
            public List<Student> enrolledStudents;

            // Constructor
            public Course(string courseName)
            {
                this.courseName = courseName;
                enrolledStudents = new List<Student>();
            }

            // Add student to course (aggregation)
            public void AddStudent(Student studentObj)
            {
                enrolledStudents.Add(studentObj);
            }

            // Set professor for course
            public void SetProfessor(Professor professorObj)
            {
                courseProfessor = professorObj;
            }

            // Display course details
            public void DisplayCourse()
            {
                Console.WriteLine("\nCourse: " + courseName);

                if (courseProfessor != null)
                {
                    Console.WriteLine("Professor: " + courseProfessor.professorName);
                }

                Console.WriteLine("Enrolled Students:");
                for (int i = 0; i < enrolledStudents.Count; i++)
                {
                    Console.WriteLine("- " + enrolledStudents[i].studentName);
                }
            }
        }

        public static void Main(string[] args)
        {

            // Input students

            Console.WriteLine("Enter number of students:");
            int studentCount = int.Parse(Console.ReadLine());
            Student[] studentArray = new Student[studentCount];

            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("Enter Student Name:");
                string studentName = Console.ReadLine();
                studentArray[i] = new Student(studentName);
            }


            // Input professors

            Console.WriteLine("\nEnter number of professors:");
            int professorCount = int.Parse(Console.ReadLine());
            Professor[] professorArray = new Professor[professorCount];

            for (int i = 0; i < professorCount; i++)
            {
                Console.WriteLine("Enter Professor Name:");
                string professorName = Console.ReadLine();
                professorArray[i] = new Professor(professorName);
            }


            // Input courses

            Console.WriteLine("\nEnter number of courses:");
            int courseCount = int.Parse(Console.ReadLine());
            Course[] courseArray = new Course[courseCount];

            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine("Enter Course Name:");
                string courseName = Console.ReadLine();
                courseArray[i] = new Course(courseName);
            }



            // Assign professors to courses


            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine("\nAssign Professor to Course: " + courseArray[i].courseName);
                Console.WriteLine("Enter Professor Number (1 to " + professorCount + "):");
                int profIndex = int.Parse(Console.ReadLine()) - 1;
                professorArray[profIndex].AssignToCourse(courseArray[i]);
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



            // Display all students and their courses


            for (int i = 0; i < studentCount; i++)
            {
                studentArray[i].ViewCourses();
            }



            // Display all courses and enrolled students


            for (int i = 0; i < courseCount; i++)
            {
                courseArray[i].DisplayCourse();
            }
        }
    }
}