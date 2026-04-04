using System;
class Countdown{
	public static void Main(string[] args){
		//ask user to input number
		int counter=int.Parse(Console.ReadLine());
		//check loop until counter's value is equal to 1
		for(int i=counter;i>=0;i--){
			Console.WriteLine("Counter's value is "+counter);
		}
	}
}
