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

      
        public async Task<Employee> AuthenticateEmployee(Employee employee)
        {
            var employeeCred = await _context
                                    .Set<Employee>()                          
                                    .SingleAsync(e => e.EmailAddress == employee.EmailAddress);
            return employeeCred;
        }

        public async Task<bool> RegisterEmployee(Employee employee)
        {
     
                var newEmployee = await _context
                                        .Set<Employee>()
                                        .AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;

        }

        public async Task<bool> ValidateEmailAddress(string emailAddress)
        {
            var validate = await _context.
                                    Set<Employee>()
                                    .Where(e => e.EmailAddress == emailAddress)
                                    .Select(e => e)
                                    .FirstOrDefaultAsync();
            return validate == null;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = await _context
                                        .Set<Employee>()
                                        .Include(e=> e.Roles)
                                        .SingleAsync(e=> e.Id == id);
            return employee;
        }
        public async Task<List<Employee>> GetAll()
        {
           return await _context
                            .Set<Employee>()
                            .Include(e=>e.Roles)
                            .ToListAsync();
        }

        public async Task<List<Employee>> GetAllSubordinates(int managerId)
        {
            var employees = await _context
                                        .Set<Employee>()
                                        .Where(e => e.ReportingManagerId == managerId)
                                        .ToListAsync();
            return employees;
        }

        public async Task<bool> EditRoles(Employee employee)
        {
            var employeeAddRoles = await _context
                                            .Set<Employee>()
                                            .Include(e => e.Roles)
                                            .SingleAsync(e=>e.Id == employee.Id);
            employeeAddRoles.Roles = employee.Roles;
            var validate =  await _context.SaveChangesAsync();
            return validate > 1;
        }
    }
}
