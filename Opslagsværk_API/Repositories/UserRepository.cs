using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opslagsværk_API.DTOs.UserDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk.Shared;
using Opslagsværk_API.Data;
using BCrypt;
using Opslagsværk_API.Mappers;

namespace Opslagsværk_API.Repositories
{
    public class UserRepository : IUsers
    {
        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Hashed_password = BCrypt.Net.BCrypt.HashPassword(user.Hashed_password);

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            var toDelete = await _context.Users.FindAsync(id);

            if (toDelete == null)
            {
                return null;
            }

            _context.Users.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var toFind = await _context.Users.FindAsync(id);

            if (toFind == null)
            {
                return null;
            }

            return toFind;
        }

        public async Task<User?> UpdateUserAsync(int id, UpdateUserDTO updateUserDTO)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            var userExistingUsername = _context.Users.FirstOrDefault(x => x.Username == updateUserDTO.Username);
            var userExistingEmail = _context.Users.FirstOrDefault(x => x.Email == updateUserDTO.Email);
            if (userExistingUsername == null)
            {
                if (updateUserDTO.Username != null)
                {
                    user.Username = updateUserDTO.Username;
                }
            }
            else { return null; }

            if (userExistingEmail == null)
            {
                if (updateUserDTO.Email != null)
                {
                    user.Email = updateUserDTO.Email;
                }
            }
            else { return null; }

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> AuthenticateUser(AuthenticateUserDTO loginUserDTO)
        {
            var existingUser = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(x => x.Username == loginUserDTO.Username);
            if (existingUser == null)
            {
                return null;
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginUserDTO.Hashed_password, existingUser.Hashed_password);

            if (isPasswordValid)
            {
                return existingUser;
            }
            else
            {
                return null;
            }
        }


        public Task<List<ReadUserDTO>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public Task<User?> GetByEmailAsync(int emailId)
        {
            throw new NotImplementedException();
        }
    }
}