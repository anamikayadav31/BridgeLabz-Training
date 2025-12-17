import java.util.*;
public  class celsius_to_fahrenheit{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter temperature in celcius
        double celsius=sc.nextDouble();
        //convert celsius into fahrenheit using formula
        double fahren=((celsius*9/5)+32);
        System.out.println(fahren);
    }
}