using System;
class  HarshadNumber{
	 public static void Main(string[] args){
        //ask user to input a number
        int n= int.Parse(Console.ReadLine());
		int org=n;
		//initialise sum with 0
		int sum=0;
		while(n!=0){
			int rem=n%10;
			sum=sum+rem;
			n=n/10;
		}
		//check if number is divisible by sum of digits or not
		if(org%sum==0){
			Console.WriteLine("The number is a Harshad Number");
		}
		else{
			Console.WriteLine("The number is not a Harshad Number");
		}
	 }
}
			