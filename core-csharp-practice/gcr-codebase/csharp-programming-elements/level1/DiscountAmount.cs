using System;
class DiscountAmount{
	public static void Main(string[] args){
		//total fees
		int fee=125000;
		//discount percentage
		int dis=10;
		//calculate discount amount
		int discountAmount=(fee*dis)/100;
		//calculate discounted fees
		int discountedfees=fee-discountAmount;
		Console.WriteLine("The discount amount is INR "+discountAmount+
		" and final discounted fee is INR "+discountedfees);
	}
}