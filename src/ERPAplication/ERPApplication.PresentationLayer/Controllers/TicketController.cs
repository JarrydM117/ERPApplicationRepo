using ERPApplication.ApplicationLayer.DTOs.AllocatedTicket;
using ERPApplication.ApplicationLayer.DTOs.Ticket;
using ERPApplication.ApplicationLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDTO ticket)
        {
            var validation = await _ticketService.CreateTicket(ticket);
            return validation ? Created() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> AssignTicket(TicketAssignmentDTO ticketAssignment)
        {
            var validate = await _ticketService.AssignTicket(ticketAssignment);
            return validate ? Ok() : BadRequest();
        }




    }
}
