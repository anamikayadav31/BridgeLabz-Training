using System;
class FindFactors{
	public static void Main(string[] args){
		//ask user user to input a number
        int number = int.Parse(Console.ReadLine());
		for(int i=1;i<number;i++){
			if(number%i==0){
				Console.WriteLine(i);
			}
		}
	}
}
