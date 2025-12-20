using System;
class PenDistribution{
	public static void Main(string[] args){
		//number of pens
		int pen=14;
		//number of students
		int student=3;
		//calculate per student pen 
		int x=pen/student;
		//remaining pen 
		int rem=pen%student;
		//print the output
		Console.WriteLine("The Pen Per Student is "+x+ " and the remaining pen not distributed is "+rem);
	}
}
		