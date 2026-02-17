using ERPApplication.ApplicationLayer.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.Employee
{
    public record EmployeeAuthenticatedDTO(int Id, string FirstName, string LastName, string JobTitle,List<RoleEmployeeDTO> roles);
}
