using System;
class FactorialOfaNumberForloop{
	public static void Main(string[] args){
		//ask user to input number
		int n= int.Parse(Console.ReadLine());
		//create a variable initialize with 1
		int fact=1;
		//loop until n is grater than zero
		for(int i=n;i>0;i--){
			fact=fact*i;
		
		}
		//print factorial
		Console.WriteLine("Factorial is "+fact);
	}
}