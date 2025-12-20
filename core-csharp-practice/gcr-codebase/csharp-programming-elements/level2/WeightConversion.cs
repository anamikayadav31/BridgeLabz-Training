using System;

class WeightConversion{
    public static void Main(string[] args){
		//ask user to input weight in pounds
        double w = double.Parse(Console.ReadLine());
		//convert weight into kgs
		double wkg=w/2.2;
		Console.WriteLine("The weight of the person in pounds is "+w+" and in kg is "+wkg);
	}
}