using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityServiceApp.Models
{
    public record IdentityItem
    {
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Name => $"{FirstName} {LastName}";
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
