using System;
class PerimeterofTriangle{
    public static void Main(string[] args) {
		//ask user to input side1
        int side1 = int.Parse(Console.ReadLine());
		//ask user to input side2
        int side2 = int.Parse(Console.ReadLine());
		//ask user to input side3
        int side3 = int.Parse(Console.ReadLine());
        int distance = 5; 
		//calculate perimeter
        int p = side1 + side2 + side3; // perimeter in meters
        double perimeterInKm = p / 1000.0; // convert meters to km
		//compute rounds
        int rounds = (int)(distance / perimeterInKm);
		//print output
        Console.WriteLine(
            "The total number of rounds the athlete will run is " +
            rounds + " to complete 5 km"
        );
    }
}
