using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.Employee
{
    public record EmployeePresentationDTO(string FirstName, string LastName, string EmailAddress, string JobTitle, int UnitId, int EmployeeStatusId);
}
