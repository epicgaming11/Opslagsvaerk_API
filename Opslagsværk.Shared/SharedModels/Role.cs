using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk.Shared
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20, ErrorMessage = "Name is longer than 20 characters")]
        public string Name { get ; set; } = string.Empty;
    }
}