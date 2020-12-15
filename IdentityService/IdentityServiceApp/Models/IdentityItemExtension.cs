using IdentityServiceApp.DTOs;

namespace IdentityServiceApp.Models
{
    public static class IdentityItemExtension
    {
        public static IdentityItemDto AsDto(this IdentityItem item)
        {
            return new IdentityItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                CreatedDate = item.CreatedDate
            };
        }
    }
}