using ERPApplication.DomainLayer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{
    public class LeaveRequest : BaseEntity
    {

        public int EmployeeId { get; private set; }
        public LeaveStatus LeaveStatus { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int LeaveTypeId { get; private set; }
        public int LeaveStatusId { get; private set; }
        public DateTime DateApplied { get; private set; }
        public DateTime? DateProcessed { get; private set; }
        public LeaveRequest(int id, int employeeId, DateTime startDate, DateTime endDate, int leaveTypeId, DateTime dateApplied, int leaveStatusId, DateTime? dateProcessed) : base(id)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            LeaveTypeId = leaveTypeId;
            DateApplied = dateApplied;
            LeaveStatusId = leaveStatusId;
            DateProcessed = dateProcessed;
        }

        public LeaveRequest(int employeeId, DateTime startDate, DateTime endDate, int leaveTypeId):base(0)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate;
            LeaveTypeId = leaveTypeId;
        }

        public void CreateLeaveRequest()
        {
            LeaveStatusId = 1;
            DateApplied = DateTime.Now;
            DateProcessed = null;
        }

        public void EditLeaveStatus(int leaveStatusId)
        {
            LeaveStatusId = leaveStatusId;
            DateProcessed = DateTime.Now;
        }

        public int CalculateDaysTaken()
        {
            int counter = 0;
            for(DateTime i = StartDate; i < EndDate.AddDays(1); i.AddDays(1))
            {
                if (i.Date.DayOfWeek == DayOfWeek.Saturday || i.Date.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                counter++;
            }
            return counter;
        }
    }
}
 