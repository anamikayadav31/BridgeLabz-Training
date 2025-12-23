using System;
class CheckFirstIsSmallest{
	public static void Main(string[] args){
		//ask user to input  a number
		int number1=int.Parse(Console.ReadLine());
		//ask user to input  a number
		int number2=int.Parse(Console.ReadLine());
		//ask user to input  a number
		int number3=int.Parse(Console.ReadLine());
		if(number1<number2 && number1<number3){
			Console.WriteLine("Yes,The first number is the smallest of the 3 numbers");
		}
		else{
			Console.WriteLine("The first number is not the smallest of the 3 numbers");
		}
	}
}
			
		