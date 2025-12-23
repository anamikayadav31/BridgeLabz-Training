using System;
class SumOfnNaturalNumbers{
	public static void Main(string[] args){
		//ask user to input number
		int n= int.Parse(Console.ReadLine());
		//calculate sum of n natural numbers using formula
		int formula=(n*(n+1))/2;
		//take a variable to store sum
		int sum=0;
		//sum of n natural numbers using loop
		while(n>=0){
			sum+=n;
			n--;
		}
		//compare both results
		if(formula==sum){
			Console.WriteLine("Both computations are correct");
		}else{
			Console.WriteLine("Both computations are not correct");
		}
			
			
	}
}