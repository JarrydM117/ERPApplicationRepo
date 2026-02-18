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
    public class TicketMapper
    {
        private readonly AllocatedTicketMapper _allocatedMapper;
        public TicketMapper(AllocatedTicketMapper allocatedMapper)
        {
            _allocatedMapper = allocatedMapper;
        }
        public List<TicketPresentationDTO> TicketToTicketPresentation(List<Ticket> tickets)
        {
            List<TicketPresentationDTO> ticketPresentations = new List<TicketPresentationDTO>();
            foreach(Ticket t in tickets)
            {
                ticketPresentations.Add(TicketToTicketPresentation(t));
            }
            return ticketPresentations;
        }

        public Ticket TicketDtoToTicket(TicketDTO ticket)
        {
            return new Ticket(0, ticket.Title, ticket.Body, DateTime.Now,0,ticket.EmployeeId,ticket.TicketSupportTypeId);
        }

        public TicketPresentationDTO TicketToTicketPresentation(Ticket ticket)
        {
            return new TicketPresentationDTO(ticket.Id, ticket.Title, ticket.Employee.FirstName, ticket.Employee.LastName, ticket.DateIssued);
        }

        public TicketAllocatedPresentationDTO TicketToAllocatedPresenation(Ticket ticket, AllocatedTicketPresentationDTO allocatedTicketPresentationDTO)
        {
            return new TicketAllocatedPresentationDTO(ticket.Id,ticket.Title, ticket.TicketStatusId,ticket.DateIssued, allocatedTicketPresentationDTO);
        }

        public List<TicketAllocatedPresentationDTO> TicketToAllocatedPresenation(List<Ticket> tickets)
        {
            List<TicketAllocatedPresentationDTO> ticketsToRet = new List<TicketAllocatedPresentationDTO>();
            foreach(var t in tickets)
            {
                ticketsToRet.Add(TicketToAllocatedPresenation(t,_allocatedMapper.AllocatedToPresentationDTO(t.GetOpenTicket())));
            }
            return ticketsToRet;
        }

        public TicketDTO TicketToTicketDTO(Ticket ticket)
        {
            return new TicketDTO(ticket.Title, ticket.Body, ticket.DateIssued, ticket.EmployeeId, ticket.SupportTypeId, _allocatedMapper.AllocatedToAllocatedDTO(ticket.AllocatedTickets));
        }

    }
}
