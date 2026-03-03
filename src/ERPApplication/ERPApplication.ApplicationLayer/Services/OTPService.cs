using ERPApplication.ApplicationLayer.Common;
using ERPApplication.ApplicationLayer.DTOs.OTP;
using ERPApplication.ApplicationLayer.Mapper;
using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.EmailServices;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.Factories;
using ERPApplication.InfrastructureLayer.ExternalServices.Email.Factory;
using ERPApplication.InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace ERPApplication.ApplicationLayer.Services
{
    public class OTPService
    {

        private readonly OTPMapper _otpMapper;
        private readonly OTPRepository _otpRepository;
        private readonly IEmailService _emailService;
        private readonly IMailboxFactory _mailboxFactory;
        private readonly RecipientFactory _recipientFactory;
        public OTPService(OTPMapper otpMapper, OTPRepository otpRepository, IEmailService emailService, OTPMailBox mailboxFactory, RecipientFactory recipientFactory)
        {
            _otpMapper = otpMapper;
            _otpRepository = otpRepository;
            _emailService = emailService;
            _mailboxFactory = mailboxFactory;
            _recipientFactory = recipientFactory;
        }

        public async Task<Result> OTPCreateOrUpdateTransaction(OTPCreationDTO otpCreation)
        {
            var otp = new EmployeeOTP(0, otpCreation.EmployeeId);
            string tempOtp = string.Empty;
            bool flag = false;
            if (await OTPExists(otp.EmployeeId))
            {
                otp = await Get(otp.EmployeeId);
                otp.CreateOTP();
                tempOtp = otp.OTP;
                otp.HashOTP();
                flag = await UpdateOTP(otp);
            }
            else
            {
                otp.CreateOTP();
                tempOtp = otp.OTP;
                otp.HashOTP();
                flag = await CreateOTP(otp);
                otp = await Get(otp.EmployeeId);
            }
            if (!flag)
                return Result.Unsuccessful(ErrorType.FailedInsertion, "Could not Insert new OTP, Please try Again.");
            return await SendEmail(otp, tempOtp);
        }


    
        private async Task<Result> SendEmail(EmployeeOTP otp, string _otp)
        {
            string subject = "Password Reset OTP";
            string body = $"Good day {otp.Employee.FirstName},\r\n\r\n" +
                           $"Your password request has been processed, your OTP is: <b>{_otp}</b>";
            return await _emailService.SendEmail(_mailboxFactory.BuildMailBox(), _recipientFactory.BuildMailBoxAddress(new Recipients(otp.Employee.FirstName, otp.Employee.EmailAddress)), subject, body) ? Result.Success(): Result.Unsuccessful(ErrorType.InvalidOperation, "Could not Send Email, Please Try Again.");
        }

        public async Task<Result> ValidateOTP(OTPValidationDTO otpValidation)
        {
            string tempOTP = otpValidation.OTP;
            var otp = _otpMapper.ValidationToOTP(otpValidation);
            otp = await _otpRepository.Get(otp.EmployeeId);
            if (otp == null) 
                return Result.Unsuccessful(ErrorType.NotFound, "OTP Does not Exist");
            return otp.ValidateOTP(tempOTP) ? Result.Success() : Result.Unsuccessful(ErrorType.InvalidData, "Invalid OTP.");
        }

        private async Task<bool> OTPExists(int employeeId)
        {
            return await _otpRepository.Exists(employeeId);
        }

        private async Task<bool> CreateOTP(EmployeeOTP otp)
        {
            return (await _otpRepository.Create(otp)) == 1;
        }

        private async Task<bool> UpdateOTP(EmployeeOTP otp)
        {

            return (await _otpRepository.Update(otp)) == 1;
        }

        private async Task<EmployeeOTP> Get(int employeeId)
        {
            return (await _otpRepository.Get(employeeId));
        }
        

    }
}
