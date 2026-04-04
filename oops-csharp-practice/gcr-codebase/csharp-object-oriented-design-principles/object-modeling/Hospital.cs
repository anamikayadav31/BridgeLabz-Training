using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.objectOrientedDesignPrinciples.objectModeling
{
    internal class Hospital
    {


        // Patient class
        public class Patient
        {
            // Patient name
            public string patientFullName;

            // Constructor
            public Patient(string patientFullName)
            {
                this.patientFullName = patientFullName;
            }
        }

        // Doctor class (Association with Patient)
        public class Doctor
        {
            // Doctor details
            public string doctorFullName;
            public List<Patient> consultedPatients;

            // Constructor
            public Doctor(string doctorFullName)
            {
                this.doctorFullName = doctorFullName;
                consultedPatients = new List<Patient>();
            }

            // Doctor consults a patient
            public void ConsultPatient(Patient patientObj)
            {
                consultedPatients.Add(patientObj);
                Console.WriteLine("Doctor " + doctorFullName +
                                  " is consulting Patient " + patientObj.patientFullName);
            }
        }

        // Main method
        public static void Main(string[] args)
        {
            // Take number of doctors
            Console.WriteLine("Enter number of doctors:");
            int doctorCount = int.Parse(Console.ReadLine());

            Doctor[] doctorList = new Doctor[doctorCount];

            // Create doctors
            for (int i = 0; i < doctorCount; i++)
            {
                Console.WriteLine("\nEnter Doctor Name:");
                string doctorNameInput = Console.ReadLine();

                doctorList[i] = new Doctor(doctorNameInput);
            }

            // Take number of patients
            Console.WriteLine("\nEnter number of patients:");
            int patientCount = int.Parse(Console.ReadLine());

            Patient[] patientList = new Patient[patientCount];

            // Create patients
            for (int i = 0; i < patientCount; i++)
            {
                Console.WriteLine("\nEnter Patient Name:");
                string patientNameInput = Console.ReadLine();

                patientList[i] = new Patient(patientNameInput);
            }

            // Consultation process
            Console.WriteLine("\n--- Consultation Details ---");

            for (int i = 0; i < doctorList.Length; i++)
            {
                Console.WriteLine("\nHow many patients did " + doctorList[i].doctorFullName + " consult?");
                int consultCount = int.Parse(Console.ReadLine());

                for (int j = 0; j < consultCount; j++)
                {
                    Console.WriteLine("Enter Patient Number (1 to " + patientCount + "):");
                    int patientIndex = int.Parse(Console.ReadLine()) - 1;

                    doctorList[i].ConsultPatient(patientList[patientIndex]);
                }
            }

            // Display doctor-patient association
            Console.WriteLine("\n--- Doctor - Patient Association ---");

            for (int i = 0; i < doctorList.Length; i++)
            {
                Console.WriteLine("\nDoctor: " + doctorList[i].doctorFullName);
                Console.WriteLine("Patients Consulted:");

                for (int j = 0; j < doctorList[i].consultedPatients.Count; j++)
                {
                    Console.WriteLine("- " + doctorList[i].consultedPatients[j].patientFullName);
                }
            }
        }
    }
}