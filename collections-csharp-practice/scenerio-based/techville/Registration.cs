using System;
using System.Collections.Generic;

class Registration
{
    static void Main()
    {
        Console.WriteLine("====== TechVille Smart City Management System ======\n");

        // ------------------ MODULE 1 ------------------
        Console.WriteLine("MODULE 1: Citizen Registration Portal");

        int totalFamilyMembers = 0;
        while (true)
        {
            try
            {
                Console.Write("Enter number of family members to register: ");
                totalFamilyMembers = Convert.ToInt32(Console.ReadLine());
                if (totalFamilyMembers <= 0)
                    throw new Exception("Number of members must be positive.");
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
        }

        // ------------------ MODULE 2 ------------------
        Console.WriteLine("\nMODULE 2: Service Eligibility Checker");

        var familyMembers = new List<(string Name, int Age, double Income, int ResidencyYears)>();

        for (int memberIndex = 1; memberIndex <= totalFamilyMembers; memberIndex++)
        {
            Console.WriteLine($"\nRegistering Family Member #{memberIndex}");
            try
            {
                Console.Write("Enter Name: ");
                string residentName = Console.ReadLine();

                Console.Write("Enter Age: ");
                int residentAge = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Annual Income: ");
                double annualIncome = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Years of Residency: ");
                int yearsOfResidency = Convert.ToInt32(Console.ReadLine());

                if (residentAge <= 0 || annualIncome < 0 || yearsOfResidency < 0)
                {
                    Console.WriteLine("Invalid input. Skipping this member.");
                    continue;
                }

                // Store in list
                familyMembers.Add((residentName, residentAge, annualIncome, yearsOfResidency));

                // Calculate score
                int totalScore = 0;
                totalScore += (residentAge >= 18)
                    ? (residentAge <= 60 ? 40 : 20)
                    : 10;

                if (annualIncome < 500000) totalScore += 30;
                else if (annualIncome < 1000000) totalScore += 20;
                else totalScore += 10;

                totalScore += (yearsOfResidency >= 5) ? 30 : 10;

                string eligibilityStatus = (totalScore >= 60) ? "Eligible" : "Not Eligible";

                int scoreCategory =
                    (totalScore >= 80) ? 3 :
                    (totalScore >= 60) ? 2 :
                    (totalScore >= 40) ? 1 : 0;

                string serviceTier = scoreCategory switch
                {
                    3 => "Platinum",
                    2 => "Gold",
                    1 => "Silver",
                    _ => "Basic"
                };

                Console.WriteLine("\nCitizen Summary");
                Console.WriteLine($"Name: {residentName}");
                Console.WriteLine($"Score: {totalScore}");
                Console.WriteLine($"Status: {eligibilityStatus}");
                Console.WriteLine($"Service Package: {serviceTier}");

                // Option to stop registration early
                Console.Write("\nStop registration? (yes/no): ");
                if (Console.ReadLine().ToLower() == "yes")
                    break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter numeric values where required.");
                memberIndex--; // retry same member
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                memberIndex--; // retry same member
            }
        }

        // ------------------ MODULE 3 ------------------
        Console.WriteLine("\nMODULE 3: Smart Citizen Database");
        Console.WriteLine("----------------------------------");

        var citizenIdList = new List<int> { 105, 102, 110, 101, 108 };

        Console.WriteLine("Original IDs:");
        citizenIdList.ForEach(id => Console.Write(id + " "));

        citizenIdList.Sort();
        Console.WriteLine("\nSorted IDs:");
        citizenIdList.ForEach(id => Console.Write(id + " "));

        Console.Write("\nSearch Citizen ID: ");
        if (int.TryParse(Console.ReadLine(), out int searchCitizenId))
        {
            int foundIndex = citizenIdList.IndexOf(searchCitizenId);
            Console.WriteLine(foundIndex != -1
                ? $"Found at index {foundIndex}"
                : "Not found");
        }
        else
        {
            Console.WriteLine("Invalid ID input.");
        }

        // Display 2D zone & sector counts
        int[,] zoneSectorCount =
        {
            {120,150,130},
            {100,140,160},
            {180,170,150},
            {110,115,125},
            {200,210,190}
        };

        Console.WriteLine("\nZone & Sector Counts:");
        for (int i = 0; i < zoneSectorCount.GetLength(0); i++)
        {
            Console.WriteLine($"Zone {i + 1}:");
            for (int j = 0; j < zoneSectorCount.GetLength(1); j++)
                Console.WriteLine($" Sector {j + 1}: {zoneSectorCount[i, j]}");
        }

        // ------------------ MODULE 4 ------------------
        Console.WriteLine("\nMODULE 4: Citizen Profile Management");
        Console.WriteLine("-------------------------------------");

        var citizenProfiles = new List<Resident>();

        for (int i = 0; i < totalFamilyMembers; i++)
        {
            Console.WriteLine($"\nCreating Profile #{i + 1}");
            Resident p = Profile.CreateProfile(citizenProfiles);
            if (p != null)
                citizenProfiles.Add(p);
            else
                i--; // retry if creation failed
        }

        // Display all profiles
        Console.WriteLine("\nAll Profiles:");
        citizenProfiles.ForEach(p => p.DisplayProfile());

        // Pass by Value Demo
        Console.WriteLine("\nPass By Value Demo");
        int copiedAge = citizenProfiles[0].GetAge();
        Profile.IncreaseAge(copiedAge);
        Console.WriteLine("Original Age: " + citizenProfiles[0].GetAge());

        // Pass by Reference Demo
        Console.WriteLine("\nPass By Reference Demo");
        Profile.UpdateCitizen(ref citizenProfiles[0], "updated name");
        Console.WriteLine("Updated Name: " + citizenProfiles[0].GetName());

        // Search citizen by name
        Console.Write("\nSearch citizen name: ");
        string nameToSearch = Console.ReadLine();
        Profile.SearchCitizen(citizenProfiles, nameToSearch);

        // Extract city from address
        Console.WriteLine("City: " + Profile.ExtractCity(citizenProfiles[0].GetAddress()));

        Console.WriteLine("\nSystem Finished. Thank you for using TechVille.");
    }
}
