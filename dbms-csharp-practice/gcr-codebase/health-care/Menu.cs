using System;

namespace HealthCareApp;

public class Menu
{
    // Services
    PatientService patient = new PatientService();
    DoctorService doctor = new DoctorService();
    AppointmentService appointment = new AppointmentService();
    BillingUtility billing = new BillingUtility();

    public void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====== HEALTH CARE MANAGEMENT SYSTEM ======\n");

            Console.WriteLine("--- DOCTOR MANAGEMENT ---");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. View Doctors");
            Console.WriteLine("3. Deactivate Doctor");

            Console.WriteLine("\n--- PATIENT MANAGEMENT ---");
            Console.WriteLine("4. Register Patient");
            Console.WriteLine("5. Update Patient");
            Console.WriteLine("6. Search Patient");

            Console.WriteLine("\n--- APPOINTMENT MANAGEMENT ---");
            Console.WriteLine("7. Book Appointment");
            Console.WriteLine("8. View Appointments");
            Console.WriteLine("9. Cancel Appointment");

            Console.WriteLine("\n--- VISIT MANAGEMENT ---");
            Console.WriteLine("10. Complete Visit");

            Console.WriteLine("\n--- BILLING MANAGEMENT ---");
            Console.WriteLine("11. Generate Bill");
            Console.WriteLine("12. Record Payment");
            Console.WriteLine("13. View Outstanding Bills");

            Console.WriteLine("\n0. Exit");
            Console.Write("\nEnter choice: ");

            if (!int.TryParse(Console.ReadLine(), out int ch))
            {
                Console.WriteLine("Invalid input!");
                Console.ReadKey();
                continue;
            }

            try
            {
                switch (ch)
                {
                    case 1: doctor.AddDoctor(); break;
                    case 2: doctor.ViewBySpecialty(); break;
                    case 3: doctor.DeactivateDoctor(); break;

                    case 4: patient.RegisterPatient(); break;
                    case 5: patient.UpdatePatient(); break;
                    case 6: patient.SearchPatient(); break;

                    case 7: appointment.Book(); break;
                    case 8: appointment.ViewDaily(); break;
                    case 9: appointment.Cancel(); break;

                    case 10: appointment.CompleteVisit(); break;

                    case 11: billing.GenerateBill(); break;
                    case 12: billing.RecordPayment(); break;
                    case 13: billing.ViewOutstanding(); break;

                    case 0:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
