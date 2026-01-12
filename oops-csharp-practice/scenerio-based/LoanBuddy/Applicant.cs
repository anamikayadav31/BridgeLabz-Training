using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.LoanBuddy
{
    internal class Applicant
    {


        private int creditScore;   // private for encapsulation

        public string Name { get; }
        public double Income { get; }
        public double LoanAmount { get; }

        // Constructor
        public Applicant(string name, int creditScore, double income, double loanAmount)
        {
            Name = name;
            this.creditScore = creditScore;
            Income = income;
            LoanAmount = loanAmount;
        }

        // Getter for credit score
        public int GetCreditScore()
        {
            return creditScore;
        }
    }
}