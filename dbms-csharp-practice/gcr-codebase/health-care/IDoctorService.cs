using System;
using Microsoft.Data.SqlClient;


namespace HealthCareApp;

public interface IDoctorService
{
    void AddDoctor();
    void ViewBySpecialty();
    void DeactivateDoctor();
}
