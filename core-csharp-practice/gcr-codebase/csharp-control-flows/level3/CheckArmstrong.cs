using System;
class  CheckArmstrong{
    public static void Main(string[] args){
        //ask user to input a number
        int n= int.Parse(Console.ReadLine());
		int sum=0;
		int orig=n;
		while(n!=0){
			int rem=n%10;
			sum=sum+(rem*rem*rem);
			n=n/10;
		}
		if(orig==sum){
			Console.WriteLine("The number is Armstrong");
		}
		else{
			Console.WriteLine("The number is not an Armstrong");
		}
			
	}
}