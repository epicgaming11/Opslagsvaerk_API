using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opslagsværk_API.DTOs.AssignmentCategoryDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk_API.Mappers;

namespace Opslagsværk_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentCategoriesController : ControllerBase
    {
        private readonly IAssignmentCategories _assignmentCategoryRepo;

        public AssignmentCategoriesController(IAssignmentCategories assignmentCategoriesRepo)
        {
            _assignmentCategoryRepo = assignmentCategoriesRepo;
        }

        [HttpGet]
        [Route("GetAllAssignmentCategories")]
        public async Task<IActionResult> GetAllAssignmentCategoriesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentCategories = await _assignmentCategoryRepo.GetAllAssignmentCategoryAsync();

            var AssignmentCategoryDTO = assignmentCategories.Select(s => s.ToReadAssignmentCategoryDTO());

            return Ok(AssignmentCategoryDTO);
        }

        [HttpGet]
        [Route("GetAssignmentCategoryById/{id:int}")]
        public async Task<IActionResult> GetAssignmentCategoryByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentCategory = await _assignmentCategoryRepo.GetAssignmentCategoryByIdAsync(id);

            if (assignmentCategory == null)
            {
                return NotFound($"AssignmentCategory with id: {id} not found.");
            }
            return Ok(assignmentCategory);
        }

        [HttpPost]
        [Route("CreateAssignmentCategory")]
        public async Task<IActionResult> CreateAssignmentCategoryAsync([FromBody] CreateAssignmentCategoryDTO createAssignmentCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentCategory = createAssignmentCategoryDTO.ToAssignmentCategoryFromCreate();

            await _assignmentCategoryRepo.CreateAssignmentCategoryAsync(assignmentCategory);

            return Ok("AssignmentCategory Added!");
        }

        [HttpPut]
        [Route("UpdateAssignmentCategory/{id:int}")]
        public async Task<IActionResult> UpdateAssignmentCategoryAsync([FromRoute] int id, [FromBody] UpdateAssignmentCategoryDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentCategory = await _assignmentCategoryRepo.UpdateAssignmentCategoryAsync(id, updateDto);

            if (assignmentCategory == null)
            {
                return NotFound("No AssignmentCategory found to update.");
            }

            return Ok(assignmentCategory.ToReadAssignmentCategoryDTO());
        }

        [HttpDelete]
        [Route("DeleteAssignmentCategory/{id:int}")]
        public async Task<IActionResult> DeleteAssignmentCategoryAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignmentCategory = await _assignmentCategoryRepo.DeleteAssignmentCategoryAsync(id);

            if (assignmentCategory == null)
            {
                return NotFound("No AssignmentCategory found to delete.");
            }

            return NoContent();
        }
    }
}