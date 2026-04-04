using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.methods.level3
{
    internal class OtpCheck
    {


        static Random rand = new Random(); // single Random object

        public static void Main(string[] args)
        {
            int[] otpArray = new int[10]; // store OTPs

            // Generate 10 OTPs
            for (int i = 0; i < 10; i++)
            {
                otpArray[i] = GenerateOTP();
            }

            // Display generated OTPs
            Console.WriteLine("Generated OTPs:");
            foreach (int otp in otpArray)
            {
                Console.WriteLine(otp);
            }

            // Check uniqueness
            bool unique = AreUnique(otpArray);
            Console.WriteLine("\nAre all OTPs unique? " + unique);
        }

        // Generate a 6-digit OTP
        public static int GenerateOTP()
        {
            return rand.Next(100000, 1000000); // use the static Random object
        }

        // Check if all OTPs are unique
        public static bool AreUnique(int[] otps)
        {
            for (int i = 0; i < otps.Length; i++)
            {
                for (int j = i + 1; j < otps.Length; j++)
                {
                    if (otps[i] == otps[j])
                        return false; // duplicate found
                }
            }
            return true; // all unique
        }
    }
}
