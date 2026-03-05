using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.LeaveRequest
{
    public record LeaveRequestCreateDTO(int Id, int EmployeeId, DateTime StartDate, DateTime EndDate, int LeaveTypeId);
}
