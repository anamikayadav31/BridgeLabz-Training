using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BridgeLabzTraining.oops.sceneriobased.LoanBuddy
{
    internal interface IApprovable
    {


        bool approveLoan(Applicant applicant);

        double calculateEMI(double principal, double rate, int tenure);
    }
}
