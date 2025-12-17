
import java.util.Scanner;

public class palindrome{
    public static void main(String[] args) {
        Scanner sc=new Scanner(System.in);
         // Ask the user to enter a string
        String s=sc.nextLine();
        //take a empty string r
        String r="";
        for(int i=s.length()-1;i>=0;i--){
            r+=s.charAt(i);
        }
        System.out.println(r.equals(s));
    }
}