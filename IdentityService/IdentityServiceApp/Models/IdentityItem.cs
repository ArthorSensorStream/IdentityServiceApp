using System;

namespace IdentityServiceApp.Models
{
    public record IdentityItem
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Name => $"{FirstName} {LastName}";
        public Address Address { get; set; }
        public Contact Contact { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
