using System;
class Calculator{
	public static void Main(string[] args){
		//ask user to take first number
		float a=float.Parse(Console.ReadLine());
		//ask user to take second number
		float b=float.Parse(Console.ReadLine());
		//perform addition
		float addition=a+b;
		//perform substraction
		float sub=a-b;
		//perform multiplication
		float multiply=a*b;
		//perform division
		float division=a/b;
		//print output
		Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers "+a+ " and "+b+" is "+addition+", "+sub+", "+multiply+",and "+division);
	}
}
		
		