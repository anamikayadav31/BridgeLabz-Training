import java.util.*;

public class factorial {
    public static void main(String[] args) {

        // Create Scanner object to take input from user
        Scanner sc = new Scanner(System.in);

        // Ask the user to enter a number
        int num = sc.nextInt();

        // Variable to store factorial result
        long factorial = 1;

        // Loop to calculate factorial
        for (int i = 1; i <= num; i++) {
            factorial = factorial * i;
        }

        // Print the factorial result
        System.out.println("Factorial of " + num);
    }
}
