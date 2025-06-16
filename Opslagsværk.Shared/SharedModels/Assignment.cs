using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk.Shared
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255, ErrorMessage = "Message is longer than 255 characters")]
        public string ImgURL { get ; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255, ErrorMessage = "Name is longer than 255 characters")]
        public string Name { get ; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255, ErrorMessage = "Description is longer than 255 characters")]
        public string Description { get ; set; } = string.Empty;

        [Required]
        public int UserID { get; set; }

        public User User { get; set; } = null!;

        public ICollection<AssignmentCategory> AssignmentCategories { get; set; }
    }
}