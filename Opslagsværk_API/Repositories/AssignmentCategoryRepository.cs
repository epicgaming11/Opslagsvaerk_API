using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opslagsværk_API.DTOs.AssignmentCategoryDTOs;
using Opslagsværk_API.DTOs.CategoryDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk.Shared;
using Opslagsværk_API.Data;

namespace Opslagsværk_API.Repositories
{
    public class AssignmentCategoryRepository : IAssignmentCategories
    {
        private readonly ApiDbContext _context;
        public AssignmentCategoryRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<AssignmentCategory> CreateAssignmentCategoryAsync(AssignmentCategory assignmentCategory)
        {
            await _context.AddAsync(assignmentCategory);
            await _context.SaveChangesAsync();
            return assignmentCategory;
        }

        public async Task<AssignmentCategory?> DeleteAssignmentCategoryAsync(int Id)
        {
            var toDelete = await _context.AssignmentCategories.FindAsync(Id);

            if (toDelete == null)
            {
                return null;
            }

            _context.AssignmentCategories.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<List<AssignmentCategory>> GetAllAssignmentCategoryAsync()
        {
            return await _context.AssignmentCategories.ToListAsync();
        }

        public async Task<AssignmentCategory?> GetAssignmentCategoryByIdAsync(int Id)
        {
            var toFind = await _context.AssignmentCategories.FindAsync(Id);

            if (toFind == null)
            {
                return null;
            }

            return toFind;
        }

        public async Task<AssignmentCategory?> UpdateAssignmentCategoryAsync(int Id, UpdateAssignmentCategoryDTO updateAssignmentCategoryDTO)
        {
            var assignmentCategory = await _context.AssignmentCategories.FindAsync(Id);

            if (assignmentCategory == null)
            {
                return null;
            }
            assignmentCategory.CategoryID = updateAssignmentCategoryDTO.CategoryID;
            await _context.SaveChangesAsync();
            return assignmentCategory;
        }
    }
}