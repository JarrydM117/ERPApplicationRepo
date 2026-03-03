using ERPApplication.ApplicationLayer.DTOs.OTP;
using ERPApplication.ApplicationLayer.Services;
using ERPApplication.PresentationLayer.HelperMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPApplication.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPController : ControllerBase
    {
        private readonly OTPService _otpService;
        public OTPController(OTPService otpService)
        {
            _otpService = otpService;
        }
        [HttpPost("CreateOrUpdateOTP")]
        public async Task<IActionResult> CreateOrUpdateOTP([FromBody] OTPCreationDTO otp)
        => ResultMapper.ReturnResult(await _otpService.OTPCreateOrUpdateTransaction(otp));
       
        [HttpGet("ValidateOTP")]
        public async Task<IActionResult> ValidateOTP(OTPValidationDTO otp)
        => ResultMapper.ReturnResult(await _otpService.ValidateOTP(otp));
    }
}
