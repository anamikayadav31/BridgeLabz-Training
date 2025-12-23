using System;
class SpringSeason{
	public static void Main(string[] args){
		//ask user to input month 
		int month=int.Parse(Console.ReadLine());
		//ask user to input date
		int date=int.Parse(Console.ReadLine());
		//check month and date is between 20 March to 20 June or not
		if(month==3 && date>=20
		|| month==4 
		||month==5 
		||month==6 &&date>=20 ){
			Console.WriteLine("It is a Spring season");
		}
		else{
			Console.WriteLine("Not a Spring season");
		}
	}
}
			
		