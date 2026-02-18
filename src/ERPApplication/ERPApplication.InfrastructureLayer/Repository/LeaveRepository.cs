using ERPApplication.DomainLayer.Models.Leave;
using ERPApplication.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Repository
{
    public  class LeaveRepository
    {
        private readonly ERPDataContext _context;
        public LeaveRepository(ERPDataContext context)
        {
            _context = context;
        }

     


    }
}
