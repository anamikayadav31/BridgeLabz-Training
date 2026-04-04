using System;
class CountNumbers{
	public static void Main(string[] args){
		//ask user to input number
		int counter=int.Parse(Console.ReadLine());
		
		//check loop until counter's value is equal to 1
		while(counter>=1){
			Console.WriteLine("Counter's value is "+counter);
			counter--;
		}
	}
}
