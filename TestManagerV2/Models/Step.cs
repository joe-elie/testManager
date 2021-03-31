using System.ComponentModel.DataAnnotations;

namespace TestManagerV2.Models
{
    public class Step
    {

        public int TestId { get; set; }

        public int StepId { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(60)]
        public string Action { get; set; }

        [Required]
        [StringLength(60)]
        public string ElementIdentifier { get; set; }

        [Required]
        [StringLength(60)]
        public string ElementIdentifierType { get; set; }

        [Required]
        [StringLength(60)]
        public string Data { get; set; }

        [Required]
        public int? ElementIndex { get; set; }

        [Required]
        [StringLength(255)]
        public string ErrorDescription { get; set; }

        [Required]
        public int StepNumber { get; set; }

    }
}
