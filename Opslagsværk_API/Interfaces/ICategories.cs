using Microsoft.EntityFrameworkCore;
using Opslagsværk_API.DTOs.CategoryDTOs;
using Opslagsværk.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.Interfaces
{
    public interface ICategories
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category?> DeleteCategoryAsync(int id);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategoryDTO);
        Task<List<Category>> GetAllCategoriesAsync();
    }
}