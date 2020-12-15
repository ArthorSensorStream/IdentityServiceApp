using System.ComponentModel.DataAnnotations;

namespace IdentityServiceApp.DTOs
{
    public class CreateIdentityItemDto
    {
        [Required]
        public string Name { get; init; }
    }
}
