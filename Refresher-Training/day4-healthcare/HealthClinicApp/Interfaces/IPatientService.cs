namespace HealthClinicApp.Interfaces;

// =====================================================
// IPatientService Interface
// This interface declares all the methods related to
// Patient Management.
//
// Any class that implements this interface must provide
// the implementation of these methods.
// =====================================================

public interface IPatientService
{
    // Add a new patient
    void AddPatient();

    // Display all patients
    void ViewPatients();

    // Search a patient using Patient Id
    void SearchPatient();

    // Update patient details
    void UpdatePatient();

    // Delete a patient
    void DeletePatient();
}