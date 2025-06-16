using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opslagsværk_API.DTOs.RoleDTOs;
using Opslagsværk.Shared;

namespace Opslagsværk_API.Interfaces
{
    public interface IRole
    {
        Task<Role> CreateRoleAsync(Role role);
        Task<Role?> UpdateRoleAsync(int id, UpdateRoleDTO updateRoleDTO);
        Task<Role?> DeleteRole(int id);
        Task<Role?> GetRoleByIdAsync(int id);
    }
}