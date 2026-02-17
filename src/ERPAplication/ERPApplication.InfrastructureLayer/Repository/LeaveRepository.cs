using ERPApplication.DomainLayer.Models.Leave;
using ERPApplication.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Repository
{
    public  class LeaveRepository
    {
        private readonly ERPDataContext _context;
        public LeaveRepository(ERPDataContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateLeaveAmmount(int employeeId, int leaveTypeId, int leaveAmmount)
        {
            var leave = await _context.Set<EmployeeLeave>().SingleAsync(l=>l.EmployeeId==employeeId && l.LeaveTypeId == leaveTypeId);
            leave.SubtractAnnualLeave(leaveAmmount);
            var validate = await _context.SaveChangesAsync();
            return validate == 1;
        }

        //public async Task<List<EmployeeLeave>> GetLeaveForEmployee()
        //{

        //}


    }
}
