using Opslagsværk_API.DTOs.CategoryDTOs;
using Opslagsværk.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.Mappers
{
    public static class CategoryMapper
    {
        public static ReadCategoryDTO CategoryToDto(this Category category)
        {
            return new ReadCategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
        public static Category ToCategoryFromCreate(this CreateCategoryDTO category)
        {
            return new Category
            {
                Name = category.Name
            };
        }
    }
}