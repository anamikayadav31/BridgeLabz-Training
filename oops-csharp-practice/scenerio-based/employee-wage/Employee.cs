using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.employeeWage
{
    internal class Employee
    {
        private int EmployeeId {  get; set; }

        private int EmployeeName { get; set; }
        private int EmployeeSalary { get; set; }

        public string ToString()
        {
            return "EmployeeId:" + EmployeeId + "Employee name" + EmployeeName + "Employee Salary" + EmployeeSalary;
        }
    }
}
