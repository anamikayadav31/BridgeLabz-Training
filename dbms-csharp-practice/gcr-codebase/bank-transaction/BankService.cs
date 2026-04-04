using System;
using Microsoft.Data.SqlClient;

public class BankService
{
    private readonly DatabaseHelper _db;

    public BankService(DatabaseHelper db)
    {
        _db = db; // Inject database helper
    }

    public void Withdraw(int accountId, decimal amount)
    {
        using var conn = _db.GetConnection();
        conn.Open(); // Open SQL connection

        using var transaction = conn.BeginTransaction(); // Start transaction

        try
        {
            // Deduct balance if sufficient
            var updateCmd = new SqlCommand(
                @"UPDATE Accounts 
                  SET Balance = Balance - @Amount
                  WHERE AccountId = @Id AND Balance >= @Amount",
                conn, transaction);

            updateCmd.Parameters.AddWithValue("@Id", accountId);
            updateCmd.Parameters.AddWithValue("@Amount", amount);

            int rows = updateCmd.ExecuteNonQuery();

            if (rows == 0)
                throw new Exception("Insufficient Balance"); // Rollback if not enough

            // Record transaction
            var insertCmd = new SqlCommand(
                @"INSERT INTO Transactions(AccountId, Amount, Type)
                  VALUES(@Id, @Amount, 'Withdrawal')",
                conn, transaction);

            insertCmd.Parameters.AddWithValue("@Id", accountId);
            insertCmd.Parameters.AddWithValue("@Amount", amount);

            insertCmd.ExecuteNonQuery();

            transaction.Commit(); // Commit transaction if all succeeds

            Console.WriteLine("Withdrawal Success");
        }
        catch (Exception ex)
        {
            transaction.Rollback(); // Rollback on error
            Console.WriteLine($"Failed: {ex.Message}");
        }
    }
}
