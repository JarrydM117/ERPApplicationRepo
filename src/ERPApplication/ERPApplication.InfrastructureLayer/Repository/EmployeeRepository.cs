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
        private readonly ERPDataContext context;

        public EmployeeRepository(ERPDataContext context)
        {
            this.context = context;
        }

      
        public async Task<int> AuthenticateEmployee(Employee employee)
        {
            var employeeId = await context
                                    .Set<Employee>()
                                    .Where(e => e.EmailAddress == employee.EmailAddress && e.Password == employee.Password)
                                    .Select(e=>e.Id)
                                    .FirstOrDefaultAsync();
            return employeeId;
        }

        public async Task<bool> RegisterEmployee(Employee employee)
        {
            try
            {
                var newEmployee = await context
                                        .Set<Employee>()
                                        .AddAsync(employee);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ValidateEmailAddress(string emailAddress)
        {
            var validate = await context.
                                    Set<Employee>()
                                    .Where(e => e.EmailAddress == emailAddress)
                                    .Select(e => e)
                                    .FirstOrDefaultAsync();
            return validate == null;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = await context
                                        .Set<Employee>()
                                        .Include(e=> e.Roles)
                                        .SingleAsync(e=> e.Id == id);
            return employee;
        }

        public async Task<List<Employee>> GetAllSubordinates(int managerId)
        {
            var employees = await context
                                        .Set<Employee>()
                                        .Where(e => e.ReportingManagerId == managerId)
                                        .ToListAsync();
            return employees;
        }

        public async Task<bool> EditRoles(Employee employee)
        {
            var employeeAddRoles = await context
                                            .Set<Employee>()
                                            .Include(e => e.Roles)
                                            .SingleAsync(e=>e.Id == employee.Id);
            employeeAddRoles.Roles = employee.Roles;
            var validate =  await context.SaveChangesAsync();
            return validate == 1;
        }
    }
}
