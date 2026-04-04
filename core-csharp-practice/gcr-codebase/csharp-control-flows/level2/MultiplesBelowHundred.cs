using System;
class MultiplesBelowHundred{
    public static void Main(string[] args){
        //ask user to input a number
        int number = int.Parse(Console.ReadLine());
        // Run loop backward from 100 to 1
        for (int i=100;i>=1;i--){
            // Check if i is a multiple of number
            if (i%number==0){
                Console.WriteLine(i);
            }
        }
    }
}
