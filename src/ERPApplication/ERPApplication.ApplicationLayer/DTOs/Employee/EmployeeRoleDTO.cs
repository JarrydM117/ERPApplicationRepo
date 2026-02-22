using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.Employee
{
    public record EmployeeRoleDTO(int Id, List<int> roleId);
}
