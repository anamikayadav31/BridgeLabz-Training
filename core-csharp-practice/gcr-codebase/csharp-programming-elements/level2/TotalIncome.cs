using System;
class TotalIncome{
	public static void Main(string[] args){
		//ask user to input salary
		int salary =int.Parse(Console.ReadLine());
		//ask user to input bonus
		int bonus =int.Parse(Console.ReadLine());
		//compute income
		int income=salary+bonus;
		//print result
		Console.WriteLine(" The salary is INR "+salary+" and bonus is INR "+bonus+
		" .Hence Total Income is INR "+income);
	}
}
		
