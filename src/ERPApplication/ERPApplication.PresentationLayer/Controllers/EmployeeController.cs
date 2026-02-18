using ERPApplication.ApplicationLayer.DTOs.Employee;
using ERPApplication.ApplicationLayer.Services;
using ERPApplication.InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ERPApplication.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(EmployeeRegisterationDTO employee)
        {
            var validation = await employeeService.RegisterEmployee(employee);
            return validation ? Created(): BadRequest();
        }

        [HttpPut("Login")]
        public async Task<ActionResult<EmployeeAuthenticatedDTO>> Login([FromBody] EmployeeCredentialsDTO credentials)
        {
            var employee = await employeeService.AuthenticateEmployee(credentials);
            return employee != null? Ok(employee) : BadRequest();
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<List<EmployeePresentationDTO>>> GetAllEmployees()
        {
            var employees = await employeeService.GetAllEmployees();
            return employees.Count() > 0 ? Ok(employees) : BadRequest();
        }
    }
}
