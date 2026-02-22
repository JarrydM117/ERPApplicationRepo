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
        public async Task<int> UpdateTicket(Ticket ticket)
        {
             _context.Set<Ticket>().Update(ticket);
             return await _context.SaveChangesAsync();
        }
        public async Task<Ticket?> Get(int id)
        {
            return await _context
                            .Set<Ticket>()
                            .Include(t => t.AllocatedTickets)
                            .SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task<bool> Create(Ticket ticket)
        {
            await _context
                        .Set<Ticket>()
                        .AddAsync(ticket);
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<List<Ticket>> GetAll(int employeeId, bool isOpen, int position)
        {
            return await _context
                                .Set<Ticket>()
                                .Include(t=>t.AllocatedTickets
                                .Where(a=>a.EmployeeId == employeeId && isOpen ? (a.DateClosed == null) : (a.DateClosed!=null))
                                .OrderBy(a=>a.DateAllocated))
                                .Skip(position)
                                .Take(10)
                                .ToListAsync();
        
        }
        public async Task<List<Ticket>> GetAll(int employeeId, int ticketStatusId, int position)
        {
            return await _context
                                .Set<Ticket>()
                                .Include(t => t.AllocatedTickets)
                                .Where(t=>t.TicketStatusId == ticketStatusId  && t.EmployeeId == employeeId)
                                .OrderBy(t => t.DateIssued)
                                .Skip(position)
                                .Take(10)
                                .ToListAsync();
            
        }
    }
}
