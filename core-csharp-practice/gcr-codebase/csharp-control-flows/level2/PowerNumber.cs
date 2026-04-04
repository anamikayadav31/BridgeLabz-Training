using System;
class PowerNumber{
	public static void Main(string[] args){
		
	    //ask user user to input a number
        int number= int.Parse(Console.ReadLine());
	    //ask user user to input a number
        int power= int.Parse(Console.ReadLine());
		//intialise result with 1;
		int result=1;
		for(int i=1;i<=power;i++){
			result=result*number;
		}
		//print the result
		Console.WriteLine("The result is "+result);
	}
}
