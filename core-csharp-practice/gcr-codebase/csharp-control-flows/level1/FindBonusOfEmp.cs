using System;
class FindBonusOfEmp{
	public static void Main(string[] args){
		//ask user to input salary
		int salary=int.Parse(Console.ReadLine());
		//ask user to input years of service
		int years=int.Parse(Console.ReadLine());
		//take a variable to store bonus amount
		double bonus=0;
		//check either years of serviceis more than 5 or not
		if(years>5){
			bonus=salary*0.05;
		}
		Console.WriteLine("The bonus amount of employee is "+bonus);
		
	}
}
		
