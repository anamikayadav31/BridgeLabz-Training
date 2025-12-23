using System;
class CountDigits{
	 public static void Main(string[] args){
        //ask user to input a number
        int n= int.Parse(Console.ReadLine());
		//initialise count with 0
		int count=0;
		//iterate a loop until number is not equal to 0
		while(n!=0){
			n=n/10;
			count++;//increase count
		}
		Console.WriteLine(count);
	 }
}