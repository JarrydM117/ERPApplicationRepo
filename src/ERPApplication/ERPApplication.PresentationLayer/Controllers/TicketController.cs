using ERPApplication.ApplicationLayer.Common;
using ERPApplication.ApplicationLayer.DTOs.AllocatedTicket;
using ERPApplication.ApplicationLayer.DTOs.Ticket;
using ERPApplication.ApplicationLayer.Services;
using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.DomainLayer.Models.Tickets;
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

        [HttpGet("GetUnallocatedTickets/{unitId}")]
        public async Task<IActionResult> GetUnallocatedTickets([FromRoute] int unitId)
        => ResultMapper.ReturnResult(await _ticketService.GetUnallocatedTickets(unitId));
        
        [HttpPost("CreateTicket")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreationDTO ticket)
        => ResultMapper.ReturnResult(await _ticketService.CreateTicket(ticket));
        
        [HttpPut("AssignTicket")]
        public async Task<IActionResult> AssignTicket(TicketAssignmentDTO ticketAssignment)
        => ResultMapper.ReturnResult(await _ticketService.AssignTicket(ticketAssignment));
        
        [HttpPut("UpdateTicket")]
        public async Task<IActionResult> UpdateTicket([FromBody] TicketUpdateDTO ticket)
        => ResultMapper.ReturnResult(await _ticketService.UpdateTicket(ticket));

        [HttpGet("GetTicket/{id}")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
         => ResultMapper.ReturnResult(await _ticketService.GetTicketWithId(id));
        
        [HttpPut("CloseTicket")]
        public async Task<IActionResult> CloseTicket([FromBody] int id)
        => ResultMapper.ReturnResult(await _ticketService.CloseTicket(id));

        [HttpPost("TransferTicket")]
        public async Task<IActionResult> TransferTicket([FromBody] TicketAssignmentDTO ticket)
        => ResultMapper.ReturnResult(await _ticketService.TransferTicket(ticket));

        [HttpGet("GetAllSupportAgent/{employeeId}/{isOpen}/{position}")]
        public async Task<IActionResult> GetAll([FromRoute] int employeeId, [FromRoute] bool isOpen, [FromRoute] int position)
         => ResultMapper.ReturnResult(await _ticketService.GetAll(employeeId, isOpen, position));
        
        [HttpGet("GetAllEndUser/{employeeId}/{ticketStatusId}/{position}")]
        public async Task<IActionResult> GetAll([FromRoute] int employeeId, [FromRoute] int ticketStatusId, [FromRoute] int position)
         =>  ResultMapper.ReturnResult(await _ticketService.GetAll(employeeId, ticketStatusId, position));
        
    }
}
