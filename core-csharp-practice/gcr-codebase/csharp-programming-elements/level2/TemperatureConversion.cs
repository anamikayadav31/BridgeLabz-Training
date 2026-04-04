using System;
class TemperatureConversion{
	public static void Main(string[] args){
		//ask user to input temperature in celsius
		int temp=int.Parse(Console.ReadLine());
		//convert celsius to Fahrenheit
		int fahr=(temp*9/5)+32;
		//print output
		Console.WriteLine("The "+temp+" Celsius is "+fahr+" Fahrenheit");
	}
}