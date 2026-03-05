using ERPApplication.DomainLayer.Models.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Factories
{
    public class LeaveFactory
    {
        public ILeave? Create(int employeeId, int leaveTypeId)
        {
            switch(leaveTypeId)
            {
                case 1:
                    return new SickLeave(employeeId);
                case 2:
                    return new AnnualLeave(employeeId);
                case 3:
                    return new FamilyResponsibilityLeave(employeeId);
                case 4:
                    return new UnpaidLeave(employeeId);
                default:
                    return null;
            }
        }
    }
}