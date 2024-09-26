using System.ComponentModel.DataAnnotations;

namespace DotNet8API.dto
{
    public class UpdateOurHeroRequest
    {
        [Required]
        [StringLength(100)]
        public required string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        public bool isActive { get; set; }
        public UpdateOurHeroRequest()
        {
            isActive = true;
        }
    }
}
