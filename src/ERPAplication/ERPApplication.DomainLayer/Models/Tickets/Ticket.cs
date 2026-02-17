using ERPApplication.DomainLayer.Models.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Tickets
{
    public class Ticket :BaseEntity
    {
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime DateIssued { get; private set; }
        public TicketStatus TicketStatus { get; private set; }
        public int SupportTypeId { get;  set; }
        public int EmployeeId { get;  private set; }
        public int TicketStatusId { get; private set; }
        //Newly Added
        public Employee Employee { get; set; }
        public TicketSupportType SupportType { get; set; }
        public List<AllocatedTicket> AllocatedTickets { get; set; }

    
        public Ticket(int id, string title, string body, DateTime  dateIssued,int ticketStatusId, int employeeId, int supportTypeId) : base(id)
        {
            Title=  title;
            Body= body;
            DateIssued = dateIssued;
            TicketStatusId = ticketStatusId;
            EmployeeId = employeeId;
            SupportTypeId = supportTypeId;
        }

        public void CreateNewTicket()
        {
            DateIssued = DateTime.Now;
            TicketStatusId = 1;
        }

        public void AssignTicket(int employeeId)
        {
            AllocatedTickets.Add(new AllocatedTicket(0,employeeId,DateTime.Now));
            if(AllocatedTickets.Count()==1)
            {
                TicketStatusId = 2;
            }
        }

       
        public AllocatedTicket GetOpenTicket()
        {
            if(TicketStatusId == 1 && TicketStatusId == 4)
            {
                throw new Exception("Ticket cannot be allocated with current ticket status.");
            }
            return AllocatedTickets.Where(t => t.DateClosed == null).First();

        }


        public bool ValidateClosedTickets()
        {
            if (AllocatedTickets.Count() == 0)
                throw new InvalidOperationException("Cannot close a ticket that was never allocated.");
            return AllocatedTickets.Any(d => d.DateClosed == null);
        }

        public void CloseTicket()
        {
            CloseAssignment();
            if (!ValidateClosedTickets())
                throw new InvalidOperationException("All allocated tickets must be closed.");
            TicketStatusId = 4;
        }

        public void TransferTicket(int employeeId)
        {
            CloseAssignment();
            AssignTicket(employeeId);
        }
        
        private  void CloseAssignment()
        {
            AllocatedTickets.Where(t => t.DateClosed == null).Select(t => t).First().CloseTicket();
        }
        public bool ValidateAllocatedTicketRules()
        {
            if (AllocatedTickets.Where(x => x.DateClosed == null).Count() <= 1)
                throw new InvalidOperationException("Tickets Should Only Be Allocated To One Support Agent At A Time.");
            return true;
        }



    }
}
