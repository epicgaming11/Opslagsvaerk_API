using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Opslagsværk_API.DTOs.AssignmentDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk_API.Mappers;
using Opslagsværk_API.Repositories;

namespace Opslagsværk_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignment _assignmentRepo;

        public AssignmentController(IAssignment assignmentRepo)
        {
            _assignmentRepo = assignmentRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllAssignments")]
        public async Task<IActionResult>GetAllAssignmentsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _assignmentRepo.GetAllAssignmentAsync();

            var AssignmentDTO = assignment.Select(s => s.ToReadAssignmentDTO());

            return Ok(AssignmentDTO);
        }

        [HttpGet]
        [Route("GetAssignmentById/{id:int}")]

        public async Task<IActionResult> GetAssignmentByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _assignmentRepo.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound($"Assignment with id: {id} not found.");
            }
            return Ok(assignment);
        }

        [HttpGet]
        [Route("getassignmentbycategoryid/{id:int}")]
        public async Task<IActionResult> GetAssignmentsByCategoryId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignments = await _assignmentRepo.GetAssignmentsByCategoryId(id);

            return Ok(assignments);

        }
        [HttpPost]
        [Route("CreateAssignment")]

        public async Task<IActionResult> CreateAssignmentAsync([FromBody] CreateAssignmentDTO createAssignmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = createAssignmentDTO.ToAssignmentFromCreate();

            await _assignmentRepo.CreateAssignmentAsync(assignment);
            return Ok(assignment);
        }

        [HttpPut]
        [Route("UpdateAssignment/{id:int}")]

        public async Task<IActionResult> UpdateAssignmentAsync
            ([FromRoute]int id, [FromBody] UpdateAssignmentDTO updateAssignmentDTO)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _assignmentRepo.UpdateAssignmentAsync(id, updateAssignmentDTO);
            if (assignment == null)
            {
                return NotFound("No Assignment found to update.");
            }

            return Ok(assignment);
        }

        [HttpDelete]
        [Route("DeleteAssignment/{id:int}")]

        public async Task<IActionResult> DeleteAssignmentAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _assignmentRepo.DeleteAssignmentAsync(id);

            if (assignment == null)
            {
                return NotFound("No Assignment found to delete.");
            }

            return Ok(assignment);
        }

    }
}