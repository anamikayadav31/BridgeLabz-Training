using System;
class ConvertcmTofeet{
	public static void Main(string[] args){
		//ask user to take height in cms
		double height=double.Parse(Console.ReadLine());
		//convert height cm to inch
		double inch=height/2.54;
		//convert height inches to foot
		double foot=inch/12;
		Console.WriteLine("Your Height in cm is "+height+" while in feet is "+foot+" and inches is "+inch);
	}
}
	