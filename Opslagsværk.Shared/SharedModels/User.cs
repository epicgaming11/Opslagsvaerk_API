using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk.Shared
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        [MaxLength(20, ErrorMessage = "Username is longer than 20 characters")]
        public string Username { get ; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(20, ErrorMessage = "Password is longer than 255 characters")]
        public string Hashed_password { get ; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Column(TypeName = "nvarchar(255)")]
        [MaxLength(255, ErrorMessage = "Email is longer than 255 characters")]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public int Role_id { get; set; }

        public Role Role { get; set; } = null!;

        public ICollection<Assignment> Assignments { get; set; } 
    }
}