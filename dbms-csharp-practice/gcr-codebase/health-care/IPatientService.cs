using System;
using Microsoft.Data.SqlClient;


namespace HealthCareApp;
public interface IPatientService
{
    void RegisterPatient();
    void UpdatePatient();
    void SearchPatient();
    void ViewVisitHistory(int patientId);
}
