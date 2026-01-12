using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.LoanBuddy
{
    internal class PersonalLoan : LoanApplication
    {
        public PersonalLoan(int tenure, double interestRate)
            : base("Personal Loan", tenure, interestRate)
        {
        }
    }
}