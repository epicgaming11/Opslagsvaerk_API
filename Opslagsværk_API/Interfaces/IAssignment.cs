using Opslagsværk_API.DTOs.AssignmentDTOs;
using Opslagsværk_API.DTOs.CategoryDTOs;
using Opslagsværk.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.Interfaces
{
    public interface IAssignment
    {
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<Assignment?> DeleteAssignmentAsync(int id);
        Task<Assignment?> GetAssignmentByIdAsync(int id);
        Task<Assignment?> UpdateAssignmentAsync(int id, UpdateAssignmentDTO updateAssignmentDTO);
        Task<List<Assignment>> GetAllAssignmentAsync();
        Task<List<Assignment>> GetAssignmentsByCategoryId(int id);
    }
}