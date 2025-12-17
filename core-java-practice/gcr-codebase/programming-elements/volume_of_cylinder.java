import java.util.*;
public  class volume_of_cylinder{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter radius of cylinder
        double radius=sc.nextDouble();
        //Ask the user to enter height
        double height=sc.nextDouble();
        //calculate volume of cylinder
        double volume=(double)(3.14*(radius*radius)*height);
        //print volume
        System.out.println(volume);

    }
}