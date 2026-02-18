using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.AllocatedTicket
{
        public record AllocatedTicketDTO(int employeeId, DateTime DateAllocated, DateTime? DateClosed); 
}
