using ERPApplication.ApplicationLayer.DTOs.AllocatedTicket;
using ERPApplication.DomainLayer.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.Ticket
{
    public record TicketDTO(string Title, string Body, DateTime DateIssued, int EmployeeId, int TicketSupportTypeId, List<AllocatedTicketDTO> AllocatedTickets);
}
