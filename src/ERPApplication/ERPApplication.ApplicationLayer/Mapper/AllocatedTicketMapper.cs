using ERPApplication.ApplicationLayer.DTOs.AllocatedTicket;
using ERPApplication.ApplicationLayer.DTOs.Ticket;
using ERPApplication.DomainLayer.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Mapper
{
    public class AllocatedTicketMapper
    {
       
        public AllocatedTicket AssignmentToAllocatedTicket(AllocatedTicketAssignmentDTO ticket)
        {
            return new AllocatedTicket(0,ticket.EmployeeId, DateTime.Now);
        }

        public AllocatedTicketPresentationDTO AllocatedToPresentationDTO(AllocatedTicket allocatedTicket)
        {
            return new AllocatedTicketPresentationDTO(allocatedTicket.Id, allocatedTicket.DateAllocated);
        }




    }
}
