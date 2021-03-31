using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestManagerV2.Models
{
    public class Test
    {
        public int TestId { get; set; }

        [Required]
        [StringLength(60)]
        public string TestName { get; set; }

        [Required]
        [StringLength(255)]
        public string TestDescription { get; set; }

        [Required]
        [StringLength(60)]
        public string CircuitName { get; set; }

        [Required]
        public int CircuitId { get; set; }

        [Required]
        [StringLength(60)]
        public string Environment { get; set; }

        [Required]
        public List<Step> Steps { get; set; }

        [Required]
        public bool Published { get; set; }

    }
}
