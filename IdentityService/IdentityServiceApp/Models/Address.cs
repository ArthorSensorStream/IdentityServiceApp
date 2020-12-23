using System;

namespace IdentityServiceApp.Models
{
    [Serializable]
    public record Address
    {
        public string House { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Division { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}