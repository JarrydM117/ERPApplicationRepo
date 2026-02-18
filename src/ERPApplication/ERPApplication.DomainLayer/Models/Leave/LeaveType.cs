using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{
    public class LeaveType :BaseEntity
    {
        public string LeaveTypeName { get; private set; }

        public LeaveType(int id, string leaveTypeName) : base(id)
        {
            LeaveTypeName = leaveTypeName;
        }

    }
}
