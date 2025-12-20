using System;

class SquarePerimeter{
    public static void Main(string[] args){
        //ask user to take perimeter
        double perimeter = double.Parse(Console.ReadLine());
		//calculate side 
        double side = perimeter / 4;
        //print output
        Console.WriteLine("The length of the side is " + side + " whose perimeter is " + perimeter);
    }
}
