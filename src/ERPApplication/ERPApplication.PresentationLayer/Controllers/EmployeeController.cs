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
        private EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(EmployeeRegistrationDTO employee)
        =>  ResultMapper.ReturnResult(await _employeeService.RegisterEmployee(employee));
        

        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] EmployeeCredentialsDTO credentials) 
        => ResultMapper.ReturnResult(await _employeeService.AuthenticateEmployee(credentials));
        

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees() 
        => ResultMapper.ReturnResult(await _employeeService.GetAllEmployees());
        

        [HttpPut("UpdateEmployeeStatus")]
        public async Task<IActionResult> UpdateEmployeeStatus(EmployeeStatusDTO employeeStatus)
        => ResultMapper.ReturnResult(await _employeeService.UpdateEmployeeStatus(employeeStatus));
        

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        => ResultMapper.ReturnResult(await _employeeService.GetAllEmployees());
        

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeEditDetailsDTO employee)
        => ResultMapper.ReturnResult(await _employeeService.EditEmployee(employee));
        
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] EmployeePasswordUpdateDTO passwordUpdate)
        =>ResultMapper.ReturnResult(await _employeeService.UpdatePassword(passwordUpdate));
    }
}
