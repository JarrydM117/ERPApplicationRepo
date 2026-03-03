using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Org.BouncyCastle.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.ExternalServices.Email.EmailServices
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendEmail(MailboxAddress sender, List<MailboxAddress> recipients, string subject, string body)
        {
            var message = new MimeMessage(sender, recipients, subject, new TextPart(body));
            return await SendEmail(message, sender.Address);
        }

        public async Task<bool> SendEmail(MailboxAddress sender, MailboxAddress recipients, string subject, string body)
        {
            var message = new MimeMessage();
            message.To.Add(recipients);
            message.Sender = sender;
            message.Subject = subject;
            message.Body = new TextPart(body);
            return await SendEmail(message, sender.Address);
        }

        private async Task<bool> SendEmail(MimeMessage message, string sender)
        {
            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, false);
                    await client.AuthenticateAsync(sender, _config[$"Password:{sender}"]);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
