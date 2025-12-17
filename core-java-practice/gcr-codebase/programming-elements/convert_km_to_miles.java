import java.util.*;
public  class convert_km_to_miles{
    public static void main(String[] args) {
        // Create Scanner object to take input from user
        Scanner sc=new Scanner(System.in);
        //Ask the user to enter kilometeres
        double km=sc.nextDouble();
        //convert km into miles using formula
        double miles=(km)*(0.621371);
        //print miles
        System.out.println(miles);
    }
}

