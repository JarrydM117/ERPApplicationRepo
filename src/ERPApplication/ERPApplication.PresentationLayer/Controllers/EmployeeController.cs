using ERPApplication.ApplicationLayer.DTOs.Employee;
using ERPApplication.ApplicationLayer.Services;
using ERPApplication.InfrastructureLayer.Repository;
using ERPApplication.PresentationLayer.HelperMethods;
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
        public async Task<IActionResult> Registration(EmployeeRegistrationDTO employee)
        {
            var result = await employeeService.RegisterEmployee(employee);
            return ResultMapper.ReturnResult(result);
        }

        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] EmployeeCredentialsDTO credentials)
        {
            var result = await employeeService.AuthenticateEmployee(credentials);
            return ResultMapper.ReturnResult(result);
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await employeeService.GetAllEmployees();
            return ResultMapper.ReturnResult(result);
        }

        [HttpPut("UpdateEmployeeStatus")]
        public async Task<IActionResult> UpdateEmployeeStatus(EmployeeStatusDTO employeeStatus)
        {
            var result = await employeeService.UpdateEmployeeStatus(employeeStatus);
            return ResultMapper.ReturnResult(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await employeeService.GetAllEmployees();
            return ResultMapper.ReturnResult(result);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeEditDetailsDTO employee)
        {
            var result = await employeeService.EditEmployee(employee);
            return ResultMapper.ReturnResult(result);
        }

    }
}
