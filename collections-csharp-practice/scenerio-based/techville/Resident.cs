using System;
using System.Collections.Generic;

public class Resident
{
    // Private attributes
    private string fullName;
    private string emailAddress;
    private string homeAddress;
    private int citizenAge;

    // Static collection to hold all residents
    private static List<Resident> allResidents = new List<Resident>();

    // Constructor
    public Resident(string fullName, string emailAddress, string homeAddress, int citizenAge)
    {
        this.fullName = fullName;
        this.emailAddress = emailAddress;
        this.homeAddress = homeAddress;
        SetAge(citizenAge);

        // Automatically add to collection when created
        allResidents.Add(this);
    }

    // Get Methods
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

    // Display single profile
    public void DisplayProfile()
    {
        Console.WriteLine("\n--- Profile ---");
        Console.WriteLine($"Name: {fullName}");
        Console.WriteLine($"Email: {emailAddress}");
        Console.WriteLine($"Address: {homeAddress}");
        Console.WriteLine($"Age: {citizenAge}");
    }

    // ---------------- Collection Methods ----------------

    // Display all residents
    public static void DisplayAllResidents()
    {
        Console.WriteLine("\n=== All Residents ===");
        foreach (var resident in allResidents)
        {
            resident.DisplayProfile();
        }
    }

    // Search residents by name (case-insensitive)
    public static Resident SearchResidentByName(string name)
    {
        foreach (var resident in allResidents)
        {
            if (resident.fullName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return resident;
        }
        return null; // not found
    }

    // Remove a resident by name
    public static bool RemoveResidentByName(string name)
    {
        var resident = SearchResidentByName(name);
        if (resident != null)
        {
            allResidents.Remove(resident);
            return true;
        }
        return false;
    }

    // Get the collection of all residents
    public static List<Resident> GetAllResidents() => allResidents;
}
