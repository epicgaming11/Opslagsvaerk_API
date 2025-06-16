using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk_API.DTOs.CategoryDTOs
{
    public class ReadCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}