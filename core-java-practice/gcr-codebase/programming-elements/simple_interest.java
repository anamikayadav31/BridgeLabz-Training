import java.util.*;
public  class simple_interest{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter principal amount
        int principal=sc.nextInt();
        //Ask the user to enter rate per year
        int rate=sc.nextInt();
        //Ask the user to enter no of years
        int time=sc.nextInt();
        //calculate simple interest
        int si=(principal*rate*time)/100;
        //print si
        System.out.println(si);
    }
}