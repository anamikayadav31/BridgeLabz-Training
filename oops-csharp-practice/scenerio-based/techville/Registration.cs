using System;

class Registration
{
    static void Main()
    {
        Console.WriteLine("====== TechVille Smart City Management System ======\n");

        // ------------------ MODULE 1 ------------------
        Console.WriteLine("MODULE 1: Citizen Registration Portal");

        // Ask number of family members to register
        Console.Write("Enter number of family members to register: ");
        int totalFamilyMembers = Convert.ToInt32(Console.ReadLine());

        // ------------------ MODULE 2 ------------------
        Console.WriteLine("\nMODULE 2: Service Eligibility Checker");

        for (int memberIndex = 1; memberIndex <= totalFamilyMembers; memberIndex++)
        {
            Console.WriteLine($"\nRegistering Family Member #{memberIndex}");

            // Input section
            Console.Write("Enter Name: ");
            string residentname = Console.ReadLine();

            Console.Write("Enter Age: ");
            int ResidentAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Annual Income: ");
            double annualIncome = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Years of Residency: ");
            int yearsOfResidency = Convert.ToInt32(Console.ReadLine());

            // Validate inputs
            if (ResidentAge <= 0 || annualIncome < 0 || yearsOfResidency < 0)
            {
                Console.WriteLine("Invalid input. Skipping this member.");
                continue;
            }

            // ---------------- Eligibility Score Calculation ----------------
            int totalScore = 0;

            // Age-based score
            totalScore += (ResidentAge >= 18)
                ? (ResidentAge <= 60 ? 40 : 20)
                : 10;

            // Income-based score
            if (annualIncome < 500000) totalScore += 30;
            else if (annualIncome < 1000000) totalScore += 20;
            else totalScore += 10;

            // Residency-based score
            totalScore += (yearsOfResidency >= 5) ? 30 : 10;

            // Determine eligibility status
            string eligibilityStatus = (totalScore >= 60) ? "Eligible" : "Not Eligible";

            // Assign service tier based on score
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

            // Output summary
            Console.WriteLine("\nCitizen Summary");
            Console.WriteLine($"Name: {residentname}");
            Console.WriteLine($"Score: {totalScore}");
            Console.WriteLine($"Status: {eligibilityStatus}");
            Console.WriteLine($"Service Package: {serviceTier}");

            // Option to stop registration early
            Console.Write("\nStop registration? (yes/no): ");
            if (Console.ReadLine().ToLower() == "yes")
                break;
        }

        // ------------------ MODULE 3 ------------------
        Console.WriteLine("\nMODULE 3: Smart Citizen Database");
        Console.WriteLine("----------------------------------");

        // Sample citizen IDs
        int[] citizenIdList = { 105, 102, 110, 101, 108 };

        // Display original IDs
        Console.WriteLine("Original IDs:");
        foreach (int id in citizenIdList) Console.Write(id + " ");

        // Sort IDs
        Array.Sort(citizenIdList);
        Console.WriteLine("\nSorted IDs:");
        foreach (int id in citizenIdList) Console.Write(id + " ");

        // Search for a citizen ID
        Console.Write("\nSearch Citizen ID: ");
        int searchCitizenId = Convert.ToInt32(Console.ReadLine());
        int foundIndex = Array.IndexOf(citizenIdList, searchCitizenId);
        Console.WriteLine(foundIndex != -1
            ? $"Found at index {foundIndex}"
            : "Not found");

        // Display 2D array of zone & sector counts
        int[,] zoneSectorCount =
        {
            {120,150,130},
            {100,140,160},
            {180,170,150},
            {110,115,125},
            {200,210,190}
        };

        Console.WriteLine("\nZone & Sector Counts:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Zone {i + 1}:");
            for (int j = 0; j < 3; j++)
                Console.WriteLine($" Sector {j + 1}: {zoneSectorCount[i,j]}");
        }

        // ------------------ MODULE 4 ------------------
        Console.WriteLine("\nMODULE 4: Citizen Profile Management");
        Console.WriteLine("-------------------------------------");

        // Array to store Resident profiles
        Resident[] citizenProfiles = new Resident[totalFamilyMembers];

        // Create profiles
        for (int i = 0; i < citizenProfiles.Length; i++)
        {
            Console.WriteLine($"\nCreating Profile #{i+1}");
            Resident p = Profile.CreateProfile(citizenProfiles);

            if (p != null)
                citizenProfiles[i] = p;
            else
                i--; // retry if creation failed
        }

        // Display all profiles
        Console.WriteLine("\nAll Profiles:");
        foreach (Resident p in citizenProfiles)
            p.DisplayProfile();

        // ---------------- Pass By Value Demo ----------------
        Console.WriteLine("\nPass By Value Demo");
        int copiedAge = citizenProfiles[0].GetAge();
        Profile.IncreaseAge(copiedAge);
        Console.WriteLine("Original Age: " + citizenProfiles[0].GetAge());

        // ---------------- Pass By Reference Demo ----------------
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
