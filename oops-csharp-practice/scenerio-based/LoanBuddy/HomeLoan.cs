using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.LoanBuddy
{
    internal class HomeLoan : LoanApplication
    {


        public HomeLoan(int tenure)
            : base("Home Loan", tenure, 8.5)
        {
        }

        public override bool ApproveLoan(Applicant applicant)
        {
            return applicant.GetCreditScore() >= 700 &&
                   applicant.Income >= 50000;
        }
    }
}