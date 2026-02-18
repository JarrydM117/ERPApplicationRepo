using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{
    public class EmployeeLeave :BaseEntity
    {
        public int LeaveTypeId { get;private set; }
        public int EmployeeId { get;private set; }
        public int LeaveAmmount {  get;private set; }
        public DateTime LeaveCycleStart { get;private set; }
        public int NumberOfCycles { get;private set; }
        public int LeaveCarriedOver {  get;private set; }
        public EmployeeLeave(int id, int leaveTypeId, int employeeId, int leaveAmmount, DateTime leaveCycleStart, int numberOfCycles, int leaveCarriedOver) : base(id)
        {
            LeaveTypeId = leaveTypeId;
            EmployeeId = employeeId;
            LeaveAmmount = leaveAmmount;
            LeaveCycleStart = leaveCycleStart;
            NumberOfCycles = numberOfCycles;
            LeaveCarriedOver = leaveCarriedOver;
        }
        public bool ValidateAnnualLeave(int amountTaken)
        {
            return LeaveCarriedOver + LeaveAmmount >= amountTaken;
        }

        //This will be used to Save changes.
        public void SubtractAnnualLeave(int ammountTaken)
        {
            if(LeaveCarriedOver > 0)
            {
                if(LeaveCarriedOver > ammountTaken)
                {
                    LeaveCarriedOver -= ammountTaken;
                    return;
                }
                else
                {
                    ammountTaken -= LeaveCarriedOver;
                    LeaveCarriedOver = 0;
                }
            }
            LeaveAmmount -= ammountTaken;
        }


    }
}
