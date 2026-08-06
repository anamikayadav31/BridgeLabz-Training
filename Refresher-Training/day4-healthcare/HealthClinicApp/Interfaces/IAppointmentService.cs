namespace HealthClinicApp.Interfaces;

// =====================================================
// IAppointmentService Interface
// This interface declares all the methods related to
// Appointment Management.
//
// Any class that implements this interface must provide
// the implementation of these methods.
// =====================================================

public interface IAppointmentService
{
    // Add a new appointment
    void AddAppointment();

    // Display all appointments
    void ViewAppointments();

    // Search an appointment using Appointment Id
    void SearchAppointment();

    // Update appointment details
    void UpdateAppointment();

    // Delete an appointment
    void DeleteAppointment();
}