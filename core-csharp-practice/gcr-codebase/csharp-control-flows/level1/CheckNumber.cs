using System;
class CheckNumber{
	public static void Main(string[] args){
		//ask user to input a number 
		int num=int.Parse(Console.ReadLine());
		//check number is greater than 0 if yes print positive
		if(num>0){
			Console.WriteLine("Positive");
		}
		//check number is less than 0 if yes print negative
		else if(num<0){
			Console.WriteLine("Negative");
		}
		else{
			Console.WriteLine("Zero");
		}
	}
}