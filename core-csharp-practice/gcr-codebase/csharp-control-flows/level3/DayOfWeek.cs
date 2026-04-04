using System;
class DayOfWeek{
	public static void Main(string[] args){
        //ask user to input month
        int m = int.Parse(args[0]); 
		// ask user to input day
        int d = int.Parse(args[1]); 
		  //ask user to input year
		int y = int.Parse(args[1]); 
		//compute using formulas
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;
		Console.WriteLine("Day of the week is "+d0);
	}
}
		
