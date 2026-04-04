// See https://aka.ms/new-console-template for more information



using System;
using System.Collections.Generic;
namespace OceanFleetApp;


class UserInterface
{
    public static void Main(string[] args)
    {
        VesselUtil util = new VesselUtil();

        Console.WriteLine("Enter the number of vessels to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter vessel details");

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            string id = parts[0];
            string name = parts[1];
            double speed = double.Parse(parts[2]);
            string type = parts[3];

            Vessel v = new Vessel(id, name, speed, type);
            util.AddVesselPerformance(v);
        }

        Console.WriteLine("Enter the Vessel Id to check speed");
        string searchId = Console.ReadLine();

        Vessel found = util.GetVesselById(searchId);

        if (found != null)
        {
            Console.WriteLine($"{found.VesselId} | {found.VesselName} | {found.VesselType} | {found.AverageSpeed} knots");
        }
        else
        {
            Console.WriteLine($"Vessel Id {searchId} not found");
        }

        Console.WriteLine("High performance vessels are");

        List<Vessel> high = util.GetHighPerformanceVessels();

        foreach (Vessel v in high)
        {
            Console.WriteLine($"{v.VesselId} | {v.VesselName} | {v.VesselType} | {v.AverageSpeed} knots");
        }
    }
}