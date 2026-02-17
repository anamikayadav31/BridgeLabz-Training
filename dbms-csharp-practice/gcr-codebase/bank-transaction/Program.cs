using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        // Connection string to SQL Server
        string connStr =
               "Server=localhost\\SQLEXPRESS;Database=BankDB;Trusted_Connection=True;TrustServerCertificate=True";

        // Initialize database helper
        var db = new DatabaseHelper(connStr);

        // Initialize bank service
        var bankService = new BankService(db);

        // Simulate 10 parallel withdrawals on account 1
        Parallel.For(0, 10, i =>
        {
            bankService.Withdraw(1, 100);
        });

        Console.ReadLine(); // Keep console open
    }
}
