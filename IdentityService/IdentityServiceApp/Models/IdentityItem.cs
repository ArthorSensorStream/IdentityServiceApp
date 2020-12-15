using System;

namespace IdentityServiceApp.Models
{
    public record IdentityItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
