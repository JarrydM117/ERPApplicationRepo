using ERPApplication.ApplicationLayer.DTOs.AllocatedTicket;
using ERPApplication.ApplicationLayer.DTOs.Ticket;
using ERPApplication.ApplicationLayer.Services;
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
        public async Task<ActionResult<List<TicketPresentationDTO>>> GetUnallocatedTickets([FromRoute] int statusId,[FromRoute] int unitId)
        {
            var tickets = await _ticketService.GetUnallocatedTickets(statusId, unitId);
            return Ok(tickets);
        }

        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDTO ticket)
        {
            var validation = await _ticketService.CreateTicket(ticket);
            return validation ? Created() : BadRequest();
        }

        [HttpPut("AssignTicket")]
        public async Task<IActionResult> AssignTicket(TicketAssignmentDTO ticketAssignment)
        {
            var validate = await _ticketService.AssignTicket(ticketAssignment);
            return validate ? Ok() : BadRequest();
        }

        [HttpPut("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket([FromBody] TicketUpdateDTO ticket)
        {
            return await _ticketService.UpdateTicket(ticket) ? Ok() : BadRequest();
        }

        [HttpGet("GetTicket/{id}")]
        public async Task<ActionResult<TicketDTO>> GetTicket([FromRoute] int id)
        {
            var ticket = await _ticketService.GetTicketWithId(id); 
            return ticket != null? Ok(ticket) : BadRequest();
        }

        [HttpPut("CloseTicket")]
        public async Task<IActionResult> CloseTicket([FromBody] int id)
        {
            return await _ticketService.CloseTicket(id) ? Ok() : BadRequest();
        }

        [HttpPost("TransferTicket")]
        public async Task<IActionResult> TransferTicket([FromBody] TicketAssignmentDTO ticket)
        {
            return await _ticketService.TransferTicket(ticket) ? Ok() : BadRequest();
        }

        [HttpGet("GetAllSupportAgent/{employeeId}/{isOpen}/{position}")]
        public async Task<ActionResult<List<TicketAllocatedPresentationDTO>>> GetAll([FromRoute] int employeeId, [FromRoute] bool isOpen, [FromRoute] int position)
        {
            var tickets = await _ticketService.GetAll(employeeId, isOpen, position);
            return tickets.Count() > 0 ? Ok(tickets) : NotFound();
        }

        [HttpGet("GetAllEndUser/{employeeId}/{ticketStatusId}/{position}")]
        public async Task<ActionResult<List<TicketAllocatedPresentationDTO>>> GetAll([FromRoute] int employeeId, [FromRoute] int ticketStatusId, [FromRoute] int position)
        {
            var tickets = await _ticketService.GetAll(employeeId, ticketStatusId, position);
            return tickets.Count() > 0 ? Ok(tickets) : NotFound();
        }






    }
}
