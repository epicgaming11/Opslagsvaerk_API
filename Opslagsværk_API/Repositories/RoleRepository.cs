using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opslagsværk_API.DTOs.RoleDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk.Shared;
using Opslagsværk_API.Data;

namespace Opslagsværk_API.Repositories
{
    public class RoleRepository : IRole
    {
        private readonly ApiDbContext _context;

        public RoleRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Role> CreateRoleAsync(Role role)
        {
            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> DeleteRole(int id)
        {
            var toDelete = await _context.Roles.FindAsync(id);

            if (toDelete == null)
            {
                return null;
            }

            _context.Roles.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            var toFind = await _context.Roles.FindAsync(id);

            if (toFind == null)
            {
                return null;
            }

            return toFind;
        }

        public async Task<Role?> UpdateRoleAsync(int id, UpdateRoleDTO updateRoleDTO)
        {
            var role = await _context.Roles.FindAsync(id);

            if(role == null)
            {
                return null;
            }
            role.Name = updateRoleDTO.Name;
            await _context.SaveChangesAsync();
            return role;
        }
    }
}