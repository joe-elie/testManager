using System.ComponentModel.DataAnnotations;

namespace TestManagerV2.Models
{
    public class Environment
    {
        public int EnvironmentId { get; set; }

        [Required]
        [StringLength(160)]
        public string EnvironmentName { get; set; }
    }
}
