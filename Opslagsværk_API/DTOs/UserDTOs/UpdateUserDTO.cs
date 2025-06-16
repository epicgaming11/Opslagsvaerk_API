using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string? Hashed_password { get; set; }
    }
}