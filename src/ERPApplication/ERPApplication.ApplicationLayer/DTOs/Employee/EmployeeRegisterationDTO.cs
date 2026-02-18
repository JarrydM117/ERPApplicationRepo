using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.Employee
{
    public record EmployeeRegisterationDTO(string FirstName, string LastName, string JobTitle, int? ReportingManagerId, int UnitId, int EmployeeStatusId);
}
