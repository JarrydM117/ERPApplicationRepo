using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Leave
{
    public interface ILeave
    {
         void SubtractLeave(double amountTaken);
         bool ValidateLeave(double amountTaken);

         void AddMonthlyLeave();
         bool StartNewCycle(bool authorisedOverride, int? totalAmountPerCycle);
    }
}
