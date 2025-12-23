using System;
class  PrimeOrNot{
	public static void Main(string[] args){
		//ask user to input a number 
		int n=int.Parse(Console.ReadLine());
		bool isPrime=true;
		//check if number is less than equals to 1 ,is not a prime number
		if(n<=1){
			isPrime=false;
		}
		//loop though all the numbers from 2 to n
		for(int i=2;i<n;i++){
			if(n%i==0){
				isPrime=false;
			    break;
			}
		}
		//print result
		Console.WriteLine(isPrime);
	}
}
			