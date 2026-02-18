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

        [HttpPost]
        public async Task<ActionResult<string>> Authentication(EmployeeCredentialsDTO employeeCredentials)
        {
            var token = await employeeService.AuthenticateEmployee(employeeCredentials);
            return token!=string.Empty? Ok(token) : Unauthorized();
        }

        [HttpGet("GetAuthenticatedEmployee/{id}")]
        public async Task<ActionResult<EmployeeAuthenticatedDTO>> GetAuthenticatedEmployee([FromRoute] int id)
        {
            var employee = await employeeService.GetAuthentciatedEmployee(id);

            return employee != null ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Registeration(EmployeeRegisterationDTO employee)
        {
            var validation = await employeeService.RegisterEmployee(employee);
            return validation ? Created(): BadRequest();
        }

        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] EmployeeCredentialsDTO credentials)
        {
            string token = await employeeService.AuthenticateEmployee(credentials);
            return Ok(token);
        }
    }
}
