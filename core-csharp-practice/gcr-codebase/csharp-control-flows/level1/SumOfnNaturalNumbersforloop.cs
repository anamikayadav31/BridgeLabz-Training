using System;
class SumOfnNaturalNumbersforloop{
	public static void Main(string[] args){
		//ask user to input number
		int n= int.Parse(Console.ReadLine());
		//calculate sum of n natural numbers using formula
		int formula=(n*(n+1))/2;
		//take a variable to store sum
		int sum=0;
		//sum of n natural numbers using loop
		for(int i=n;i>=0;i--){
			sum+=i;
			
		}
		//compare both results
		if(formula==sum){
			Console.WriteLine("Both computations are correct");
		}else{
			Console.WriteLine("Both computations are not correct");
		}
			
			
	}
}