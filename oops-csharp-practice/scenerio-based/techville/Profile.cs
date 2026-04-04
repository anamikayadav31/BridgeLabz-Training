using System;
using System.Globalization;

// Static class to manage resident profiles

//Module -5
public static class Profile
{
    // Format Name: trims spaces and converts to title case
    public static string FormatName(string rawName)
    {
        rawName = rawName.Trim();
        return CultureInfo.CurrentCulture.TextInfo
               .ToTitleCase(rawName.ToLower());
    }

    // Email Validation: checks if email contains '@' and '.'
    public static bool ValidateEmail(string emailAddress)
    {
        return emailAddress.Contains("@") && emailAddress.Contains(".");
    }

    // Extract City from Address: assumes address format "Street, City"
    public static string ExtractCity(string fullAddress)
    {
        string[] addressParts = fullAddress.Split(',');

        if (addressParts.Length >= 2)
            return addressParts[1].Trim(); // Return city part

        return "Unknown"; // Default if city not found
    }

    // Pass by Value Example: increases age locally, original not changed
    public static void IncreaseAge(int currentAge)
    {
        currentAge += 1;
        Console.WriteLine("Age inside method: " + currentAge);
    }

    // Pass by Reference Example: updates resident object using ref
    public static void UpdateCitizen(ref Resident citizenRef, string updatedName)
    {
        citizenRef = new Resident(
            FormatName(updatedName),
            citizenRef.GetEmail(),
            citizenRef.GetAddress(),
            citizenRef.GetAge());
    }

    // Search using string matching: finds citizens by name (case-insensitive)
    public static void SearchCitizen(Resident[] citizenList, string nameToSearch)
    {
        if (string.IsNullOrWhiteSpace(nameToSearch))
        {
            Console.WriteLine("Invalid search text.");
            return;
        }

        bool isFound = false;

        for (int i = 0; i < citizenList.Length; i++)
        {
            if (citizenList[i] != null &&
                citizenList[i].GetName()
                    .Contains(nameToSearch, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Match Found: " + citizenList[i].GetName());
                isFound = true;
            }
        }

        if (!isFound)
            Console.WriteLine("No citizen found.");
    }

    // Profile Generator: creates a new Resident with validation
    public static Resident CreateProfile(Resident[] citizenArray)
    {

        
        try
        {
            Console.Write("Enter Name: ");
            string formattedName = FormatName(Console.ReadLine());

            // Check for duplicate name
            for (int idx = 0; idx < citizenArray.Length; idx++)
            {
                if (citizenArray[idx] != null &&
                    citizenArray[idx].GetName() == formattedName)
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

            // Return new Resident object
            return new Resident(
                formattedName,
                inputEmail,
                inputAddress,
                inputAge);
        }
        catch (InvalidAge ex)
        {
            Console.WriteLine("Age Error: " + ex.Message);
            ErrorLogger.LogError(ex.Message); // Log error
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

        return null; // Return null if creation failed
    }
}
