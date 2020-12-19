using System;
using System.ComponentModel.DataAnnotations;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.DTOs
{
    public class CreateIdentityItemDto
    {
        [Required] 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}