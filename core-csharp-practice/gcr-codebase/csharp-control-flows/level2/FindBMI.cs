using System;
class FindBMI{
	public static void Main(string[] args){
		//ask user to input weight
		double w=double.Parse(Console.ReadLine());
		//ask user to input height
		double hh=double.Parse(Console.ReadLine());
		double h=hh/100.0;
		//compute bmi using formula 
		double bmi=w/(h*h);
		//check some conditions and print weight status
		if(bmi<=18.4){
			Console.WriteLine("Weight status is underweight");
		}else if(bmi>=18.5 && bmi<=24.9){
			Console.WriteLine("Weight status is normal");
		}
		else if(bmi>=25.0 && bmi<=39.9){
			Console.WriteLine("Weight status is overweight");
		}
		else if(bmi>=40.0){
			Console.WriteLine("Weight status is obese");
		}
			
	}
}
