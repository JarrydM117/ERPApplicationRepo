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
            return await _ticketRepository.Create(ticket);
        }

        public async Task<bool> AssignTicket(TicketAssignmentDTO ticketAssignment)
        {
            var ticket = await GetTicket(ticketAssignment.TicketId);
            ticket.AssignTicket(ticketAssignment.EmployeeId);
            return await UpdateTicket(ticket,2);
           
        }

        //Double Check this one
        public async Task<bool> UpdateTicket(TicketUpdateDTO ticketUpdate)
        {
            var ticket = await GetTicket(ticketUpdate.Id);
            ticket.UpdateTicket(ticketUpdate.TicketStatusId, ticketUpdate.SupportTypeId);
            return await UpdateTicket(ticket,1);   
        }
        //Get Individual Ticket
        public async Task<TicketDTO> GetTicketWithId(int id)
        {
            return _ticketMapper.TicketToTicketDTO(await GetTicket(id));
        }

        public async Task<bool> CloseTicket(int id)
        {
            var ticket = await GetTicket(id);
            ticket.CloseTicket();
            return await UpdateTicket(ticket,2);
        }

        public async Task<bool> TransferTicket(TicketAssignmentDTO ticketAssignment)
        {
            var ticket = await GetTicket(ticketAssignment.TicketId);
            ticket.TransferTicket(ticketAssignment.EmployeeId);
            return await UpdateTicket(ticket,3);
        }

        //Gets all open tickets that are assigned to a support agent
        public async Task<List<TicketAllocatedPresentationDTO>> GetAll(int employeeId, bool isOpen, int position)
        {
            var tickets= await _ticketRepository.GetAll(employeeId, isOpen, position);
            return _ticketMapper.TicketToAllocatedPresenation(tickets);
        }
        //Return all tickets that have not been allocated as of yet.
        public async Task<List<TicketPresentationDTO>> GetUnallocatedTickets(int statusId, int unitId)
        {
            var tickets = await _ticketRepository.GetUnallocatedTickets(statusId, unitId);
            return _ticketMapper.TicketToTicketPresentation(tickets);
        }

        //Get all tickets that have been logged by end-user
        public async Task<List<TicketAllocatedPresentationDTO>> GetAll(int employeeId, int ticketStatusId, int position)
        {
            var tickets = await _ticketRepository.GetAll(employeeId, ticketStatusId, position);
            return _ticketMapper.TicketToAllocatedPresenation(tickets);
        }

        private async Task<bool> UpdateTicket(Ticket ticket, int expectedUpdates)
        {
            return await _ticketRepository.UpdateTicket(ticket) == expectedUpdates;
        }

        private async Task<Ticket> GetTicket(int id)
        {
            return await _ticketRepository.Get(id);
        }

     
    }
}
