using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Organisation
{
    public  class Role: BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Role(int id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }
    }
}
