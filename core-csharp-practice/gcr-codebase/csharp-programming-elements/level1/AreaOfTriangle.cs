using System;
class AreaOfTriangle{
	public static void Main(string[] args){
		double b=double.Parse(Console.ReadLine());
		//ask user to take height in cms
		double height=double.Parse(Console.ReadLine());
		//calculate area
		double Area= (0.5)*b*height;
		//convert cm to inches
		double inch=Area/2.54;
		//convert inch to feet
		double feet=inch/12;
		Console.WriteLine("Your Area in cm is "+height+" while in feet is "+feet+"and inches is "+inch);
	}
}