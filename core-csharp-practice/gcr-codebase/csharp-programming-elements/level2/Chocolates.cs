using System;

class Chocolates{
    public static void Main(string[] args){
		//ask user to input no. of chocolates
        int chocolates = int.Parse(Console.ReadLine());
		//ask user to input no. of childrens
        int children = int.Parse(Console.ReadLine());
		//compute chocolates per child
        int chocolatesEach = chocolates / children;
		// compute remaining chocolates
        int remChocolates = chocolates % children;
        Console.WriteLine("The number of chocolates each child gets is " 
            + chocolatesEach + 
            " and the number of remaining chocolates is " 
            + remChocolates);
    }
}
