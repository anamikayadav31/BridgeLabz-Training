using System;

class DistanceConversion{
    public static void Main(string[] args){
        //ask user to take height
        double distanceInFeet =double.Parse(Console.ReadLine());
		//convert distance feet to yards
        double distanceInYards = distanceInFeet / 3;
		//convert distance yards to miles
        double distanceInMiles = distanceInYards / 1760;
		//print output
        Console.WriteLine("Distance in feet is " + distanceInFeet+" while in yards "+distanceInYards+" and miles is "+distanceInMiles);
       
	   
    }
}
