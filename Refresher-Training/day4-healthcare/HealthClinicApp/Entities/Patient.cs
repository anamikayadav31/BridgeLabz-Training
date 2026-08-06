namespace HealthClinicApp.Entities;

// =====================================================
// Patient Class
// This class represents the Patient table in the
// database.
//
// Each object of this class stores the details of
// one patient.
// =====================================================

public class Patient
{
    // Stores the Patient Id
    // This is the Primary Key of the Patient table.
    public int PatientId { get; set; }

    // Stores the patient's name
    public string PatientName { get; set; }

    // Stores the patient's age
    public int PatientAge { get; set; }

    // Stores the patient's gender
    public string PatientGender { get; set; }

    // Stores the patient's contact number
    public string PatientContactNo { get; set; }

    // Stores the patient's address
    public string PatientAddress { get; set; }

    // =====================================================
    // Parameterized Constructor
    // This constructor is used to initialize the object
    // with values when a new Patient object is created.
    // =====================================================
    public Patient(int patientId, string patientName, int patientAge,
                   string patientGender, string patientContactNo,
                   string patientAddress)
    {
        PatientId = patientId;
        PatientName = patientName;
        PatientAge = patientAge;
        PatientGender = patientGender;
        PatientContactNo = patientContactNo;
        PatientAddress = patientAddress;
    }
}