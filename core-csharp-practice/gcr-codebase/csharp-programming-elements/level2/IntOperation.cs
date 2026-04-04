using System;
class IntOperation{
	//ask user to input a number
	public static void Main(string[] args){
	int a=int.Parse(Console.ReadLine());
	//ask user to input a number
	int b=int.Parse(Console.ReadLine());
	//ask user to input a number
	int c=int.Parse(Console.ReadLine());
	//perform operations
	int p=a+b*c;
	int q=a*b+c;
	int r=c+a/b;
	int s=a%b+c;
	//print results
	Console.WriteLine("The results of Int Operations are "+p+", "+q+", "+
	r+" and "+s);
}
}

