using System;
class Swapping{
	//ask user to input a number
	public static void Main(string[] args){
	int a=int.Parse(Console.ReadLine());
	//ask user to input a number
	int b=int.Parse(Console.ReadLine());
	//swap both users 
	int temp=a;
	a=b;
	b=temp;
	//print
	Console.WriteLine("The swapped numbers are "+a+" and "+b);
	}
}