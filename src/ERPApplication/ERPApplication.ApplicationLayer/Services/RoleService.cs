using ERPApplication.ApplicationLayer.DTOs.Roles;
using ERPApplication.ApplicationLayer.Mapper;
using ERPApplication.DomainLayer.Models.Organisation;
using ERPApplication.InfrastructureLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Services
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;
        private readonly RoleMapper _roleMapper;
        protected RoleService(RoleRepository roleRepository, RoleMapper roleMapper)
        {
            _roleRepository = roleRepository;
            _roleMapper = roleMapper;
        }


        protected async Task<List<Role>> GetAllRoles(List<RoleEmployeeDTO> roleEmployee)
        {
            List<Role> roles = _roleMapper.EmployeeRoleDtoToRoles(roleEmployee);
            roles = await _roleRepository.GetRolesWithId(roles.Select(x=>x.Id).ToList());
            return roles;
        }




    }
}
