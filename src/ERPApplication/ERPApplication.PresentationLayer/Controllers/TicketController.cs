using ERPApplication.ApplicationLayer.Common;
using ERPApplication.ApplicationLayer.DTOs.AllocatedTicket;
using ERPApplication.ApplicationLayer.DTOs.Ticket;
using ERPApplication.ApplicationLayer.Services;
using ERPApplication.PresentationLayer.HelperMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ERPApplication.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("GetUnallocatedTickets/{statusId}/{unitId}")]
        public async Task<IActionResult> GetUnallocatedTickets([FromRoute] int statusId,[FromRoute] int unitId)
        {
            var result = await _ticketService.GetUnallocatedTickets(statusId, unitId);
            return ResultMapper.ReturnResult(result);
        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDTO ticket)
        {
            var result = await _ticketService.CreateTicket(ticket);
            return ResultMapper.ReturnResult(result);
        }

        [HttpPut("AssignTicket")]
        public async Task<IActionResult> AssignTicket(TicketAssignmentDTO ticketAssignment)
        {
            var result = await _ticketService.AssignTicket(ticketAssignment);
            return ResultMapper.ReturnResult(result);
        }

        [HttpPut("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket([FromBody] TicketUpdateDTO ticket)
        {
            var result = await _ticketService.UpdateTicket(ticket);
            return ResultMapper.ReturnResult(result);
        }

        [HttpGet("GetTicket/{id}")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
        {
            var result = await _ticketService.GetTicketWithId(id);
            return ResultMapper.ReturnResult(result);

        }

        [HttpPut("CloseTicket")]
        public async Task<IActionResult> CloseTicket([FromBody] int id)
        {
            var result = await _ticketService.CloseTicket(id);
            return ResultMapper.ReturnResult(result);
        }

        [HttpPost("TransferTicket")]
        public async Task<IActionResult> TransferTicket([FromBody] TicketAssignmentDTO ticket)
        {
            var result = await _ticketService.TransferTicket(ticket);
            return ResultMapper.ReturnResult(result);
        }

        [HttpGet("GetAllSupportAgent/{employeeId}/{isOpen}/{position}")]
        public async Task<IActionResult> GetAll([FromRoute] int employeeId, [FromRoute] bool isOpen, [FromRoute] int position)
        {
            var result = await _ticketService.GetAll(employeeId, isOpen, position);
            return ResultMapper.ReturnResult(result);
        }

        [HttpGet("GetAllEndUser/{employeeId}/{ticketStatusId}/{position}")]
        public async Task<IActionResult> GetAll([FromRoute] int employeeId, [FromRoute] int ticketStatusId, [FromRoute] int position)
        {
            var result = await _ticketService.GetAll(employeeId, ticketStatusId, position);
            return ResultMapper.ReturnResult(result);
        }

       
    }
}
