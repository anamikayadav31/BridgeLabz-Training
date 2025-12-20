class SimpleInterest2{
	public static void Main(string[] args){
		//take principal amount as input
		int p=int.Parse(Console.ReadLine());
		//take rate as input
		int r=int.Parse(Console.ReadLine());
		//take time as input
		int t=int.Parse(Console.ReadLine());
		//calculate simpleinterst using formula
		int si=(p*r*t)/100;
		//print si
		Console.WriteLine("The Simple Interest is "+si+" for Principal "+p+
		",  Rate of Interest "+r+" and Time "+t);
	}
}