using System;
class MultiplicationTable{
	public static void Main(string[] args){
		//ask user to input a number 
		int n=int.Parse(Console.ReadLine());
		//loop from 1 to 10 
		for(int i=1;i<=10;i++){
			Console.WriteLine(n+" x "+i+" = "+n*i);
		}
	}
}
		