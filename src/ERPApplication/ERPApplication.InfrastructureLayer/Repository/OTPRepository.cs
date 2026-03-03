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
    public class OTPRepository
    {
        private readonly ERPDataContext _context;
        public OTPRepository(ERPDataContext context)
        {
            _context = context;
        }


        public async Task<EmployeeOTP> Get(int employeeId)
        {
            var otp = await _context
                                    .OTP
                                    .Include(e=>e.Employee)
                                    .SingleAsync(e=>e.EmployeeId == employeeId);
            return otp;
        }
        public async Task<bool> Exists(int employeeId)
        {
            return await _context
                                .OTP
                                .Where(x=>x.EmployeeId == employeeId)
                                .AnyAsync();
        }

        public async Task<int> Create(EmployeeOTP otp)
        {
            await _context
                            .OTP
                            .AddAsync(otp);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(EmployeeOTP otp)
        {
            _context.OTP.Update(otp);
            return await _context.SaveChangesAsync();
        }

    }
}
