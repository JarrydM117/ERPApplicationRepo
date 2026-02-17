using ERPApplication.ApplicationLayer.DTOs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.AllocatedTicket
{
    public record AllocatedTicketPresentationDTO(int Id, DateTime DateAllocated);
}
