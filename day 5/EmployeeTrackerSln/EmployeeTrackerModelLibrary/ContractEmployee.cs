using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerModelLibrary
{
    public class ContractEmployee : Employee
    {
        public double WagesPerDay { get; set; }
        public ContractEmployee()
        {
            WagesPerDay = 0;
            Type = EmployeeType.Contract;
            Console.WriteLine("Contract employee constructor");
        }
        public ContractEmployee(int id, string name, DateTime dateOfBirth, double salary, double wagesPerDay) : base(id, name, dateOfBirth)
        {
            
            WagesPerDay = wagesPerDay;
        }


        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the Daily Wage");
            WagesPerDay = Convert.ToDouble(Console.ReadLine());
        }

        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine($"Type {Type}");
            Console.WriteLine($"Wage: {WagesPerDay}");
        }

        public override string ToString()
        {
            return base.ToString() + $"\tWage: {WagesPerDay}";
        }
    }
}
