using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerModelLibrary
{
    public class PermanentEmployee: Employee
    {
        public double Salary { get; set; }

        public PermanentEmployee()
        {
            Type = EmployeeType.Permanent;
            Salary = 0;
        }

        public PermanentEmployee(int id, string name, DateTime dateOfBirth, double salary) : base(id, name, dateOfBirth)
        {
            Type = EmployeeType.Permanent;
            Salary = salary;
        }

        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the Salary");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine($"Type {Type}");
            Console.WriteLine($"Salary {Salary}");
        }

        public override string ToString()
        {
            return base.ToString() + $"Salary {Salary}";
        }

    }
}
