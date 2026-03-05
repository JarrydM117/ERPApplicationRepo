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
    public class EmployeeRepository
    {
        private readonly ERPDataContext _context;

        public EmployeeRepository(ERPDataContext context)
        {
            _context = context;
        }
        public async Task<Employee?> AuthenticateEmployee(Employee employee)
        {
                var employeeCred = await _context
                                        .Employees
                                        .Include(e=>e.Roles)
                                        .SingleOrDefaultAsync(e => e.EmailAddress == employee.EmailAddress);
                return employeeCred;
        }
        public async Task<bool> RegisterEmployee(Employee employee)
        {
                var newEmployee = await _context
                                        .Employees
                                        .AddAsync(employee);
                return await _context.SaveChangesAsync() == 1;
        }
        public async Task<bool> ValidateEmailAddress(string emailAddress)
        {
            var validate = await _context
                                    .Employees
                                    .Where(e => e.EmailAddress == emailAddress)
                                    .Select(e => e)
                                    .SingleOrDefaultAsync();

            return validate == null;
        }
        public async Task<Employee?> GetEmployee(int id)
        {
            var employee = await _context
                                        .Employees
                                        .Include(e => e.Roles)
                                        .SingleOrDefaultAsync(e => e.Id == id);
            return employee;
        }
        public async Task<List<Employee>> GetAll()
        {
                return await _context
                                 .Employees
                                 .Include(e => e.Roles)
                                 .ToListAsync();
        }
        public async Task<List<Employee>> GetAllSubordinates(int managerId)
        {
            return await _context
                            .Employees
                            .Where(e => e.ReportingManagerId == managerId)
                            .ToListAsync();
        }
        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context
                .Employees
                .Update(employee);
            return await _context.SaveChangesAsync();

        }
    }
}
