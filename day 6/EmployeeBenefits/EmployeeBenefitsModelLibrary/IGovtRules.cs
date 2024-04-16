using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefitsModelLibrary
{
    public interface IGovtRules
    {
        public double EmployeePF(double Salary);

        public string LeaveDetails();
        
        public double GratuityAmount(double salary, float serviceCompleted);

    }
}
