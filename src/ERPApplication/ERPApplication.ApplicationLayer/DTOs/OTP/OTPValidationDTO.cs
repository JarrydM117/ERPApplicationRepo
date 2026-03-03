using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.DTOs.OTP
{
    public record OTPValidationDTO(int EmployeeId, string OTP);
}
