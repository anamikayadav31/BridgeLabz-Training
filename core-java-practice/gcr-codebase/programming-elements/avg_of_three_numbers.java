import java.util.*;
public  class avg_of_three_numbers{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter 1st number
        int a=sc.nextInt();
        //Ask the user to enter 2nd number
        int b=sc.nextInt();
        //Ask the user to enter 3rd number
        int c=sc.nextInt();
        //calculate average
        int avg=(a+b+c)/3;
        //print avg
        System.out.println(avg);
    }
}