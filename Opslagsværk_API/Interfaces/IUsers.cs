using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opslagsværk_API.DTOs.UserDTOs;
using Opslagsværk.Shared;

namespace Opslagsværk_API.Interfaces
{
    public interface IUsers
    {
        Task<User> CreateUserAsync(User user);

        Task<User?> GetUserByIdAsync(int id);

        Task<List<ReadUserDTO>> GetAllUsersAsync();

        Task<User?> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO);

        Task<User?> DeleteUserAsync(int id);

        Task<User?> AuthenticateUser(AuthenticateUserDTO loginUserDTO);

        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(int emailId);
    }
}