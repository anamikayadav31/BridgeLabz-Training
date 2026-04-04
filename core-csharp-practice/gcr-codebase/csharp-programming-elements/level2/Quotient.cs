using System;
class Quotient{
	public static void Main(string[] args){
		//ask user to input a number
		int a=int.Parse(Console.ReadLine());
		//ask user to input another number
		int b=int.Parse(Console.ReadLine());
		//calculate quotient
		int quotient=a/b;
		int rem=a%b;
		//calculate remainder
		Console.WriteLine("The Quotient is "+quotient+" and Remainder is "+rem+
		" of two numbers "+a+" and "+b);
	}
}
		