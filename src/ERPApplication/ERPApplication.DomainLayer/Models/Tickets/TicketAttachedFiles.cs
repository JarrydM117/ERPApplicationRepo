using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Tickets
{
    public  class TicketAttachedFiles: BaseEntity
    {
        public int TicketId { get;  set; }
        public string FileUri { get; private set; }
        public string CheckSum {  get; private set; }
        public TicketAttachedFiles(int id, string fileUri, string checkSum) : base(id)
        {
            FileUri = fileUri;
            CheckSum = checkSum;
        }
    }
}
