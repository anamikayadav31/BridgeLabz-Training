using System;

class TotalPrice{
    public static void Main(string[] args){
		//ask user to take price per unit  as input
        double unitPrice = double.Parse(Console.ReadLine());
		//ask user to take quantity 
        int quantity = int.Parse(Console.ReadLine());
		//calculate the total price
        double totalPrice = unitPrice * quantity;
		//print output
        Console.WriteLine(
            "The total purchase price is INR " + totalPrice +
            " if the quantity " + quantity +
            " and unit price is INR " + unitPrice
        );
    }
}
