using System;
class ProfitLoss{
	public static void Main(string[] args){
		//costprice 
		int costprice=129;
		//selling price 
		int sellprice=191;
		//calculate profit
		double profit=sellprice-costprice;
		//calculate profit percentage
		double pp=(profit/costprice)*100;
		Console.WriteLine("The Cost Price in INR "+costprice+" and Selling Price is INR "+sellprice);
		Console.WriteLine("The Profit is INR "+profit+" and the Profit Percentage is "+pp);
		
	}
}