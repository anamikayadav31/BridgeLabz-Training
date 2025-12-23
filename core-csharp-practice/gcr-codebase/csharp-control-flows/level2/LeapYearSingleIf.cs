using System;
class LeapYearSingleIf{
    public static void Main(string[] args){
		//ask user to input a year
        int year=int.Parse(Console.ReadLine());
		//check condition for a leap year 
        if (year>=1582 && (year%400==0 || (year%4==0 && year%100!=0))){
            Console.WriteLine("Year is a Leap Year");
        }
        else{
            Console.WriteLine("Year is not a Leap Year");
        }
    }
}
