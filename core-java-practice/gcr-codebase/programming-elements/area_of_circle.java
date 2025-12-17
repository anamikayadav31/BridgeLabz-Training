
import java.util.*;

public class area_of_circle{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter radius
        double radius=sc.nextDouble();
        //calculate area using formula
        double Area = (double)(3.14 *(radius*radius));
        //print area
        System.out.println(Area);
    }
}