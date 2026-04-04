using System;
class CheckNumberIsLargest{
	public static void Main(string[] args){
		//ask user to input  a number
		int number1=int.Parse(Console.ReadLine());
		//ask user to input  a number
		int number2=int.Parse(Console.ReadLine());
		//ask user to input  a number
		int number3=int.Parse(Console.ReadLine());
		//check if number 1 is greater than number2 and number3
		if(number1>number2 && number1>number3){
			Console.WriteLine("Yes,The first number is the largest of the 3 numbers");
		}
			//check if number 2 is greater than number1 and number3
		else if(number2>number1 && number2>number3){
			Console.WriteLine("Yes,The second number is the largest  of the 3 numbers");
		}
			//check if number 3 is greater than number2 and number1
		else if(number3>number1 && number3>number2){
			Console.WriteLine("Yes,The third number is the largest  of the 3 numbers");
		}
		
	}
}
			
