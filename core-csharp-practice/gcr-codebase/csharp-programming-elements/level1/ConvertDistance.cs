using System;
class ConvertDistance{
	public static void Main(string[] args){
		//distance in kilometers
		double distanceInKm=10.8;
		//convert distance from km to miles(1km=1.6 miles)
		double miles=0.621*distanceInKm;
		//print distance in miles
		Console.WriteLine("The distance "+distanceInKm+" km in miles is "+miles);
	}
}