using System;
class DoubleOpt{
	public static void Main(string[] args){
	double a=double.Parse(Console.ReadLine());
	//ask user to input a number
	double b=double.Parse(Console.ReadLine());
	//ask user to input a number
	double c=double.Parse(Console.ReadLine());
	//perform operations
	double p=a+b*c;
	double q=a*b+c;
	double r=c+a/b;
	double s=a%b+c;
	//print results
	Console.WriteLine("The results of Int Operations are "+p+", "+q+", "+
	r+" and "+s);
	}
}