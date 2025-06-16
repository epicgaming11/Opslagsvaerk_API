using Opslagsværk_API.DTOs.AssignmentCategoryDTOs;
using Opslagsværk_API.DTOs.CategoryDTOs;
using Opslagsværk.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.Interfaces
{
    public interface IAssignmentCategories
    {
        Task<AssignmentCategory> CreateAssignmentCategoryAsync(AssignmentCategory assignmentCategory);
        Task<AssignmentCategory?> DeleteAssignmentCategoryAsync(int Id);
        Task<AssignmentCategory?> GetAssignmentCategoryByIdAsync(int Id);
        Task<AssignmentCategory?> UpdateAssignmentCategoryAsync(int Id, UpdateAssignmentCategoryDTO updateAssignmentCategoryDTO);
        Task<List<AssignmentCategory>> GetAllAssignmentCategoryAsync();
    }
}