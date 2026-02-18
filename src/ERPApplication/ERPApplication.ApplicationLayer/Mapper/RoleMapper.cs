using ERPApplication.ApplicationLayer.DTOs.Roles;
using ERPApplication.DomainLayer.Models.Organisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPApplication.ApplicationLayer.Mapper
{
    public class RoleMapper: IEntityMapper
    {
        public List<RoleEmployeeDTO> RolesToRoleEmployee(List<Role> roles)
        {
            List<RoleEmployeeDTO> roleEmployees = new List<RoleEmployeeDTO>();
            foreach (Role r in roles)
            {
                roleEmployees.Add(new RoleEmployeeDTO(r.Id, r.Name));
            }
            return roleEmployees;
        }
        public List<Role> EmployeeRoleDtoToRoles(List<RoleEmployeeDTO> rolesEmployees)
        {
            List<Role> roles = new List<Role>();
            foreach (RoleEmployeeDTO r in rolesEmployees)
                roles.Add(new Role(r.Id, r.Name, string.Empty));
            return roles;

        }
    }
}
