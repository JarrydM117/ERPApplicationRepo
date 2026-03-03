using ERPApplication.DomainLayer.Models.Organisation;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.ExternalServices.Email.Factory
{
    public class RecipientFactory
    {

        public RecipientFactory() 
        {
        
        }
        public List<MailboxAddress> BuildMailBoxAddress(List<Recipients> recipients)
        {
            List<MailboxAddress> mailboxAddresses = new List<MailboxAddress>();
            foreach(var r in recipients)
            {
                mailboxAddresses.Add(new MailboxAddress(r.FullName, r.Email));
            }
            return mailboxAddresses;
        }
        public MailboxAddress BuildMailBoxAddress(Recipients recipient) => new MailboxAddress(recipient.FullName, recipient.Email);

    }
}
