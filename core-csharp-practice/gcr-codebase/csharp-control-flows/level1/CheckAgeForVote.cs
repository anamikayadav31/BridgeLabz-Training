using System;
class CheckAgeForVote{
	public static void Main(string[] args){
		//ask user to input his age
		int age=int.Parse(Console.ReadLine());
		//check the age is greater than equal to 18 or not
		if(age>=18){
			Console.WriteLine("The person's age is "+age+" and can vote");
		}
		else{
			Console.WriteLine("The person's age is "+age+" and cannot  vote");
		}
	}
}
			