using System;
class SumOfTheNumbers{
	public static void Main(string[] args){
		//ask user to input number
		double n;
		//take a variable for storing total value
		double total=0.0; 
		//check loop until user entered value is equal to 0
		while(true){
			n=double.Parse(Console.ReadLine());
			if(n==0){
				break;
			}
			else{
			total=total+n;
			}
			
			
		}
		Console.WriteLine("Total value is "+total);
	}
}