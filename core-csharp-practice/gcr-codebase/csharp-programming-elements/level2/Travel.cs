using System;

class Travel
{
    public static void Main(string[] args)
    {
        // Ask user to input their name
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        // Ask user to input starting city
        Console.WriteLine("Enter starting city:");
        string fromCity = Console.ReadLine();

        // Ask user to input via city
        Console.WriteLine("Enter via city:");
        string viaCity = Console.ReadLine();

        // Ask user to input destination city
        Console.WriteLine("Enter destination city:");
        string toCity = Console.ReadLine();

        // Ask user to input distance from start to via city
        Console.WriteLine("Enter distance from start city to via city (in km):");
        int fromToVia = int.Parse(Console.ReadLine());

        // Ask user to input time taken
        Console.WriteLine("Enter time taken from start city to via city (in hours):");
        int timeTaken1 = int.Parse(Console.ReadLine());

        // Ask user to input distance from via city to destination
        Console.WriteLine("Enter distance from via city to destination (in km):");
        int viaToFinalCity = int.Parse(Console.ReadLine());

        // Ask user to input time taken
        int timeTaken2 = int.Parse(Console.ReadLine());

        int totalDis = fromToVia + viaToFinalCity;
        int totalTime = timeTaken1 + timeTaken2;

        Console.WriteLine(
            "The Total Distance travelled by " + name +
            " from " + fromCity +
            " to " + toCity +
            " via " + viaCity +
            " is " + totalDis +
            " km and the Total Time taken is " +
            totalTime + " hours"
        );
    }
}

	  
	  
	  

