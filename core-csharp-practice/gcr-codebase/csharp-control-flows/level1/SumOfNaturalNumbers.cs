using System;
class SumOfNaturalNumbers{
	public static void Main(string[] args){
		int n=int.Parse(Console.ReadLine());
		int sum=0;
		int i=1;
		while(i<n){
			if(i>0){
				sum+=i;
				i++;
			}
			else{
				Console.WriteLine(i+" is not a natural number");
			}
		}
		Console.WriteLine("The sum of "+n+" natural number is "+sum);
	}
}