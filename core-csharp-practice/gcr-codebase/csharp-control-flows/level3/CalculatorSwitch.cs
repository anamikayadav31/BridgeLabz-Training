using System;
class CalculatorSwitch{
		public static void Main(string[] args){
        //ask user to input a number
        double a=double.Parse(Console.ReadLine());
		//ask user to input a number
		double b=double.Parse(Console.ReadLine());
		//ask user to input a string(operators)
		string op=Console.ReadLine()!;
		switch(op){
			case"+":
			Console.WriteLine("result= "+(a+b));
			break;
			case"-":
			Console.WriteLine("result= "+(a-b));
			break;
			case"*":
			Console.WriteLine("result= "+(a*b));
			break;
			case"/":
			if(b!=0){
				Console.WriteLine("result= "+(a/b));
			}
			else{
				Console.WriteLine("Cannot divided by zero");
			}
			break;
			default:
			Console.WriteLine("Invalid operator");
			break;
		}
		
		}
}
			
			
		
		
