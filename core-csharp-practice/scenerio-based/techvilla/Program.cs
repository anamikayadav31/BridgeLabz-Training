
using System;
class CitizenRegistration{
    static void Main(){

        
        // Module 1: Basic Concepts

        Console.WriteLine("Welcome to TechVille Citizen Registration Portal");
        Console.Write("Enter number of family members to register: ");
        int familyCount = Convert.ToInt32(Console.ReadLine());
        // Module 2: Loops & Logic
        for (int i = 1; i <= familyCount; i++){
            Console.WriteLine($"\nRegistering Family Member #{i}");
            // Module 1: Variables
            string name;
            int age;
            double income;
            int residencyYears;
            // Module 1: Input
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Age: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Annual Income: ");
            income = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Years of Residency: ");
            residencyYears = Convert.ToInt32(Console.ReadLine());
            // Module 2: Validation using continue
            if (age <= 0 || income < 0 || residencyYears < 0){
                Console.WriteLine("Invalid input. Skipping.");
                continue;
            }
            // Module 1 & 2: Eligibility calculation
            int eligibilityScore = 0;

            if (age >= 18){
                if (age <= 60){
                    eligibilityScore += 40;
                }else{
                    eligibilityScore += 20;
                }
            }
            else{
                eligibilityScore += 10;
            }
            if (income < 500000){
                eligibilityScore += 30;
            }else if (income < 1000000){
                eligibilityScore += 20;
            }else{
                eligibilityScore += 10;
            }
            if (residencyYears >= 5){
                eligibilityScore += 30;
            }else{
                eligibilityScore += 10;
            }
            // Module 2: Ternary operator
            string status = (eligibilityScore >= 60)? "Eligible": "Not Eligible";
            // Module 2: Switch statement
            // convert score into category
            int category;
            if (eligibilityScore >= 80){
                category = 3;
            }else if (eligibilityScore >= 60){
                category = 2;
            }else if (eligibilityScore >= 40){
                category = 1;
            }else{
                category = 0;
            }
            // normal switch-case
            string servicePackage;
            switch (category){
            case 3:
                servicePackage = "Platinum";
                break;
            case 2:
                servicePackage = "Gold";
                break;
            case 1:
                servicePackage = "Silver";
                break;
            default:
                servicePackage = "Basic";
                break;
            }
            // Module 1: Output
            Console.WriteLine("\nCitizen Information Summary");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Eligibility Score: {eligibilityScore}");
            Console.WriteLine($"Status: {status}");
            Console.WriteLine($"Service Package: {servicePackage}");
            // Module 2: Break example
            Console.Write("\nDo you want to stop? (yes/no): ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes"){
                break;
            }
        }
  
  
        // Module 3: Smart Citizen Database (Arrays)
       
       

        // 1D Array - store sample citizen IDs
        int[] citizenIDs = { 105, 102, 110, 101, 108 };
        Console.WriteLine("\nOriginal Citizen IDs:");
        foreach (int id in citizenIDs){
            Console.Write(id + " ");
        }
        // Sorting
        Array.Sort(citizenIDs);
        Console.WriteLine("\nSorted Citizen IDs:");
        foreach (int id in citizenIDs) {
            Console.Write(id + " ");
        }
        // Searching
        Console.Write("\nEnter Citizen ID to search: ");
        int searchID = Convert.ToInt32(Console.ReadLine());
        int index = Array.IndexOf(citizenIDs, searchID);

        if (index != -1)
            Console.WriteLine("Citizen ID found at index: " + index);
        else
        Console.WriteLine("Citizen ID not found.");
        // 2D Array - Zones & Sectors
        int[,] zoneSector = {
            {120, 150, 130},
            {100, 140, 160},
            {180, 170, 150},
            {110, 115, 125},
            {200, 210, 190}
        };
        Console.WriteLine("\nZone-wise Sector Citizen Count:");
        for (int i = 0; i < 5; i++){
            Console.WriteLine("Zone " + (i + 1) + ":");
            for (int j = 0; j < 3; j++)
        {
            Console.WriteLine("  Sector " + (j + 1) + " → " + zoneSector[i, j]);
        }
    }
        Console.WriteLine("\nThank you for using TechVille System!");
    }
}