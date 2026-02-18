using ERPApplication.ApplicationLayer.DTOs.Employee;
using ERPApplication.ApplicationLayer.DTOs.Roles;
using ERPApplication.DomainLayer.Models.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Mapper
{
    public sealed class EmployeeMapper :IEntityMapper
    {
        private readonly RoleMapper _roleMapper;

        public EmployeeMapper(RoleMapper roleMapper)
        {
            _roleMapper = roleMapper;
        }

        public Employee CredentialsToEmployee(EmployeeCredentialsDTO employeeCredentials)
        {
            return new Employee(0,string.Empty, string.Empty,employeeCredentials.EmailAddress, employeeCredentials.Password,0,0, string.Empty);
        }

        public EmployeeAuthenticatedDTO EmployeeToAuthenticated(Employee employee)
        {
            return new EmployeeAuthenticatedDTO(employee.Id, employee.FirstName, employee.LastName, employee.JobTitle,_roleMapper.RolesToRoleEmployee(employee.Roles));
        }

        public Employee AuthenticatedDtoToEmployee(EmployeeAuthenticatedDTO authenticatedEmployee)
        {
            Employee employee = new Employee(authenticatedEmployee.Id, authenticatedEmployee.FirstName, authenticatedEmployee.LastName, string.Empty,string.Empty,0,0,string.Empty);
            return employee;
        }

        public Employee RegisterToEmployee(EmployeeRegisterationDTO employeeRegisteration)
        {
            return new Employee(0, employeeRegisteration.FirstName, employeeRegisteration.LastName, string.Empty, string.Empty, employeeRegisteration.UnitId, employeeRegisteration.EmployeeStatusId, employeeRegisteration.JobTitle, employeeRegisteration.ReportingManagerId);
        }

        public EmployeePresentationDTO EmployeeToPresentation(Employee employee)
        {
            return new EmployeePresentationDTO(employee.FirstName, employee.LastName, employee.EmailAddress, employee.JobTitle, employee.UnitId ?? 0, employee.EmployeeStatusId);
        }

        public List<EmployeePresentationDTO> EmployeeToPresentation(List<Employee> employees)
        {
            List<EmployeePresentationDTO> employeePresentations = new List<EmployeePresentationDTO>();
            foreach (var e in employees)
            {
                employeePresentations.Add(EmployeeToPresentation(e));
            }
            return employeePresentations;
        }

    }
}
