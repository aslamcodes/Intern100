using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBenefitsModelLibrary
{
    public interface ICompany
    {
        public string Name { get; set; }
        public double EmployeePFPercentage { get; set; }
        public double EmployerPFPercentage { get; set; }

        public string GetSalaryDetails(double salary);
    }
}
