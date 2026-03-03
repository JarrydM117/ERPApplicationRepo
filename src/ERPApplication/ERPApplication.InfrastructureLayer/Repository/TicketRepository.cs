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

        public async Task<List<Ticket>> GetUnallocatedTickets(int unitId)
        {
            var tickets = await _context
                                    .Set<Ticket>()
                                    .Where(t => t.TicketStatusId == 1)
                                    .Include(e=>e.Employee)
                                    .Include(s => s.SupportType)
                                    .ThenInclude(s=>s.Units.Where(e=>e.Id == unitId))
                                    .ToListAsync();
            return tickets;
        }
        public async Task<int> UpdateTicket(Ticket ticket)
        {
             _context.Set<Ticket>().Update(ticket);
             return await _context.SaveChangesAsync();
        }
        public async Task<Ticket?> Get(int id)
        {
            return await _context
                            .Tickets
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
                                .Tickets
                                .Where(t => t.AllocatedTickets.Any(s => s.EmployeeId == employeeId && (isOpen ? s.DateClosed == null : s.DateClosed != null)))
                                .Include(t => t.AllocatedTickets.Where(e=>e.EmployeeId == employeeId))
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
