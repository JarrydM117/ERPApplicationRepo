using ERPApplication.DomainLayer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{
    public class LeaveStatus : Status
    {
        // 1. Pending
        // 2. Aproved
        // 3. Rejected
        // 4. Cancelled
        public LeaveStatus(int id, string name) : base(id,name)
        {
        }
    }
}
