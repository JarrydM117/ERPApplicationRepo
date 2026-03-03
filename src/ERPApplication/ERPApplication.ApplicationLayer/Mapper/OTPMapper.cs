using ERPApplication.ApplicationLayer.DTOs.OTP;
using ERPApplication.DomainLayer.Models.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Mapper
{
    public class OTPMapper
    {

        public EmployeeOTP CreationToOTP(OTPCreationDTO creation)
        {
            return new EmployeeOTP(0,creation.EmployeeId);
        }

        public EmployeeOTP ValidationToOTP(OTPValidationDTO validation)
        {
            return new EmployeeOTP(0,validation.EmployeeId, validation.OTP, DateTime.MinValue);
        }
    }
}
