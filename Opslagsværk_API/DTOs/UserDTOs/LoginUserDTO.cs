using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Opslagsværk_API.DTOs.UserDTOs
{
    public class LoginUserDTO
    {
        public string? usernameOrEmail { get; set; } = string.Empty;
        public string? password { get; set; } = string.Empty;
    }
}