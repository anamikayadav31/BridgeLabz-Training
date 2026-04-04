using System;

public class Resident
{
    // Private attributes (renamed)
    private string fullName;
    private string emailAddress;
    private string homeAddress;
    private int citizenAge;

    // Constructor
    public  Resident(string fullName, string emailAddress, string homeAddress, int citizenAge)
    {
        this.fullName = fullName;
        this.emailAddress = emailAddress;
        this.homeAddress = homeAddress;
        SetAge(citizenAge);
    }

    // Get Methods (Public access)
    public string GetName() => fullName;
    public string GetEmail() => emailAddress;
    public string GetAddress() => homeAddress;
    public int GetAge() => citizenAge;

    // Setter with validation
    public void SetAge(int value)
    {
        if (value > 0)
            citizenAge = value;
        else
            Console.WriteLine("Invalid Age");
    }

    // Display
    public void DisplayProfile()
    {
        Console.WriteLine("\n---  Profile ---");
        Console.WriteLine($"Name: {fullName}");
        Console.WriteLine($"Email: {emailAddress}");
        Console.WriteLine($"Address: {homeAddress}");
        Console.WriteLine($"Age: {citizenAge}");
    }
}
