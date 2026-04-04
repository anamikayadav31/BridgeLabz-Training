using System;
class CheckAgeIsYoungest{
	public static void Main(string[] args){
		//ask Amar to input   his age
		int Amar=int.Parse(Console.ReadLine());
		//ask Akbar to input   his age
		int Akbar=int.Parse(Console.ReadLine());
		//ask Anthony to input   his age
		int Anthony=int.Parse(Console.ReadLine());
		//check if Akbar is  younger than Akbar and Anthony
		if(Amar<Akbar && Amar<Anthony){
			Console.WriteLine("Yes,The Amar is the youngest of the 3");
		}
			//check if number 2 is younger than Amar and Anthony
		else if(Akbar<Amar && Akbar<Anthony){
			Console.WriteLine("Yes,The Akbar is the youngest  of the 3");
		}
			//check if number 3 is younger than Akbar and Amar
		else if(Anthony<Amar && Anthony<Akbar){
			Console.WriteLine("Yes,The Anthony is the youngest  of the 3");
		}
		
	}
}