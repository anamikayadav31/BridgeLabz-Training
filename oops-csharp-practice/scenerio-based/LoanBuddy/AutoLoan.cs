using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.LoanBuddy
{
    internal class AutoLoan : LoanApplication
    {


        public AutoLoan(int tenure)
            : base("Auto Loan", tenure, 10.5)
        {
        }

        public override bool ApproveLoan(Applicant applicant)
        {
            return applicant.GetCreditScore() >= 680 &&
                   applicant.Income >= 40000;
        }
    }
}