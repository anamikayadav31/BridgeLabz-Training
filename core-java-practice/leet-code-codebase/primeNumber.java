import java.util.*;

public class primeNumber {
        public static void main(String[] args) {
        // Create Scanner object to read input
        Scanner sc = new Scanner(System.in);
        // Ask user to enter a number
        int num = sc.nextInt();
        // Prime numbers are greater than 1
        boolean isPrime = true;
        if (num <= 1) {
            isPrime = false;
        } else {
            for (int i = 2; i <= num / 2; i++) {
                if (num % i == 0) {
                    isPrime = false;
                    break;
                }
            }
        }
        if (isPrime) {
            System.out.println("prime");
        } else {
            System.out.println("Not Prime");
        }
    }
}
