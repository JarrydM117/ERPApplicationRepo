using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models
{
    public class Status:BaseEntity
    {
        public string Name { get; set; }
        public Status(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
