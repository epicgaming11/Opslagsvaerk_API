using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opslagsværk_API.DTOs.UserDTOs;
using Opslagsværk.Shared;

namespace Opslagsværk_API.Mappers
{
    public static class UserMapper
    {
        public static ReadUserDTO ToReadUserDTO(this User user)
        {
            return new ReadUserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                RoleId = user.Role_id,
                RoleName = user.Role.Name
            };
        }

        public static User ToCreateUserFromDTO(this CreateUserDTO createUserDTO, string Hashed_password)
        {
            return new User
            {
                Username = createUserDTO.Username,
                Email = createUserDTO.Email,
                Hashed_password = createUserDTO.Hashed_password,
                Role_id = createUserDTO.RoleId
            };
        }

        public static User ToUpdateUserFromDTO(UpdateUserDTO dto)
        {
            return new User
            {
                Username = dto.Username ?? throw new ArgumentNullException(nameof(dto.Username)),
                Email = dto.Email ?? throw new ArgumentNullException(nameof(dto.Email))
            };
        }
    }
}