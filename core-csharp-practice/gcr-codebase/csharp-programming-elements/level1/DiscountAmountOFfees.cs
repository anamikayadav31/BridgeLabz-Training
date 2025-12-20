using System;
class DiscountAmountOFfees{
	public static void Main(string[] args){
		//ask user to take total fees as input
		int fee=int.Parse(Console.ReadLine());
		//ask user to take discount percentage
		int discountPercent=int.Parse(Console.ReadLine());
		//calculate discount amount
		int discountAmount=(fee*discountPercent)/100;
		//calculate discounted fees
		int discountedfees=fee-discountAmount;
		Console.WriteLine("The discount amount is INR "+discountAmount+
		" and final discounted fee is INR "+discountedfees);
	}
}