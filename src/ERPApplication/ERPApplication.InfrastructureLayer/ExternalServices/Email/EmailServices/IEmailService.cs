using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.ExternalServices.Email.EmailServices
{
    public interface IEmailService
    {
        Task<bool> SendEmail(MailboxAddress sender, List<MailboxAddress> recipients, string subject, string body);


        Task<bool> SendEmail(MailboxAddress sender, MailboxAddress recipients, string subject, string body);

    
    }
}
