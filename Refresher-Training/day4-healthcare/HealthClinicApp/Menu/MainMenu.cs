using HealthClinicApp.Services;

namespace HealthClinicApp.Menu;

// =====================================================
// MainMenu Class
// This class displays all menus to the user and calls
// the appropriate service methods.
//
// It does not communicate with the database directly.
// Database operations are handled by the Service classes.
// =====================================================

public class MainMenu
{
    // Create objects of service classes
    DoctorService doctorService = new DoctorService();
    PatientService patientService = new PatientService();
    AppointmentService appointmentService = new AppointmentService();

    // =====================================================
    // Display the Main Menu
    // This menu keeps running until the user chooses Exit.
    // =====================================================
    public void ShowMenu()
    {
        while (true)
        {
            // Clear the console screen
            Console.Clear();

            // Display main menu
            Console.WriteLine("==============================================");
            Console.WriteLine("         HEALTHCARE MINI SYSTEM");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Doctor Management");
            Console.WriteLine("2. Patient Management");
            Console.WriteLine("3. Appointment Management");
            Console.WriteLine("4. Exit");
            Console.WriteLine("==============================================");
            Console.Write("Enter Choice : ");

            // Read user input safely
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("\nInvalid Input. Please enter a number.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            // Execute the selected option
            switch (choice)
            {
                case 1:
                    DoctorMenu();
                    break;

                case 2:
                    PatientMenu();
                    break;

                case 3:
                    AppointmentMenu();
                    break;

                case 4:
                    Console.WriteLine("\nThank You for using the Healthcare Mini System.");
                    return;

                default:
                    Console.WriteLine("\nInvalid Choice.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // =====================================================
    // Doctor Management Menu
    // =====================================================
    private void DoctorMenu()
    {
        Console.Clear();

        Console.WriteLine("========== DOCTOR MANAGEMENT ==========");
        Console.WriteLine("1. Add Doctor");
        Console.WriteLine("2. View Doctors");
        Console.WriteLine("3. Search Doctor");
        Console.WriteLine("4. Update Doctor");
        Console.WriteLine("5. Delete Doctor");
        Console.WriteLine("0. Back");
        Console.Write("Enter Choice : ");

        // Read user choice safely
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            choice = -1;
        }

        switch (choice)
        {
            case 1:
                doctorService.AddDoctor();
                break;

            case 2:
                doctorService.ViewDoctors();
                break;

            case 3:
                doctorService.SearchDoctor();
                break;

            case 4:
                doctorService.UpdateDoctor();
                break;

            case 5:
                doctorService.DeleteDoctor();
                break;

            case 0:
                return;

            default:
                Console.WriteLine("Invalid Choice.");
                break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    // =====================================================
    // Patient Management Menu
    // =====================================================
    private void PatientMenu()
    {
        Console.Clear();

        Console.WriteLine("========== PATIENT MANAGEMENT ==========");
        Console.WriteLine("1. Add Patient");
        Console.WriteLine("2. View Patients");
        Console.WriteLine("3. Search Patient");
        Console.WriteLine("4. Update Patient");
        Console.WriteLine("5. Delete Patient");
        Console.WriteLine("0. Back");
        Console.Write("Enter Choice : ");

        // Read user choice safely
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            choice = -1;
        }

        switch (choice)
        {
            case 1:
                patientService.AddPatient();
                break;

            case 2:
                patientService.ViewPatients();
                break;

            case 3:
                patientService.SearchPatient();
                break;

            case 4:
                patientService.UpdatePatient();
                break;

            case 5:
                patientService.DeletePatient();
                break;

            case 0:
                return;

            default:
                Console.WriteLine("Invalid Choice.");
                break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    // =====================================================
    // Appointment Management Menu
    // =====================================================
    private void AppointmentMenu()
    {
        Console.Clear();

        Console.WriteLine("======= APPOINTMENT MANAGEMENT =======");
        Console.WriteLine("1. Schedule Appointment");
        Console.WriteLine("2. View Appointments");
        Console.WriteLine("3. Search Appointment");
        Console.WriteLine("4. Update Appointment");
        Console.WriteLine("5. Cancel Appointment");
        Console.WriteLine("0. Back");
        Console.Write("Enter Choice : ");

        // Read user choice safely
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            choice = -1;
        }

        switch (choice)
        {
            case 1:
                appointmentService.AddAppointment();
                break;

            case 2:
                appointmentService.ViewAppointments();
                break;

            case 3:
                appointmentService.SearchAppointment();
                break;

            case 4:
                appointmentService.UpdateAppointment();
                break;

            case 5:
                appointmentService.DeleteAppointment();
                break;

            case 0:
                return;

            default:
                Console.WriteLine("Invalid Choice.");
                break;
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}