using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BridgeLabzTraining.oops.sceneriobased.LoanBuddy
{
    internal class LoanApplication : IApprovable
    {


        protected string LoanType;
        protected int Tenure;          // in months
        protected double InterestRate; // annual %

        // Constructor
        public LoanApplication(string loanType, int tenure, double interestRate)
        {
            LoanType = loanType;
            Tenure = tenure;
            InterestRate = interestRate;
        }

        // Default approval logic
        public virtual bool ApproveLoan(Applicant applicant)
        {
            return applicant.GetCreditScore() >= 650 &&
                   applicant.Income >= 30000;
        }

        // EMI calculation
        public double CalculateEMI(double principal, double rate, int tenure)
        {
            double monthlyRate = rate / (12 * 100);

            return (principal * monthlyRate * Math.Pow(1 + monthlyRate, tenure)) /
                   (Math.Pow(1 + monthlyRate, tenure) - 1);
        }
    }
}