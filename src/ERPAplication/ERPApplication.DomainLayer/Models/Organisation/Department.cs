using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Organisation
{
    public class Department :BaseEntity
    {
        public string DepartmentName { get; private set; }
        public int DepartmentHead { get; private set; }
        public Employee Employee { get;  set; }
        public Department(int id, string departmentName, int departmentHead) : base(id)
        {
            DepartmentName = departmentName;
            DepartmentHead = departmentHead;
        }
    }
}
