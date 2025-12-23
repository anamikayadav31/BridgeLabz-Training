using System;
class AvgOfSubjects{
	public static void Main(string[] args){
		//ask user to input marks in physics
		int physics=int.Parse(Console.ReadLine());
		//ask user to input marks in chemistry
		int chemistry=int.Parse(Console.ReadLine());
		//ask user to input marks in maths
		int maths=int.Parse(Console.ReadLine());
		//compute total of three subjects
		int total=physics+chemistry+maths;
		//compute percentage
		double percentage=total/3.0;
		//print grades and percentage by checking some conditions
		if(percentage>=80){
			Console.WriteLine("Percentage is "+percentage+" and grade is A");
		}
		else if(percentage>70 && percentage<80){
			Console.WriteLine("Percentage is "+percentage+" and grade is B");
		}
		else if(percentage>60 && percentage<70){
			Console.WriteLine("Percentage is "+percentage+" and grade is C");
		}
		else if(percentage>50 && percentage<60){
			Console.WriteLine("Percentage is "+percentage+" and grade is D");
		}
		else if(percentage>40 && percentage<50){
			Console.WriteLine("Percentage is "+percentage+" and grade is E");
		}
		else if(percentage<=39){
			Console.WriteLine("Percentage is "+percentage+" and grade is R");
		}
	}
}
			
		