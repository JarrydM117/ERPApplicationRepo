using ERPApplication.DomainLayer.Models.Organisation;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace ERPApplication.InfrastructureLayer.ExternalServices.Email.Factories
{
    public interface IMailboxFactory
    {

        public MailboxAddress BuildMailBox();
      
    }
    public class OTPMailBox : IMailboxFactory
    {
        private readonly IConfiguration _config;
        public OTPMailBox(IConfiguration config)
        {
            _config = config;
        }
        public MailboxAddress BuildMailBox()  => new MailboxAddress(_config["OTP:Name"], _config["OTP:EmailAddress"]);
        
    }
    public class NoticiationMailBox: IMailboxFactory
    {
        private readonly IConfiguration _config;
        public NoticiationMailBox(IConfiguration config)
        {
            _config = config;
        }
        public MailboxAddress BuildMailBox() => new MailboxAddress(_config["Note:Name"], _config["Note:Email"]);
    }
}
