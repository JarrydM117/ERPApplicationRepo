using ERPApplication.DomainLayer.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Organisation
{
    public class Unit :BaseEntity
    {
        public string UnitName { get; private  set; }
        public int UnitHead {  get; private set; }
        public int DepartmentId { get; private set; }
        public List<TicketSupportType> TicketSupportTypes { get;  set; }
        public Unit(int id, string unitName, int unitHead, int departmentId): base(id)
        {
            UnitName = unitName;
            UnitHead = unitHead;
            DepartmentId = departmentId;
        }
    }
}
