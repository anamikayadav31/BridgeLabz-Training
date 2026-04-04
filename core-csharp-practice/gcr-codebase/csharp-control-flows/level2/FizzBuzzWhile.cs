using System;
class FizzBuzzWhile{
	public static void Main(string[] args){
		//ask user to input a number 
		int num=int.Parse(Console.ReadLine());
		//check num is positive or not 
	
		if(num>0){
			int i=1;
		   while(i<=num){
				//if number is multiple of 3 and 5 ,print fizzbuzz
				if(i%3==0 && i%5==0){
					Console.WriteLine("FizzBuzz");
				}
				//if number is multiple of 3 ,print Fizz
				else if(i%3==0){
					Console.WriteLine("Fizz");
				}
				//if number is multiple of 5 ,print Buzz
				else if(i%5==0){
					Console.WriteLine("Buzz");
				}
				i++;
				
			}
		}
	}
}
			
