using ERPApplication.DomainLayer.Models.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Tickets
{
    public  class TicketSupportType: BaseEntity
    {
        public string SupportTypeName { get; private set; }
        public List<Unit> Units { get;  set; } = new List<Unit>();
        public TicketSupportType(int id, string supportTypeName) : base(id)
        {
            SupportTypeName = supportTypeName;
        }
    }
}