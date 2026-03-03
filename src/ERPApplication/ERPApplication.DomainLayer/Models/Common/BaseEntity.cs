using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.DomainLayer.Models.Common
{
    public class BaseEntity
    {
        public int Id { get;private set; }

        public BaseEntity(int id)
        {
            Id = id;
        }

    }
}
