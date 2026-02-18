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
       


        public AllocatedTicketPresentationDTO AllocatedToPresentationDTO(AllocatedTicket allocatedTicket)
        {
            return new AllocatedTicketPresentationDTO(allocatedTicket.Id, allocatedTicket.DateAllocated);
        }

        public AllocatedTicketDTO AllocatedToAllocatedDTO(AllocatedTicket allocatedTicket)
        {
            return new AllocatedTicketDTO(allocatedTicket.EmployeeId, allocatedTicket.DateAllocated, allocatedTicket.DateClosed);
        }

        public List<AllocatedTicketDTO> AllocatedToAllocatedDTO(List<AllocatedTicket> allocatedTickets)
        {
            List<AllocatedTicketDTO> tickets = new List<AllocatedTicketDTO>();
            foreach(var t in allocatedTickets)
            {
                tickets.Add(AllocatedToAllocatedDTO(t));
            }
            return tickets;
        }


    }
}
