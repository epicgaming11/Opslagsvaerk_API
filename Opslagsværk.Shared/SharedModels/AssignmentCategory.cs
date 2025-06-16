using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Opslagsværk.Shared
{
    public class AssignmentCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        [Required]
        public int AssignmentID { get; set; }

        public Assignment Assignment { get; set; }
    }
}