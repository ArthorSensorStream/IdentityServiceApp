using System;
using System.ComponentModel.DataAnnotations;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.DTOs
{
    public class CreateIdentityItemDto
    {
        [Required] 
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}