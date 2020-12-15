using System;

namespace IdentityServiceApp.DTOs
{
    public record IdentityItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
