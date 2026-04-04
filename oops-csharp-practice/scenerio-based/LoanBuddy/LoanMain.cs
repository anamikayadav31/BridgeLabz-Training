using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.LoanBuddy
{
    internal class LoanMain
    {


        static void Main(string[] args)
        {
            // Taking applicant input
            Console.WriteLine("Enter Applicant Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Credit Score:");
            int creditScore = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Monthly Income:");
            double income = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Loan Amount:");
            double loanAmount = double.Parse(Console.ReadLine());

            Applicant applicant = new Applicant(name, creditScore, income, loanAmount);

            // Loan type selection
            Console.WriteLine("\nSelect Loan Type:");
            Console.WriteLine("1. Home Loan");
            Console.WriteLine("2. Auto Loan");
            Console.WriteLine("3. Personal Loan");

            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Loan Tenure (months):");
            int tenure = int.Parse(Console.ReadLine());

            LoanApplication loan;

            if (choice == 1)
            {
                loan = new HomeLoan(tenure);
            }
            else if (choice == 2)
            {
                loan = new AutoLoan(tenure);
            }
            else
            {
                Console.WriteLine("Enter Interest Rate:");
                double rate = double.Parse(Console.ReadLine());
                loan = new PersonalLoan(tenure, rate);
            }

            // Loan approval result
            if (loan.ApproveLoan(applicant))
            {
                double emi = loan.CalculateEMI(
                    applicant.LoanAmount,
                    loan.InterestRate,
                    tenure
                );

                Console.WriteLine("\nLoan Approved");
                Console.WriteLine("Applicant Name: " + applicant.Name);
                Console.WriteLine("Monthly EMI: ₹" + emi.ToString("0.00"));
            }
            else
            {
                Console.WriteLine("\n Loan Rejected");
            }
        }
    }
}