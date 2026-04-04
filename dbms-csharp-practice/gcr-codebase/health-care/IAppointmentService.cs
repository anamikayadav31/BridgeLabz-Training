
using System;
using Microsoft.Data.SqlClient;


namespace HealthCareApp;

public interface IAppointmentService
{
    void Book();
    void Cancel();
    void ViewDaily();
    void CompleteVisit();   // NEW
}
