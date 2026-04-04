using System;
using System.Collections.Generic;

// Custom exception class for robot safety-related errors
class RobotSafetyException : Exception
{
    // Constructor that passes the error message to the base Exception class
    public RobotSafetyException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prompt user for robot arm precision
            Console.WriteLine("Enter Arm Precision(0.0 -1.0):");
            double armPrecision = double.Parse(Console.ReadLine());

            // Prompt user for number of workers near the robot
            Console.WriteLine("Enter Worker Density(1 - 20):");
            int workerDensity = int.Parse(Console.ReadLine());

            // Prompt user for machinery condition
            Console.WriteLine("Enter Machinery State(Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            // Create Program object to call instance method
            Program p = new Program();

            // Calculate the hazard risk score
            double risk = p.CalculateHazardRisk(armPrecision, workerDensity, machineryState);

            // Display the calculated risk score
            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }
        // Catch and display custom robot safety errors
        catch (RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Method to calculate robot hazard risk based on inputs
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validate arm precision range
        if (armPrecision < 0.0 || armPrecision > 1.0)
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");

        // Validate worker density range
        if (workerDensity < 1 || workerDensity > 20)
            throw new RobotSafetyException("Error: Worker density must be 1-20");

        // Dictionary mapping machinery state to risk multiplier
        Dictionary<string, double> hash = new Dictionary<string, double>();
        hash.Add("Worn", 1.3);
        hash.Add("Faulty", 2.0);
        hash.Add("Critical", 3.0);

        // Check if machinery state is supported
        if (!hash.ContainsKey(machineryState))
            throw new RobotSafetyException("Error: Unsupported machinery state");

        // Get risk factor based on machinery condition
        double machineRiskFactor = hash[machineryState];

        // Calculate final hazard risk score
        double risk = ((1.0 - armPrecision) * 15.0) +
                      (workerDensity * machineRiskFactor);

        return risk;
    }
}
