using ERPApplication.DomainLayer.Models.Leave;
using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Repository
{
    public class LeaveRequestRepository
    {
        private readonly ERPDataContext _context;
        public LeaveRequestRepository(ERPDataContext context)
        {
            _context = context;   
        }



        public async Task<List<LeaveRequest>> GetSubordinatesAllLeaveRequests(int employeeId, int statusId)
        {
           return await _context
                            .LeaveRequests
                            .Join(_context.Employees, l => l.EmployeeId, e => e.Id,
                            (leave,e)=>new  
                                        { 
                                            leave,
                                            e.ReportingManagerId 
                                        })
                            .Where(e => e.ReportingManagerId == employeeId && e.leave.LeaveStatusId == statusId)
                            .Select(s=>s.leave)
                            .ToListAsync();
        }


        public async Task<List<LeaveRequest>> GetEmployeeLeaveRequests(int employeeId)
        {
            return await _context
                                .LeaveRequests
                                .Where(s=>s.EmployeeId== employeeId)
                                .ToListAsync();
        }

        public async Task<int> Create(LeaveRequest leave)
        {
            await _context
                    .LeaveRequests
                    .AddAsync(leave);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(LeaveRequest leave)
        {
            _context
                .LeaveRequests
                .Update(leave); 
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> LeaveTransaction(LeaveRequest leaveRequest, Leave leave)
        {
            await using(var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.LeaveRequests.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                    _context.Leave.Update(leave);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<LeaveRequest?> Get(int leaveRequestId)
        {
            return await _context.LeaveRequests.SingleOrDefaultAsync(l=>l.Id==leaveRequestId);
        }

        //Checks if user has taken double leave for the same requested time period
        public async Task<bool> ValidateOverlap(LeaveRequest leaveRequest)
        {
            return await _context.LeaveRequests.Where(l=> l.EmployeeId == leaveRequest.EmployeeId &&
                                                     (l.StartDate <= leaveRequest.StartDate && l.EndDate >=leaveRequest.StartDate) &&
                                                     (l.StartDate <= leaveRequest.EndDate && l.EndDate >= leaveRequest.EndDate) &&
                                                     (l.LeaveStatusId == 1 || l.LeaveStatusId == 2))
                                                     .FirstOrDefaultAsync() == null;
        }

    }
}
