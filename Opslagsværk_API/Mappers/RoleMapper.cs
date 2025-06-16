using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opslagsværk_API.DTOs.RoleDTOs;
using Opslagsværk.Shared;

namespace Opslagsværk_API.Mappers
{
    public static class RoleMapper
    {
        public static Role ToRoleFromCreate(this CreateRoleDTO role)
        {
            return  new Role
            {
                Name = role.Name
            };
        }
    }
}