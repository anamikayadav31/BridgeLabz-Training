using System;
using System.Collections.Generic;
using System.Globalization;

// Static class to manage resident profiles
public static class Profile
{
    // Format Name: trims spaces and converts to title case
    public static string FormatName(string rawName)
    {
        rawName = rawName.Trim();
        return CultureInfo.CurrentCulture.TextInfo
               .ToTitleCase(rawName.ToLower());
    }

    // Email Validation
    public static bool ValidateEmail(string emailAddress)
    {
        return emailAddress.Contains("@") && emailAddress.Contains(".");
    }

    // Extract City from Address
    public static string ExtractCity(string fullAddress)
    {
        string[] addressParts = fullAddress.Split(',');
        if (addressParts.Length >= 2)
            return addressParts[1].Trim();
        return "Unknown";
    }

    // Pass by Value Example
    public static void IncreaseAge(int currentAge)
    {
        currentAge += 1;
        Console.WriteLine("Age inside method: " + currentAge);
    }

    // Pass by Reference Example
    public static void UpdateCitizen(ref Resident citizenRef, string updatedName)
    {
        citizenRef = new Resident(
            FormatName(updatedName),
            citizenRef.GetEmail(),
            citizenRef.GetAddress(),
            citizenRef.GetAge());
    }

    // Search using string matching
    public static void SearchCitizen(List<Resident> citizenList, string nameToSearch)
    {
        if (string.IsNullOrWhiteSpace(nameToSearch))
        {
            Console.WriteLine("Invalid search text.");
            return;
        }

        bool isFound = false;

        foreach (var citizen in citizenList)
        {
            if (citizen != null &&
                citizen.GetName().Contains(nameToSearch, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Match Found: " + citizen.GetName());
                isFound = true;
            }
        }

        if (!isFound)
            Console.WriteLine("No citizen found.");
    }

    // Profile Generator
    public static Resident CreateProfile(List<Resident> citizenList)
    {
        try
        {
            Console.Write("Enter Name: ");
            string formattedName = FormatName(Console.ReadLine());

            // Check for duplicate name
            foreach (var resident in citizenList)
            {
                if (resident != null && resident.GetName() == formattedName)
                {
                    throw new DuplicateResidentError(
                        "Citizen with same name already exists.");
                }
            }

            Console.Write("Enter Email: ");
            string inputEmail = Console.ReadLine();

            if (!ValidateEmail(inputEmail))
                throw new FormatException("Invalid Email Format");

            Console.Write("Enter Address (Street, City): ");
            string inputAddress = Console.ReadLine();

            Console.Write("Enter Age: ");
            int inputAge = Convert.ToInt32(Console.ReadLine());

            if (inputAge <= 0)
                throw new InvalidAge("Age must be greater than 0");

            // Create new Resident and add to the list
            Resident newResident = new Resident(
                formattedName,
                inputEmail,
                inputAddress,
                inputAge);

            citizenList.Add(newResident); // Add to collection
            return newResident;
        }
        catch (InvalidAge ex)
        {
            Console.WriteLine("Age Error: " + ex.Message);
            ErrorLogger.LogError(ex.Message);
        }
        catch (DuplicateResidentError ex)
        {
            Console.WriteLine("Duplicate Error: " + ex.Message);
            ErrorLogger.LogError(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Format Error: " + ex.Message);
            ErrorLogger.LogError(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
            ErrorLogger.LogError(ex.Message);
        }
        finally
        {
            Console.WriteLine("Profile creation attempt completed.");
        }

        return null;
    }

    // Optional: Display all residents
    public static void ShowAllResidents(List<Resident> citizenList)
    {
        Console.WriteLine("\nAll Residents:");
        foreach (var resident in citizenList)
        {
            Console.WriteLine($"{resident.GetName()} | {resident.GetEmail()} | {resident.GetAddress()} | Age: {resident.GetAge()}");
        }
    }
}
