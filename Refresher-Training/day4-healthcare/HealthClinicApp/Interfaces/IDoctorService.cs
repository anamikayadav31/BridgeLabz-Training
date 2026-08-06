namespace HealthClinicApp.Interfaces;

// =====================================================
// IDoctorService Interface
// This interface declares all the methods related to
// Doctor Management.
//
// Any class that implements this interface must provide
// the implementation of these methods.
// =====================================================

public interface IDoctorService
{
    // Add a new doctor
    void AddDoctor();

    // Display all doctors
    void ViewDoctors();

    // Search a doctor using Doctor Id
    void SearchDoctor();

    // Update doctor details
    void UpdateDoctor();

    // Delete a doctor
    void DeleteDoctor();
}