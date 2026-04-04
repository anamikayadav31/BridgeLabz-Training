using System;
class  AbundantNumber{
	 public static void Main(string[] args){
        //ask user to input a number
        int n=int.Parse(Console.ReadLine());
		//initialise sum to 0
		int sum=0;
		for(int i=1;i<n-1;i++){
			if(n%i==0){
				sum=sum+i;
			}
		}
		//check if sum of digits ids greater than number or not
		if(sum>n){
			Console.WriteLine("This is an Abundant Number");
		}else{
			Console.WriteLine("This is not an Abundant Number");
		}
			
	 }
}
		