using Opslagsværk_API.DTOs.AssignmentCategoryDTOs;
using Opslagsværk_API.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opslagsværk.Shared;

namespace Opslagsværk_API.Mappers
{
    public static class AssignmentCategoryMapper
    {
        public static ReadAssignmentCategoryDTO ToReadAssignmentCategoryDTO(this AssignmentCategory assignmentCategory)
        {
            return new ReadAssignmentCategoryDTO
            {
                Id = assignmentCategory.Id,
                CategoryID = assignmentCategory.CategoryID,
                AssignmentID = assignmentCategory.AssignmentID
            };
        }
        public static AssignmentCategory ToAssignmentCategoryFromCreate(this CreateAssignmentCategoryDTO assignmentCategory)
        {
            return new AssignmentCategory
            {
                CategoryID = assignmentCategory.CategoryID,
                AssignmentID = assignmentCategory.AssignmentID
            };
        }
    }
}   