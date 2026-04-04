using System;
class TemperatureConvert{
	public static void Main(string[] args){
		//ask user to input temperature in Fahrenheit
		int temp=int.Parse(Console.ReadLine());
		//convert  Fahrenheit to celsius
		int celsius=(temp-32)*5/9;
		//print output
		Console.WriteLine("The "+temp+" Fahrenheit is "+celsius+" Celsius");
	}
}