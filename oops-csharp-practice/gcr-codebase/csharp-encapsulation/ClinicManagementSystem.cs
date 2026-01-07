using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.encapsulationAndPolymorphism
{

    // Interface for medical record operations
    interface IMedicalInfo
    {
        void AddMedicalRecord(string details);
        void ShowMedicalRecord();
    }

    // Abstract base class for all patients
    abstract class Person
    {
        // Encapsulated fields
        private int id;
        private string fullName;
        private int age;

        // Properties to access private fields
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // Abstract method for bill calculation
        public abstract double CalculateBill();

        // Concrete method to display basic details
        public void DisplayDetails()
        {
            Console.WriteLine("Patient ID   : " + Id);
            Console.WriteLine("Full Name    : " + FullName);
            Console.WriteLine("Age          : " + Age);
        }
    }

    // Inpatient class
    class ResidentPatient : Person, IMedicalInfo
    {
        private string medicalNotes;
        public int StayDays { get; set; }
        public double DailyRate { get; set; }

        public override double CalculateBill()
        {
            return StayDays * DailyRate;
        }

        public void AddMedicalRecord(string details)
        {
            medicalNotes = details;
        }

        public void ShowMedicalRecord()
        {
            Console.WriteLine("Diagnosis    : " + medicalNotes);
        }
    }

    // Outpatient class
    class VisitingPatient : Person, IMedicalInfo
    {
        private string medicalNotes;
        public double ConsultationCharge { get; set; }

        public override double CalculateBill()
        {
            return ConsultationCharge;
        }

        public void AddMedicalRecord(string details)
        {
            medicalNotes = details;
        }

        public void ShowMedicalRecord()
        {
            Console.WriteLine("Diagnosis    : " + medicalNotes);
        }
    }

    // Main program class
    internal class ClinicManagementSystem
    {
        public static void Main(string[] args)
        {
            Console.Write("How many patients will you enter? ");
            int totalPatients = int.Parse(Console.ReadLine());

            // Array to store patients using polymorphism
            Person[] patientList = new Person[totalPatients];

            for (int i = 0; i < totalPatients; i++)
            {
                Console.WriteLine("\nSelect patient type (1-Resident, 2-Visiting): ");
                int type = int.Parse(Console.ReadLine());

                Person patient;

                if (type == 1)
                {
                    ResidentPatient rp = new ResidentPatient();

                    Console.Write("Enter number of days admitted: ");
                    rp.StayDays = int.Parse(Console.ReadLine());

                    Console.Write("Enter daily rate: ");
                    rp.DailyRate = double.Parse(Console.ReadLine());

                    patient = rp;
                }
                else
                {
                    VisitingPatient vp = new VisitingPatient();

                    Console.Write("Enter consultation fee: ");
                    vp.ConsultationCharge = double.Parse(Console.ReadLine());

                    patient = vp;
                }

                Console.Write("Enter patient ID: ");
                patient.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter full name: ");
                patient.FullName = Console.ReadLine();

                Console.Write("Enter age: ");
                patient.Age = int.Parse(Console.ReadLine());

                Console.Write("Enter diagnosis: ");
                string diagnosis = Console.ReadLine();

                if (patient is IMedicalInfo record)
                {
                    record.AddMedicalRecord(diagnosis);
                }

                patientList[i] = patient;
            }

            // Display patient details and bills
            Console.WriteLine("\n--- Patient Details and Bills ---\n");

            foreach (var p in patientList)
            {
                p.DisplayDetails();
                Console.WriteLine("Bill Amount  : " + p.CalculateBill());

                if (p is IMedicalInfo record)
                {
                    record.ShowMedicalRecord();
                }

                Console.WriteLine();
            }
        }
    }
}

  