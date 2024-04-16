using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefitsModelLibrary
{
   public class CTS : ICompanyWithGovtRules
    {
        public  string Name { get; set; }
        public double EmployeePFPercentage { get; set; }
        public double EmployerPFPercentage { get; set; }


        public CTS() {
            Name = "CTS";
            EmployeePFPercentage = 0.12;
            EmployerPFPercentage = 0.12;
        }   

        public double EmployeePF(double Salary)
        {
            return Salary * EmployerPFPercentage + Salary * EmployeePFPercentage;
        }

        public double GratuityAmount(double salary, float serviceCompleted)
        {
            if (serviceCompleted >= 5)
            {
                return salary;
            }
            else if (serviceCompleted >= 10)
            {
                return salary * 2;
            }
            else if (serviceCompleted >= 20)
            {
                return salary * 3;
            }

            return 0;
        }

        public string LeaveDetails()
        {
            return "1 day of Casual Leave per month\r\n12 days of Sick Leave per year\r\n10 days of Privilege Leave per year";
        }

        public string GetSalaryDetails(double salary)
        {
            return $"Basic Salary - {salary} - Employee PF - {EmployeePF(salary)} = {salary - EmployeePF(salary)}";
        }
    }
}
