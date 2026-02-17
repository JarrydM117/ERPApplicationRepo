using ERPApplication.DomainLayer.Models.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Tickets
{
    public class AllocatedTicket :BaseEntity
    {
        public int EmployeeId { get; private set; }
        public int TicketId { get;  set; }
        public DateTime DateAllocated { get; private set; }
        public DateTime? DateClosed { get; private set; }
        public Ticket Ticket { get;  set; }
        public Employee Employee { get; set; }
        public AllocatedTicket(int id, int employeeId, DateTime dateAllocated) : base(id) 
        {
            EmployeeId = employeeId;
            DateAllocated = dateAllocated;
            DateClosed = null;
        }

        public void CloseTicket()
        {
            DateClosed = DateTime.Now;
        }
     

       

    }
}
