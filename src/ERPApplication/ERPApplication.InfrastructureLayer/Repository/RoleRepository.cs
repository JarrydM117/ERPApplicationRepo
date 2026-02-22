using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.InfrastructureLayer.Repository
{
    public class RoleRepository
    {
        private readonly ERPDataContext _context;

        public RoleRepository(ERPDataContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetRolesWithId(List<int> roleIds)
        {

            var roles = await _context.Set<Role>().Where(e=>roleIds.Contains(e.Id)).ToListAsync();
            return roles;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            List<Role> roles = await _context.Roles.ToListAsync();
            return roles;
        }
        public async Task<bool> CreateNewRoles(List<Role> roles)
        {
            await _context
                        .Set<Role>()
                        .AddRangeAsync(roles);
            var validate = await _context.SaveChangesAsync();
            return validate == 1;
        }
    }
}
