using System;
using System.IO;
//MODULE-5
// Static class to handle error logging
public static class ErrorLogger
{
    private static string filePath = "error_log.txt"; // Log file name

    // Method to write error message to file
    public static void LogError(string message)
    {
        try
        {
            // Add error message with date and time
            File.AppendAllText(
                filePath,
                DateTime.Now + " : " + message + Environment.NewLine);
        }
        catch
        {
            // Show message if logging fails
            Console.WriteLine("Logging failed.");
        }
    }
}
