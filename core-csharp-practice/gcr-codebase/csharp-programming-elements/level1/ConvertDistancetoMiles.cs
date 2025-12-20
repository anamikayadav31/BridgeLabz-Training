using System;
class ConvertDistancetoMiles{
	public static void Main(string[] args){
		//take distance in km from user
		double km=double.Parse(Console.ReadLine());
		//convert distance from km to miles(1km=1.6 miles)
		double miles=0.621*km;
		//print distance in miles
		Console.WriteLine("The total miles is "+miles+" mile for the given "+km+" km");
	}
}