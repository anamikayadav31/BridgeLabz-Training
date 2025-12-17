import java.util.*;
public  class perimeter_of_rectangle{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter length
        double length=sc.nextDouble();
        //Ask the user to enter width
        double width=sc.nextDouble();
        //calculate perimeter of rectangle
        double perimeter=2*(length*width);
        //print perimeter 
        System.out.println(perimeter);
    }
}