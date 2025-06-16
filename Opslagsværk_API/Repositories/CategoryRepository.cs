using Microsoft.EntityFrameworkCore;
using Opslagsværk_API.DTOs.CategoryDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk.Shared;
using Opslagsværk_API.Data;

namespace Opslagsværk_API.Repositories
{
    public class CategoryRepository : ICategories
    {
        private readonly ApiDbContext _context;

        public CategoryRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategoryAsync(int id)
        {
            var toDelete = await _context.Categories.FindAsync(id);

            if (toDelete == null)
            {
                return null;
            }

            _context.Categories.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var toFind = await _context.Categories.FindAsync(id);

            if (toFind == null)
            {
                return null;
            }

            return toFind;
        }

        public async Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }
            category.Name = updateCategoryDTO.Name;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}