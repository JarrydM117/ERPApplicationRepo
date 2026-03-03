using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Organisation
{
    public class Recipients
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public Recipients(string fullName, string email) 
        { 
            FullName = fullName;
            Email = email;
        }

    }
}
