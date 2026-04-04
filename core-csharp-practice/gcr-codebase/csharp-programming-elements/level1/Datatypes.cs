using System;
class Datatypes{
	public static void Main(string[] args){
		//Datatypes
		//  variable a stores an whole numbers
		int a=4;
		Console.WriteLine(a);
		//variable b stores a character
		char b='c';
		Console.WriteLine(b);
		//variable c stores an integer value
		byte c=20;
		Console.WriteLine(c);
		//variable d stores an integer value
		short d=150;
		Console.WriteLine(d);
		//variable e stores small decimal value
		float e=85.5f;
		Console.WriteLine(e);
		//variable f stores default decimal value
		double f=4.0;
		Console.WriteLine(f);
		//variable g  stores very large whole numbers
		long g=45678934;
		Console.WriteLine(g);
		//variable h stores true or false
		bool h=true;
		Console.WriteLine(h);
		
		
		
		//Type Casting
		
		//Implicit conversion
		//convert int to double
		int num=7;
		double dd=num;
		Console.WriteLine(dd);
		//convert float to double
		float aa=8.44f;
		double bb=aa;
		Console.WriteLine(bb);
		//convert char to int
		char cc='e';
		int d1=cc;
		Console.WriteLine(d1);
		
		//Explicit conversion
		//double to float
		double d2=98.3;
		float f1=(float)d2;
		Console.WriteLine(f1);
		//long to float
		long l1=2345675678;
		float ff=(float)l1;
		Console.WriteLine(ff);
		//int to char
		int i1=5;
		char c1=(char)i1;
		Console.WriteLine(c1);
		
		
	
	}
}
		
		