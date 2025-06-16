
using Microsoft.EntityFrameworkCore;
using Opslagsværk_API.DTOs.AssignmentDTOs;
using Opslagsværk_API.Interfaces;
using Opslagsværk.Shared;
using Opslagsværk_API.Data;

namespace Opslagsværk_API.Repositories
{
    public class AssignmentRepository : IAssignment
    {
        private readonly ApiDbContext _context;
        public AssignmentRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            await _context.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<Assignment?> DeleteAssignmentAsync(int id)
        {
            var toDelete = await _context.Assignments.FindAsync(id);

            if (toDelete == null)
            {
                return null;
            }

            _context.Assignments.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }

        public async Task<List<Assignment>> GetAllAssignmentAsync()
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task<Assignment?> GetAssignmentByIdAsync(int id)
        {
            var toFind = await _context.Assignments.FindAsync(id);

            if (toFind == null)
            {
                return null;
            }

            return toFind;
        }

        public async Task<Assignment?> UpdateAssignmentAsync(int id, UpdateAssignmentDTO updateAssignmentDTO)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return null;
            }
            if (updateAssignmentDTO.Name == null)
            {
                return null;
            }
            assignment.Name = updateAssignmentDTO.Name;
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<List<Assignment>> GetAssignmentsByCategoryId(int id)
        {
            return await _context.Assignments
                    .Where(a => a.AssignmentCategories.Any(ac => ac.CategoryID == id))
                    .ToListAsync();
        }
    }
}