using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.DomainLayer.Models.Tickets;
using ERPApplication.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Repository
{
    public class TicketRepository
    {
        private readonly ERPDataContext _context;
        public TicketRepository(ERPDataContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetUnallocatedTickets(int ticketStatusId, int unitId)
        {
            var tickets = await _context
                                .Set<Ticket>()
                                .Where(t => t.TicketStatusId == ticketStatusId)
                                .Include(s => s.SupportType)
                                .ToListAsync();
            List<Ticket> ticketToRet = tickets.Where(s=> s.SupportType.Units.Where(p=>p.Id==unitId).Any()).ToList();
            return ticketToRet;
        }
        public async Task UpdateTicket(Ticket ticket)
        {
             await _context.SaveChangesAsync();

        }
        public async Task<Ticket> Get(int id)
        {
            return await _context
                            .Set<Ticket>()
                            .Include(t => t.AllocatedTickets)
                            .SingleAsync(t => t.Id == id);
        }

        public async Task<bool> Create(Ticket ticket)
        {
            await _context.Set<Ticket>().AddAsync(ticket);
            var validate = await _context.SaveChangesAsync();
            return validate == 1;
        }

        public async Task<List<Ticket>> GetAllAllocatedTickets(int employeeId)
        {
            var tickets = await _context.Set<Ticket>().Include(t=>t.AllocatedTickets.Where(a=>a.EmployeeId == employeeId && a.DateClosed ==null)).ToListAsync();
            return tickets;
        }

    }
}
