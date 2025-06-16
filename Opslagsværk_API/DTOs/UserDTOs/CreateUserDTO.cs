using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Hashed_password {get; set; } = string.Empty;
        public int RoleId { get; set; }

    }
}