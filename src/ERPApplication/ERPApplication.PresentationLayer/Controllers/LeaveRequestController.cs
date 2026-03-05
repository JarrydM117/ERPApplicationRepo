using ERPApplication.ApplicationLayer.DTOs.LeaveRequest;
using ERPApplication.ApplicationLayer.Services;
using ERPApplication.PresentationLayer.HelperMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPApplication.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {

        private readonly LeaveRequestService _leaveRequestService;
        public LeaveRequestController(LeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpPost("CreateLeaveRequest")]
        public async Task<IActionResult> Create([FromBody] LeaveRequestCreateDTO create) 
        => ResultMapper.ReturnResult(await _leaveRequestService.CreateLeaveRequest(create));

        [HttpPut("CancelLeaveRequest")]
        public async Task<IActionResult> CancelLeaveRequest(LeaveRequestUpdateDTO update) 
        => ResultMapper.ReturnResult(await _leaveRequestService.CancelLeaveRequest(update));

        [HttpPut("UpdateLeaveRequest")]
        public async Task<IActionResult> UpdateLeaveRequest(LeaveRequestUpdateDTO update)
        => ResultMapper.ReturnResult(await _leaveRequestService.UpdateLeaveStatus(update));

        [HttpGet("GetAllSubordinatesLeaveRequests/{employeeId}/{statusId}")]
        public async Task<IActionResult> GetAllSubordinateLeaveRequests([FromRoute]int employeeId, [FromRoute]int statusId)
        => ResultMapper.ReturnResult(await _leaveRequestService.GetAllSubordinateLeaveRequests(employeeId, statusId));

        [HttpGet("GetEmployeeLeaveRequests/{employeeId}")]
        public async Task<IActionResult> GetEmployeeLeaveRequests([FromRoute] int employeeId)
        => ResultMapper.ReturnResult(await _leaveRequestService.GetEmployeeLeaveRequests(employeeId));
    }
}
