using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{
    public class LeaveStatus : Status
    {
        public LeaveStatus(int id, string name) : base(id,name)
        {
        }
    }
}
