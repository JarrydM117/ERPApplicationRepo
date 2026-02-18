using ERPApplication.ApplicationLayer.DTOs.AllocatedTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.Ticket
{
    public record TicketAllocatedPresentationDTO(int Id, string Title, int TicketStatusId, DateTime DateIssued, AllocatedTicketPresentationDTO AllocatedTicketPresentation );
}
