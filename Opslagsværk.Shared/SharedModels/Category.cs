using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk.Shared
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255, ErrorMessage = "Name is longer than 255 characters")]
        public string Name { get ; set; } = string.Empty;
    }
}