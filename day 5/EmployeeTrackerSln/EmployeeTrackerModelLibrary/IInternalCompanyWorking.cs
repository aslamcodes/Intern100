using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerModelLibrary
{
    internal interface IInternalCompanyWorking
    {
        void RaiseRequest();
        void CloseRequest();
    }
}
