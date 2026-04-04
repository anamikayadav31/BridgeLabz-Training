using System;

class GreatestFactor{
    public static void Main(string[] args){
        //ask user user to input a number
        int number = int.Parse(Console.ReadLine());
        // initialise greatestFactor as 1
        int greatestFactor = 1;
        // Loop from number-1 down to 1
        for (int i=number-1;i>=1;i--){
            // Check if number is divisible by i
            if (number % i == 0){
                greatestFactor = i;
                break;//break out the loop if we find greatest factor
            }
        }
        // print result
        Console.WriteLine("The greatest factor of the number is " + greatestFactor);
    }
}
