using ERPApplication.DomainLayer.Models.Common;
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
        public DateTime CreationDate { get; private set; }
        public int RoleOwner {  get; private set; }
        public Employee Owner { get;  set; }

        public Role(int id, string name, string description, DateTime creationDate, int roleOwner) : base(id)
        {
            Name = name;
            Description = description;
            CreationDate = creationDate;
            RoleOwner = roleOwner;
        }
    }
}
