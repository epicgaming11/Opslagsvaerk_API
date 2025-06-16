using Opslagsværk_API.DTOs.AssignmentCategoryDTOs;
using Opslagsværk_API.DTOs.AssignmentDTOs;
using Opslagsværk_API.DTOs.UserDTOs;
using Opslagsværk.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.Mappers
{
    public static class AssignmentMapper
    {
        public static ReadAssignmentDTO ToReadAssignmentDTO(this Assignment assignment)
        {
            return new ReadAssignmentDTO
            {
                Id = assignment.Id,
                ImgUrl = assignment.ImgURL,
                Name = assignment.Name,
                Description = assignment.Description,
                UserId = assignment.UserID
            };
        }

        public static Assignment ToAssignmentFromCreate(this CreateAssignmentDTO assignment)
        {
            return new Assignment
            {
                Name = assignment.Name,
                Description = assignment.Description,
                ImgURL = assignment.ImgUrl,
                UserID = assignment.UserId,
            };
        }
    }
}