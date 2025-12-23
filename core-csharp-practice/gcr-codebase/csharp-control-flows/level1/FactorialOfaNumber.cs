using System;
class FactorialOfaNumber{
	public static void Main(string[] args){
		//ask user to input number
		int n= int.Parse(Console.ReadLine());
		//create a variable initialize with 1
		int fact=1;
		//loop until n is grater than zero
		while(n>0){
			fact=fact*n;
			n--;
		}
		//print factorial
		Console.WriteLine("Factorial is "+fact);
	}
}