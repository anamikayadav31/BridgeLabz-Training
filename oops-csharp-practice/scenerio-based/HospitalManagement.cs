using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased
{


    // Base class for patient details
    class Patient
    {
        protected int patientId;
        protected string patientName;
        protected int patientAge;

        // Constructor
        public Patient(int patientId, string patientName, int patientAge)
        {
            this.patientId = patientId;
            this.patientName = patientName;
            this.patientAge = patientAge;
        }

        // Display patient details
        public virtual void DisplayPatientInfo()
        {
            Console.WriteLine($"Patient ID : {patientId}");
            Console.WriteLine($"Name       : {patientName}");
            Console.WriteLine($"Age        : {patientAge}");
        }
    }

    // Derived class for admitted patients
    class InPatient : Patient
    {
        int roomNumber;
        int admittedDays;

        // Constructor
        public InPatient(int patientId, string patientName, int patientAge,
                         int roomNumber, int admittedDays)
            : base(patientId, patientName, patientAge)
        {
            this.roomNumber = roomNumber;
            this.admittedDays = admittedDays;
        }

        // Override display method
        public override void DisplayPatientInfo()
        {
            base.DisplayPatientInfo();
            Console.WriteLine($"Room Number: {roomNumber}");
            Console.WriteLine($"Days Admitted: {admittedDays}");
        }
    }

    // Doctor details class
    class Doctor
    {
        int doctorId;
        string doctorName;
        string specialization;

        // Constructor
        public Doctor(int doctorId, string doctorName, string specialization)
        {
            this.doctorId = doctorId;
            this.doctorName = doctorName;
            this.specialization = specialization;
        }

        // Display doctor details
        public void DisplayDoctorInfo()
        {
            Console.WriteLine($"Doctor ID  : {doctorId}");
            Console.WriteLine($"Name       : {doctorName}");
            Console.WriteLine($"Specialist : {specialization}");
        }
    }

    // Interface for billing
    interface IPayable
    {
        double CalculateBillAmount();
    }

    // Bill class implementing interface
    class Bill : IPayable
    {
        double billAmount;

        public Bill(double billAmount)
        {
            this.billAmount = billAmount;
        }

        public double CalculateBillAmount()
        {
            return billAmount;
        }
    }

    // Main class
    class HospitalManagement
    {
        public static void Main(string[] args)
        {
            // Patient input
            Console.Write("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            Console.Write("Enter Patient Name: ");
            string patientName = Console.ReadLine();

            Console.Write("Enter Patient Age: ");
            int patientAge = int.Parse(Console.ReadLine());

            Console.Write("Enter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter Days Admitted: ");
            int admittedDays = int.Parse(Console.ReadLine());

            InPatient inPatient =
                new InPatient(patientId, patientName, patientAge,
                              roomNumber, admittedDays);

            Console.WriteLine("\n--- Patient Details ---");
            inPatient.DisplayPatientInfo();

            // Doctor input
            Console.Write("\nEnter Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());

            Console.Write("Enter Doctor Name: ");
            string doctorName = Console.ReadLine();

            Console.Write("Enter Specialization: ");
            string specialization = Console.ReadLine();

            Doctor doctor = new Doctor(doctorId, doctorName, specialization);

            Console.WriteLine("\n--- Doctor Details ---");
            doctor.DisplayDoctorInfo();

            // Billing input
            Console.Write("\nEnter Total Bill Amount: ");
            double amount = double.Parse(Console.ReadLine());

            IPayable bill = new Bill(amount);

            Console.WriteLine("\nTotal Bill Amount: " + bill.CalculateBillAmount());
            Console.ReadLine();
        }
    }
}
