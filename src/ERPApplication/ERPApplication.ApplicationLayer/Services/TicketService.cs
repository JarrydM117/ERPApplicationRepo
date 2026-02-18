using ERPApplication.ApplicationLayer.DTOs.Ticket;
using ERPApplication.ApplicationLayer.Mapper;
using ERPApplication.DomainLayer.Models.Tickets;
using ERPApplication.InfrastructureLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Services
{
    public class TicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly TicketMapper _ticketMapper;

        public TicketService(TicketRepository ticketRepository, TicketMapper ticketMapper)
        {
            _ticketRepository = ticketRepository;
            _ticketMapper = ticketMapper;
        }

        public async Task<bool> CreateTicket(TicketDTO ticketDto)
        {
            Ticket ticket = _ticketMapper.TicketDtoToTicket(ticketDto);
            ticket.CreateNewTicket();
            var validation = await _ticketRepository.Create(ticket);
            return validation;
        }

        public async Task<bool> AssignTicket(TicketAssignmentDTO ticketAssignment)
        {
            var ticket = await GetTicket(ticketAssignment.TicketId);
            ticket.AssignTicket(ticketAssignment.EmployeeId);
            await UpdateTicket(ticket);
            return true;
        }
        public async Task<bool> CloseTicket(int id)
        {
            var ticket = await GetTicket(id);
            ticket.CloseTicket();
            await UpdateTicket(ticket);
            return true;
        }
        public async Task<bool> TransferTicket(TicketAssignmentDTO ticketAssignment)
        {
            var ticket = await GetTicket(ticketAssignment.TicketId);
            ticket.TransferTicket(ticketAssignment.EmployeeId);
            await UpdateTicket(ticket);
            return true;   
        }

        //Gets all open tickets that are assigned to a support agent
        public async Task<List<TicketAllocatedPresentationDTO>> GetAllOpenAllocatedTickets(int employeeId)
        {
            var tickets= await _ticketRepository.GetAllAllocatedTickets(employeeId);
            var ticketsToRet = _ticketMapper.TicketToAllocatedPresenation(tickets);
            return ticketsToRet;
        }
        private async Task<bool> UpdateTicket(Ticket ticket)
        {
            await _ticketRepository.UpdateTicket(ticket);
            return true;
        }

        private  async Task<Ticket> GetTicket(int id)
        {
            return await _ticketRepository.Get(id);
        }

        public async Task<List<TicketPresentationDTO>> GetUnallocatedTickets(int statusId, int unitId)
        {
            var tickets = await _ticketRepository.GetUnallocatedTickets(statusId,unitId);
            var ticketsToRet = _ticketMapper.TicketToTicketPresentation(tickets);
            return ticketsToRet;
        }
    }
}
