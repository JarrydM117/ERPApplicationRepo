using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{
    public class EmployeeLeaveRequest : BaseEntity
    {

        public int EmployeeId { get; private set; }
        public LeaveStatus LeaveStatus { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int LeaveTypeId { get; private set; }
        public int LeaveStatusId { get; private set; }
        public DateTime DateApplied { get; private set; }
        public DateTime? DateProcessed { get; private set; }
        public EmployeeLeaveRequest(int id, int employeeId, DateTime startDate, DateTime endDate, int leaveTypeId, DateTime dateApplied, int leaveStatusId, DateTime? dateProcessed) : base(id)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            LeaveTypeId = leaveTypeId;
            DateApplied = dateApplied;
            LeaveStatusId = leaveStatusId;
            DateProcessed = dateProcessed;
        }
    }
}
 