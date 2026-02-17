using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Organisation
{
    public class EmployeeStatus : Status
    {
        public EmployeeStatus(int id, string name) : base(id, name)
        {
        }
    }
}
