using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class University
    {


        // Faculty class (Aggregation: Faculty can exist independently)
        public class Faculty
        {
            public string facultyName;

            // Constructor
            public Faculty(string facultyName)
            {
                this.facultyName = facultyName;
            }

            // Display faculty details
            public void ShowFaculty()
            {
                Console.WriteLine("Faculty Name: " + facultyName);
            }
        }

        // Department class (Composition: Department exists only within University)
        public class Department
        {
            public string departmentName;

            // Constructor
            public Department(string departmentName)
            {
                this.departmentName = departmentName;
            }

            // Display department details
            public void ShowDepartment()
            {
                Console.WriteLine("Department: " + departmentName);
            }
        }

        // University class
        public string universityTitle;
        public List<Department> departmentList;  // Composition
        public List<Faculty> facultyList;        // Aggregation

        // Constructor
        public University(string universityTitle)
        {
            this.universityTitle = universityTitle;
            departmentList = new List<Department>();
            facultyList = new List<Faculty>();
        }

        // Add department (composition)
        public void AddDepartment(string deptName)
        {
            departmentList.Add(new Department(deptName));
        }

        // Add faculty (aggregation)
        public void AddFaculty(Faculty facultyObj)
        {
            facultyList.Add(facultyObj);
        }

        // Display university structure
        public void ShowUniversity()
        {
            Console.WriteLine("\nUniversity Name: " + universityTitle);

            Console.WriteLine("\nDepartments:");
            for (int i = 0; i < departmentList.Count; i++)
            {
                departmentList[i].ShowDepartment();
            }

            Console.WriteLine("\nFaculties:");
            for (int i = 0; i < facultyList.Count; i++)
            {
                facultyList[i].ShowFaculty();
            }
        }

        // Main method
        public static void Main(string[] args)
        {
            // Take university name
            Console.WriteLine("Enter University Name:");
            string inputUniversityName = Console.ReadLine();

            University universityObj = new University(inputUniversityName);

            // Take number of departments
            Console.WriteLine("Enter Number of Departments:");
            int departmentCount = int.Parse(Console.ReadLine());

            // Add departments
            for (int i = 0; i < departmentCount; i++)
            {
                Console.WriteLine("\nEnter Department Name:");
                string deptName = Console.ReadLine();

                universityObj.AddDepartment(deptName);
            }

            // Take number of faculties
            Console.WriteLine("\nEnter Number of Faculties:");
            int facultyCount = int.Parse(Console.ReadLine());

            Faculty[] facultyArray = new Faculty[facultyCount];

            // Create faculty objects and add to university
            for (int i = 0; i < facultyCount; i++)
            {
                Console.WriteLine("\nEnter Faculty Name:");
                string facultyName = Console.ReadLine();

                facultyArray[i] = new Faculty(facultyName);

                // Add faculty to university (aggregation)
                universityObj.AddFaculty(facultyArray[i]);
            }

            // Display the university structure
            universityObj.ShowUniversity();
        }
    }
}