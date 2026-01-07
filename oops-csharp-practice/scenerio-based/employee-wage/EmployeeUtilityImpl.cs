using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.employeeWage
{



    internal class EmployeeUtilityImpl : IEmployee
    {
        // Constants
        const int IS_FULL_TIME = 1;
        const int IS_PART_TIME = 2;
        const int WAGE_PER_HOUR = 20;
        const int FULL_DAY_HOUR = 8;
        const int PART_TIME_HOUR = 4;
        const int MAX_WORKING_DAYS = 20;
        const int MAX_WORKING_HOURS = 100;

        public void AddEmployee()
        {
            int totalWorkingDays = 0;
            int totalWorkingHours = 0;
            int totalWage = 0;

            Random random = new Random();

            // UC6: Calculate wages till max 100 hours OR 20 working days
            while (totalWorkingDays < MAX_WORKING_DAYS &&
                   totalWorkingHours < MAX_WORKING_HOURS)
            {
                totalWorkingDays++;

                // UC1: Employee attendance using Random
                int empCheck = random.Next(0, 3);
                int empHours = 0;

                // UC4: Switch case usage
                switch (empCheck)
                {
                    case IS_FULL_TIME:
                        // UC2: Daily wage calculation (Full-time)
                        empHours = FULL_DAY_HOUR;
                        break;

                    case IS_PART_TIME:
                        // UC3: Part-time employee wage
                        empHours = PART_TIME_HOUR;
                        break;

                    default:
                        empHours = 0; // Absent
                        break;
                }

                totalWorkingHours += empHours;

                // UC2: Daily wage calculation
                int dailyWage = empHours * WAGE_PER_HOUR;
                totalWage += dailyWage;

                Console.WriteLine(
                    $"Day {totalWorkingDays} | Hours Worked: {empHours} | Daily Wage: {dailyWage}");
            }

            // UC5: Monthly wage for 20 working days
            Console.WriteLine("\n------------------------------");
            Console.WriteLine($"Total Working Days  : {totalWorkingDays}");
            Console.WriteLine($"Total Working Hours : {totalWorkingHours}");
            Console.WriteLine($"Total Monthly Wage : {totalWage}");
        }
    }
}
