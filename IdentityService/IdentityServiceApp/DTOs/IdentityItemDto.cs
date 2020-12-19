using System;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.DTOs
{
    public record IdentityItemDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}