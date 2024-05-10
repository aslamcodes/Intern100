using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefitsModelLibrary
{
    public class Accenture : ICompanyWithGovtRules
    {
        public string Name { get; set; }
        public double EmployerPFPercentage { get; set; }

        public double EmployeePFPercentage { get; set; }


        public Accenture()
        {
            Name = "Accenture";
            EmployeePFPercentage = 0.0833;
            EmployerPFPercentage = 0.367;
        }
        
     
        public double EmployeePF(double Salary)
        {
            return EmployerPFPercentage * Salary + EmployeePFPercentage * Salary;
        } 

        public double GratuityAmount(double salary, float serviceCompleted)
        {
            return 0;
        }

        public string LeaveDetails()
        {
            return "2 day of Casual Leave per month\r\n5 days of Sick Leave per year\r\n5 days of Previlage Leave per year";
        }

        public string GetSalaryDetails(double salary)
        {
            return $"Basic Salary - {salary} - Employee PF - {EmployeePF(salary)} = {salary - EmployeePF(salary)}";
        }
    }
}
