using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.Ticket
{
    public record TicketPresentationDTO(int Id, string Title, string EmployeeFirstName, string EmployeeLastName, DateTime DateIssued);
}
