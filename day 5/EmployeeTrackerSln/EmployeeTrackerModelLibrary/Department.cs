using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerModelLibrary
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Department_Head { get; set; }
    }
}
