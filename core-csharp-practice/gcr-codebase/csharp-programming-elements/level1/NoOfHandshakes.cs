using System;
class NoOfHandshakes{
	public static void Main(string[] args){
		//ask user to take no of students
		int n=int.Parse(Console.ReadLine());
		//calculate possible handshakes
		int hand=(n*(n-1))/2;
		//print output
		Console.WriteLine("The Number of Possible Handshakes "+hand);
	}
}
