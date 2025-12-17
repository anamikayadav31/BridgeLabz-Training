import java.util.*;
public class evenOdd{
    public static void main(String[] args){
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
         // Ask the user to enter a number
        int n=sc.nextInt();
        if(n%2==0){
            System.out.println("Even");
        }
        else{
            System.out.println("Odd");
        }

    }
}