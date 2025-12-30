using System;
class CelsiusToFahrenheit{
	public static void Main(string[] args){
		//Ask user to input temperature in celsius
		int celsius=int.Parse(Console.ReadLine());
		//covert temperature celsius to fahrenheit
		int fahr=(celsius*9/5)+32;
		//print temperature in fahrenheit
		Console.WriteLine(fahr);
	}
}