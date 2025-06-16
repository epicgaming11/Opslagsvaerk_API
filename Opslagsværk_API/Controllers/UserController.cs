using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Opslagsværk_API.DTOs.UserDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk_API.Mappers;
using Opslagsværk_API.Services;

namespace Opslagsværk_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUsers _userRepo;
        private readonly JwtGenerator _jwtGenerator;
        private readonly IRole _roleRepo;

        public UserController(IUsers iusers, IRole role, JwtGenerator jwtGenerator)
        {
            _userRepo = iusers;
            _roleRepo = role;
            _jwtGenerator = jwtGenerator;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createUserDTO.Hashed_password);
            var user = createUserDTO.ToCreateUserFromDTO(hashedPassword);

            //PROBLEM RIGHT NOW IS ERROR AT ROLEID AND EMAILID AND EMAIL

            // Find the Role with a given roleid
            var role = await _roleRepo.GetRoleByIdAsync(user.Role_id);
            if (role == null)
            {
                return NotFound($"Role with id: {user.Role_id} not found.");
            }

            user.Role = role;
            //Add the user  to the roles's users collection

            await _userRepo.CreateUserAsync(user);

            return Ok($"User {user.Username} created successfully.");
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepo.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with id: {id} not found.");
            }

            await _userRepo.DeleteUserAsync(id);

            return Ok($"User with id {id} deleted successfully.");
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepo.GetAllUsersAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepo.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with id: {id} not found.");
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepo.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound($"User with id: {id} not found."); 
            }

            await _userRepo.UpdateUserAsync(user.Id, userDTO);
            return Ok($"User with id: {id} updated successfully.");
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserDTO authenticateDTO)
        {
            if (authenticateDTO == null || string.IsNullOrEmpty(authenticateDTO.Username) || string.IsNullOrEmpty(authenticateDTO.Hashed_password))
            {
                return BadRequest("Username and Password are required.");
            }

            var auth = await _userRepo.AuthenticateUser(authenticateDTO);

            if (auth == null) 
            {
                return BadRequest("Username or password wrong");
            }
            var user = auth.ToReadUserDTO();
            string token = _jwtGenerator.GenerateToken(user.Id.ToString(), user.RoleId.ToString());
            return Ok(new
            {
                message = "Login successful!",
                token,
                user.Id,
                user.RoleId
            });
        }
    }
}