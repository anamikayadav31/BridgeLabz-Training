using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class EmailValidatorMain
{
    // List to store valid emails
    private static List<string> mails = new List<string>();

    // Regex pattern for email validation
    private static string pattern =
        "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6}$";

    // Variable to store number of users
    private static int usercount;

    public static void Main()
    {
        // Entry point of program
        Console.WriteLine("Welcome to EmailValidator!");
        AddUser();
    }

    public static void AddUser()
    {
        try
        {
            // Get number of users
            Console.WriteLine("Enter number of users:");
            usercount = int.Parse(Console.ReadLine());

            // Loop through users
            for (int i = 0; i < usercount; i++)
            {
                Console.WriteLine($"Enter email of user {i + 1}:");
                string email = Console.ReadLine();

                // Validate email using regex
                if (IsValidEmail(email))
                {
                    Console.WriteLine("This is a Valid Email");
                    mails.Add(email); // Add valid email to list
                }
                else
                {
                    Console.WriteLine("This is an Invalid Email");
                }
            }

            // Display all valid emails
            DisplayEmails();
        }
        catch (Exception ex)
        {
            // Handle runtime errors
            Console.WriteLine("An error occurred! " + ex.Message);
        }
    }

    // Method to check email format
    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, pattern);
    }

    // Method to print stored valid emails
    public static void DisplayEmails()
    {
        Console.WriteLine("Valid Mails list:");
        foreach (string email in mails)
        {
            Console.WriteLine(email);
        }
    }
}
