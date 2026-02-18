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

        public EmployeeService(EmployeeMapper employeeMapper, EmployeeRepository employeeRepository, RoleMapper roleMapper)
        {
            _employeeMapper = employeeMapper;
            _employeeRepository = employeeRepository;
            _roleMapper = roleMapper;
        }

        public async Task<EmployeeAuthenticatedDTO?> AuthenticateEmployee(EmployeeCredentialsDTO credentials)
        {
            Employee employee = _employeeMapper.CredentialsToEmployee(credentials);
            var employeeCred = await _employeeRepository.AuthenticateEmployee(employee);
            if(employeeCred.VerifyCredentials(credentials.Password))
            {
                return _employeeMapper.EmployeeToAuthenticated(employee);
            }
            return null;
        }


        public async Task<bool> RegisterEmployee(EmployeeRegisterationDTO employeeRegisteration)
        {
            Employee employee = _employeeMapper.RegisterToEmployee(employeeRegisteration);
            string emailAddress =await BuildEmailAddress(employee.FirstName, employee.LastName,"@enters.co.za");
            employee.RegisterNewEmployee(emailAddress);
            var validation = await _employeeRepository.RegisterEmployee(employee);
            return validation;
        }

        public async Task<List<EmployeePresentationDTO>> GetAllEmployees()
        {
            return _employeeMapper.EmployeeToPresentation(await _employeeRepository.GetAll());
        }
        

        private async Task<Employee> GetEmployeeWithId(int id)
        {
            Employee? employee = await _employeeRepository.GetEmployee(id);
            return employee;
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
    }
}
