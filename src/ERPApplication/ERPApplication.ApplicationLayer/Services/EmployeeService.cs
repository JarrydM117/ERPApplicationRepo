using ERPApplication.ApplicationLayer.Common;
using ERPApplication.ApplicationLayer.DTOs.Employee;
using ERPApplication.ApplicationLayer.Mapper;
using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.InfrastructureLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Services
{
    public class EmployeeService
    {
        private readonly EmployeeMapper _employeeMapper;
        private readonly EmployeeRepository _employeeRepository;
        private readonly RoleMapper _roleMapper;
       // private readonly RoleRepository _roleRepository;

        public EmployeeService(EmployeeMapper employeeMapper, EmployeeRepository employeeRepository, RoleMapper roleMapper)
        {
            _employeeMapper = employeeMapper;
            _employeeRepository = employeeRepository;
            _roleMapper = roleMapper;
        }

        //Authentication of employee details.
        public async Task<Result<EmployeeAuthenticatedDTO>> AuthenticateEmployee(EmployeeCredentialsDTO credentials)
        {
                Employee employee = _employeeMapper.CredentialsToEmployee(credentials);
                var employeeCred = await _employeeRepository.AuthenticateEmployee(employee);
                //I was debating on whether to isolate these two conditions, with two different response codes.
                //But due to the sensitive nature of the data, I decided not to.
                if (employeeCred == null|| !employeeCred.VerifyCredentials(credentials.Password))
                    return Result<EmployeeAuthenticatedDTO>.Unsuccessful(ErrorType.InvalidData,"Employee Authentication Details are Invalid.");
                return Result<EmployeeAuthenticatedDTO>.Success(_employeeMapper.EmployeeToAuthenticated(employee));
        }
        public async Task<Result> UpdateEmployeeStatus(EmployeeStatusDTO employeeStatus)
        {
            var employee = await GetEmployeeWithId(employeeStatus.Id);
            if(employee == null)
                return Result.Unsuccessful(ErrorType.NotFound, "Employee Not Found.");
            employee.UpdateEmployeeStatus(employeeStatus.StatusId);
            return await UpdateEmployee(employee,1) ? Result.Success(): Result.Unsuccessful(ErrorType.FailedUpdate, "Could Not Update Employee.");
        }

        public async Task<Result> RegisterEmployee(EmployeeRegistrationDTO employeeRegistration)
        {
            Employee employee = _employeeMapper.RegisterToEmployee(employeeRegistration);
            string emailAddress =await BuildEmailAddress(employee.FirstName, employee.LastName,"@enters.co.za");
            employee.RegisterNewEmployee(emailAddress);
            var emp = await _employeeRepository.RegisterEmployee(employee);
            return emp? Result.Success() : Result.Unsuccessful(ErrorType.FailedInsertion, "Could Not Insert Employee."); ;
        }
        public async Task<Result<List<EmployeePresentationDTO>>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAll();
            return employees.Count() == 0 ? Result<List<EmployeePresentationDTO>>.Success(_employeeMapper.EmployeeToPresentation(employees)): Result<List<EmployeePresentationDTO>>.Unsuccessful(ErrorType.NotFound,"Could Not Find Employees");
        }
        public async Task<Result> EditEmployee(EmployeeEditDetailsDTO details)
        {
            var employee = await GetEmployeeWithId(details.Id);
            if(employee == null)
                return Result.Unsuccessful(ErrorType.NotFound, "Employee Not Found.");
            employee.UpdateDetails(details.FirstName, details.LastName, details.JobTitle, details.UnitId, details.ReportingManagerId);
            return await UpdateEmployee(employee, 1) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate, "Could Not Update Employee") ;
        }
        #region Helper methods
        private async Task<Employee?> GetEmployeeWithId(int id)
        {
            Employee? employee = await _employeeRepository.GetEmployee(id);
            return employee;
        }
        private async Task<bool> UpdateEmployee(Employee employee, int updatesTotal)
        {
            return await _employeeRepository.UpdateEmployee(employee) == updatesTotal;
        }
        private async Task<string> BuildEmailAddress(string firstName, string lastName, string domain)
        {
            bool flag = false;
            int counter = 1;
            string emailAddress = string.Empty;
            while (!flag)
            {
                emailAddress = $"{firstName}{new string (lastName.Take(counter).ToArray())}{domain}";
                flag = await _employeeRepository.ValidateEmailAddress(emailAddress);
                counter++;
            }
            return emailAddress;
        }
        #endregion
    }
}
