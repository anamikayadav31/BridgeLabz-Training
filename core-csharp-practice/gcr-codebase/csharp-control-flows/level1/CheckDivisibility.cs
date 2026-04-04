using System;
class CheckDivisibility{
	public static void Main(string[] args){
		//ask user to input a number
		int n=int.Parse(Console.ReadLine());
		if(n%5==0){
			Console.WriteLine("The number is divisible by 5");
		}else{
			Console.WriteLine("The number is not divisible by 5");
		}
	}
}
			