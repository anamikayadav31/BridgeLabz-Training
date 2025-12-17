import java.util.*;
public  class power_calculation{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter base
        int a=sc.nextInt();
        //Ask the user to enter exponent
        int b=sc.nextInt();
        //calculte power
        int x=(int)(Math.pow(a,b));
        System.out.println(x);
    }
}