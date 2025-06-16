using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Opslagsværk_API.DTOs.CategoryDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk_API.Mappers;

namespace Opslagsværk_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories _categoriesRepo;

        public CategoriesController(ICategories categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categories = await _categoriesRepo.GetAllCategoriesAsync();

            var categoryDTO = categories.Select(s => s.CategoryToDto());

            return Ok(categoryDTO);
        }

        [HttpGet]
        [Route("GetCategoryById/{id:int}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoriesRepo.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound($"Category with id: {id} not found.");
            }
            return Ok(category);
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody]CreateCategoryDTO createCategoryDTO)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState); 
            }

            var category = createCategoryDTO.ToCategoryFromCreate();

            await _categoriesRepo.CreateCategoryAsync(category);

            return Ok("Category Added!");
        }

        [HttpPut]
        [Route("UpdateCategory/{id:int}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] UpdateCategoryDTO updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoriesRepo.UpdateCategoryAsync(id, updateDto);

            if (category == null)
            {
                return NotFound("No category found to update.");
            }

            return Ok(category.CategoryToDto());
        }

        [HttpDelete]
        [Route("DeleteCategory/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoriesRepo.DeleteCategoryAsync(id);

            if (category == null)
            {
                return NotFound("No category found to delete");
            }

            return NoContent();
        }
    }
}