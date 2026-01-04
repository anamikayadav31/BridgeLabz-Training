using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.oopsKeywordsOperator
{
    internal class Patient
    {


        // static variable: hospital name
        public static string HospitalName;

        // static variable: total number of patients
        private static int TotalPatients = 0;

        // readonly patient ID (cannot be changed after creation)
        public readonly int PatientId;

        // instance variables
        public string PatientName;
        public int PatientAge;
        public string Ailment;

        // Constructor using 'this' keyword
        public Patient(int patientId, string patientName, int patientAge, string ailment)
        {
            this.PatientId = patientId;       // refers to current object
            this.PatientName = patientName;
            this.PatientAge = patientAge;
            this.Ailment = ailment;

            TotalPatients++;                  // increase total patient count
        }

        // Static method to show total patients
        public static void ShowTotalPatients()
        {
            Console.WriteLine("\nTotal Patients in " + HospitalName + " : " + TotalPatients);
        }

        // Display patient details
        public void ShowDetails()
        {
            Console.WriteLine("\nPatient Information:");
            Console.WriteLine("Hospital Name : " + HospitalName);
            Console.WriteLine("Patient ID    : " + PatientId);
            Console.WriteLine("Name          : " + PatientName);
            Console.WriteLine("Age           : " + PatientAge);
            Console.WriteLine("Ailment       : " + Ailment);
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hospital Management System\n");

            // Ask hospital name
            Console.Write("Enter Hospital Name: ");
            Patient.HospitalName = Console.ReadLine();

            // Ask how many patients to add
            Console.Write("\nHow many patients do you want to register? : ");
            int numPatients = int.Parse(Console.ReadLine());

            // Array to store patient objects
            Patient[] patients = new Patient[numPatients];

            // Input patient details
            for (int i = 0; i < numPatients; i++)
            {
                Console.WriteLine($"\nEnter details for Patient {i + 1}:");

                Console.Write("Patient ID    : ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Patient Name  : ");
                string name = Console.ReadLine();

                Console.Write("Patient Age   : ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Ailment       : ");
                string ailment = Console.ReadLine();

                // Create patient object and store in array
                patients[i] = new Patient(id, name, age, ailment);
            }

            // Display details of all patients using 'is' operator
            Console.WriteLine("\n--- Patient Details ---");
            for (int i = 0; i < numPatients; i++)
            {
                if (patients[i] is Patient)
                {
                    patients[i].ShowDetails();
                }
            }

            // Show total patients
            Patient.ShowTotalPatients();

            Console.WriteLine("\nThank you for using Hospital Management System!");
        }
    }
}
