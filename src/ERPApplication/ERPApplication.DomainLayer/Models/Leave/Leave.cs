using ERPApplication.DomainLayer.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{

    //Decided to change it to an inherritance based structure.
    //Due to the different behaviour  and attributes of the different leave types.
    public abstract class Leave :BaseEntity, ILeave
    {
        public int LeaveTypeId { get; protected set; }
        public int TotalAmountOfLeavePerCycle { get; protected set; }
        public int EmployeeId { get; protected set; }
        public double LeaveAmmount {  get;protected set; }
        public DateTime LeaveCycleStart { get; protected set; }
        public int Cycle { get; protected set; }
        public LeaveType LeaveType { get;  set; }
        public Leave(int id,  int employeeId, double leaveAmmount, DateTime leaveCycleStart, int cycle, int totalAmountOfLeavePerCycle, int leaveTypeId) : base(id)
        {
            EmployeeId = employeeId;
            LeaveAmmount = leaveAmmount;
            LeaveCycleStart = leaveCycleStart;
            Cycle = cycle;
            TotalAmountOfLeavePerCycle = totalAmountOfLeavePerCycle;
            LeaveTypeId = leaveTypeId;
        }
     
        public virtual void SubtractLeave(double amountTaken)
        {
            LeaveAmmount -= amountTaken;
        }

        public virtual bool ValidateLeave(double amountTaken)
        {
            return LeaveAmmount >= amountTaken;
        }

        public void AddMonthlyLeave()
        {
            LeaveAmmount += TotalAmountOfLeavePerCycle / Cycle;
        }

        public virtual bool StartNewCycle(bool authorisedOverride, int? totalAmountPerCycle)
        {
            if (LeaveCycleStart.AddMonths(Cycle) >= DateTime.Now || !authorisedOverride)
                return false;
            LeaveCycleStart =  DateTime.Now.Date;
            TotalAmountOfLeavePerCycle = totalAmountPerCycle ?? TotalAmountOfLeavePerCycle;
            return true;
        }

    }


    public class AnnualLeave : Leave
    {
        public double LeaveCarriedOver { get; private set; }

        public AnnualLeave(int id,  int employeeId, double leaveAmmount, DateTime leaveCycleStart, int cycle, int totalAmountOfLeavePerCycle, int leaveTypeId, double leaveCarriedOver) : base(id,  employeeId, leaveAmmount, leaveCycleStart, cycle, totalAmountOfLeavePerCycle, leaveTypeId)
        {
            LeaveCarriedOver = leaveCarriedOver;
        }

        public override void SubtractLeave(double amountTaken)
        {
            if (LeaveCarriedOver > 0)
            {
                if (LeaveCarriedOver > amountTaken)
                {
                    LeaveCarriedOver -= amountTaken;
                    return;
                }
                else
                {
                    amountTaken -= LeaveCarriedOver;
                    LeaveCarriedOver = 0;
                }
            }
            LeaveAmmount -= amountTaken;
        }
        public override bool ValidateLeave(double amountTaken)
        {
            return LeaveCarriedOver + LeaveAmmount >= amountTaken;
        }
        public override bool StartNewCycle(bool authorisedOverride, int? totalAmountPerCycle)
        {

            if (LeaveCycleStart.AddMonths(Cycle) >= DateTime.Now || !authorisedOverride)
                return false;
            LeaveCycleStart = DateTime.Now.Date;
            LeaveCarriedOver = TotalAmountOfLeavePerCycle;
            TotalAmountOfLeavePerCycle = totalAmountPerCycle ?? TotalAmountOfLeavePerCycle;
            return true;
        }
    }

    public class SickLeave : Leave
    {
        public SickLeave(int id,  int employeeId, double leaveAmmount, DateTime leaveCycleStart, int cycle, int totalAmountOfLeavePerCycle,int leaveTypeId = 1) : base(id, employeeId, leaveAmmount, leaveCycleStart, cycle, totalAmountOfLeavePerCycle, leaveTypeId)
        {
        }
    }
    public class FamilyResponsibilityLeave : Leave
    {
        public FamilyResponsibilityLeave(int id, int employeeId, double leaveAmmount, DateTime leaveCycleStart, int cycle, int totalAmountOfLeavePerCycle, int leaveTypeId=3) : base(id, employeeId, leaveAmmount, leaveCycleStart, cycle, totalAmountOfLeavePerCycle, leaveTypeId)
        {
        }
    }
    public class UnpaidLeave : Leave
    {
        public UnpaidLeave(int id, int employeeId, double leaveAmmount, DateTime leaveCycleStart, int cycle, int totalAmountOfLeavePerCycle, int leaveTypeId=4) : base(id, employeeId, leaveAmmount, leaveCycleStart, cycle, totalAmountOfLeavePerCycle, leaveTypeId)
        {
        }
    }
}
