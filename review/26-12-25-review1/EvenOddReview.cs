using System;
class EvenOddReview{
	public static void Main(string [] args){
		int n=int.Parse(Console.ReadLine());
		int [] arr=new int[n];
		for(int i=0;i<arr.Length;i++){
			arr[i]=int.Parse(Console.ReadLine());
		}
		int c=0;
        int c2=0;
		for(int i=0;i<arr.Length;i++){
			
			
			if(arr[i]%2==0){
			c++;
			}
			else{
			c2++;
			}
		}
		int [] even=new int[c];
		int [] odd=new int[c2];
		int idx=0;
		int idx2=0;
		for(int i=0;i<arr.Length;i++){
			if(arr[i]%2==0){
				even[idx]=arr[i];
				idx++;
			}
			else{
				odd[idx2]=arr[i];
				idx2++;
			}
		}
		for(int i=0;i<idx;i++){
			Console.WriteLine("even numbers:"+even[i]);
		
		}
		for(int i=0;i<idx2;i++){
			Console.WriteLine("odd numbers"+odd[i]);
		}
		
	}
}
		
	