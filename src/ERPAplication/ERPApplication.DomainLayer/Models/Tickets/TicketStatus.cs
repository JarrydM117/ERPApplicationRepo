using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Tickets
{
    public class TicketStatus : Status
    {
        //1 Unallocated
        //2 Allocated
        //3 Pending
        //4 Closed 
        public TicketStatus(int id, string name) : base(id, name)
        {
        }
    }
}
