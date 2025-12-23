using System;
class PrintOddEven{
	public static void Main(string[] args){
		int n=int.Parse(Console.ReadLine());
		for(int i=1;i<=n;i++){
			if(i%2==0){
				Console.WriteLine(i+" is a Even number");
			}
			else{
				Console.WriteLine(i +" is a Odd number");
			}
		}
	}
}
