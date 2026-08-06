namespace HealthClinicApp.Entities;

// =====================================================
// Doctor Class
// This class represents the Doctor table in the
// database.
//
// Each object of this class stores the details of
// one doctor.
// =====================================================

public class Doctor
{
    // Stores the Doctor Id
    public int DoctorId { get; set; }

    // Stores the Doctor Name
    public string DoctorName { get; set; }

    // Stores the doctor's specialization
    public string Speciality { get; set; }

    // Stores the doctor's contact number
    public string ContactNo { get; set; }

    // =====================================================
    // Parameterized Constructor
    // This constructor is used to initialize the object
    // with values when a new Doctor object is created.
    // =====================================================
    public Doctor(int doctorId, string doctorName, string speciality, string contactNo)
    {
        DoctorId = doctorId;
        DoctorName = doctorName;
        Speciality = speciality;
        ContactNo = contactNo;
    }
}