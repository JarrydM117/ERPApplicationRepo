using ERPApplication.ApplicationLayer.Common;
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
        //Used to create a ticket.
        public async Task<Result> CreateTicket(TicketDTO ticketDto)
        {
            Ticket ticket = _ticketMapper.TicketDtoToTicket(ticketDto);
            ticket.CreateNewTicket();
            return await _ticketRepository.Create(ticket) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedInsertion, "Could Not Create Ticket.") ; 
        }

        //This method is called when a ticket is first assigned, hence the ticket status is updated and a support agent entity is created.
        public async Task<Result> AssignTicket(TicketAssignmentDTO ticketAssignment)
        {
            var ticket = await GetTicket(ticketAssignment.TicketId);
            if (ticket == null)
                return NotFoundResult();
            ticket.AssignTicket(ticketAssignment.EmployeeId);
            return await UpdateTicket(ticket, 2) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate, "Could Not Assign Ticket.");  
        }

        //Double Check this one
        public async Task<Result> UpdateTicket(TicketUpdateDTO ticketUpdate)
        {
            var ticket = await GetTicket(ticketUpdate.Id);
            if (ticket == null)
                return NotFoundResult();
            ticket.UpdateTicket(ticketUpdate.TicketStatusId, ticketUpdate.SupportTypeId);
            return await UpdateTicket(ticket, 1) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate,"Could Not Update Ticket") ;
        }
        //Get Individual Ticket
        public async Task<Result<TicketDTO>> GetTicketWithId(int id)
        {
            var ticket = await GetTicket(id);
            return ticket != null ? Result<TicketDTO>.Success(_ticketMapper.TicketToTicketDTO(ticket)) : Result<TicketDTO>.Unsuccessful(ErrorType.NotFound, "Could not find ticket");
        }
        //Called when an the ticket is completed. Changes the ticket status of the main ticket and closes the ticket for the support agent.
        public async Task<Result> CloseTicket(int id)
        {
            var ticket = await GetTicket(id);
            if (ticket == null)
                return NotFoundResult();
            ticket.CloseTicket();
            return await UpdateTicket(ticket, 2) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate, "Could Not Close the Ticket.") ;
        }
        //Transfer a Ticket between support staff.
        public async Task<Result> TransferTicket(TicketAssignmentDTO ticketAssignment)
        {
            var ticket = await GetTicket(ticketAssignment.TicketId);
            if (ticket == null)
                return NotFoundResult();
            ticket.TransferTicket(ticketAssignment.EmployeeId);
            return await UpdateTicket(ticket, 3) ? Result.Success() : Result.Unsuccessful(ErrorType.FailedUpdate, "Could Not Trasfer the Ticket.");
        }

        //Gets all open tickets that are assigned to a support agent
        public async Task<Result<List<TicketAllocatedPresentationDTO>>> GetAll(int employeeId, bool isOpen, int position)
        {
            var tickets= await _ticketRepository.GetAll(employeeId, isOpen, position);
            return tickets != null ? Result<List<TicketAllocatedPresentationDTO>>.Success(_ticketMapper.TicketToAllocatedPresenation(tickets)) :  Result<List<TicketAllocatedPresentationDTO>>.Unsuccessful(ErrorType.NotFound, "Could not retrieve tickets");
        }
        //Return all tickets that have not been allocated as of yet.
        public async Task<Result<List<TicketPresentationDTO>>> GetUnallocatedTickets(int statusId, int unitId)
        {
            var tickets = await _ticketRepository.GetUnallocatedTickets(statusId, unitId);
            return tickets != null ? Result<List<TicketPresentationDTO>>.Success(_ticketMapper.TicketToTicketPresentation(tickets)) : Result<List<TicketPresentationDTO>>.Unsuccessful(ErrorType.InvalidOperation, "Could not retrieve tickets");
        }

        //Get all tickets that have been logged by end-user
        public async Task<Result<List<TicketAllocatedPresentationDTO>>> GetAll(int employeeId, int ticketStatusId, int position)
        {
            var tickets = await _ticketRepository.GetAll(employeeId, ticketStatusId, position);
            return tickets != null? Result<List<TicketAllocatedPresentationDTO>>.Success(_ticketMapper.TicketToAllocatedPresenation(tickets)) : Result<List<TicketAllocatedPresentationDTO>>.Unsuccessful(ErrorType.InvalidOperation, "Could not retrieve tickets");
        }

        #region Helper methods created to prevent redundancy
        private async Task<bool> UpdateTicket(Ticket ticket, int expectedUpdates)
        {
            return await _ticketRepository.UpdateTicket(ticket) == expectedUpdates;
        }

        private async Task<Ticket> GetTicket(int id)
        {
            var ticket = await _ticketRepository.Get(id);
            return ticket;
        }
      
        private Result NotFoundResult()
        {
            return Result.Unsuccessful(ErrorType.NotFound, "Could not find ticket");
        }
        #endregion
    }
}
