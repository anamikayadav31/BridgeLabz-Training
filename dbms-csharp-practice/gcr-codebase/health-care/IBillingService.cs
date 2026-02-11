using System;
using Microsoft.Data.SqlClient;


namespace HealthCareApp;

public interface IBillingService
{
    void GenerateBill();
    void RecordPayment();
    void ViewOutstanding();
}
