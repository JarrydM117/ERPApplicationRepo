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

        public async Task<int> Update(Leave leave)
        {
            _context.Leave.Update(leave);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Leave>> GetLeave(int employeeId)
        {
            return await _context
                                .Leave
                                .Where(l => l.EmployeeId == employeeId)
                                .ToListAsync();
        }

        public async Task<Leave?> Get(int employeeId, int leaveTypeId)
        {
            return await _context
                                    .Leave
                                    .SingleOrDefaultAsync(l=>l.EmployeeId == employeeId && l.LeaveTypeId ==leaveTypeId);
        }

        public async Task<int> Create(List<Leave> leave)
        {
            await _context.AddRangeAsync(leave);
            return await _context.SaveChangesAsync();
        }


        public async Task<int> UpdateAll(List<Leave> leave)
        {
            _context.Leave.UpdateRange(leave);
            return await _context.SaveChangesAsync();
        }


    }
}
