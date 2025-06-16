using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opslagsværk_API.DTOs.RoleDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk_API.Mappers;
using Opslagsværk_API.Data;
using Opslagsværk_API.Repositories;
using Opslagsværk_API.Services;

namespace Opslagsværk_API.Controllers
{
    [ApiController]
    [Route("api/Role")]
    public class RoleController : ControllerBase
    {
        private readonly IRole _roleRepo;

        public RoleController(IRole roleRepository)
        {
            _roleRepo = roleRepository;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleModel = roleDTO.ToRoleFromCreate();

            //Call repository to save the role
            var createdRole = await _roleRepo.CreateRoleAsync(roleModel);

            return Ok("Role created successfully");
        }

        [HttpGet]
        [Route("GetRoleById/{id:int}")]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleRepo.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound($"Role with id {id} not found");
            }
            return Ok(role);
        }

        [HttpPut]
        [Route("UpdateRole/{id:int}")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] UpdateRoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleRepo.UpdateRoleAsync(id, roleDTO);
            
            if (role == null)
            {
                return NotFound($"Role with id {id} not found");
            }

            return Ok("Role updated successfully");
        }

        [HttpDelete]
        [Route("DeleteRole/{id:int}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleRepo.DeleteRole(id);

            if (role == null)
            {
                return NotFound($"Role with id {id} not found");
            }

            return Ok($"Role: {role.Name} was deleted successfully");
        }
    }
}