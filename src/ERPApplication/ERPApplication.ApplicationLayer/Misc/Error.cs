using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Common
{
    public record Error(ErrorType ErrorCode, string Message);
}
