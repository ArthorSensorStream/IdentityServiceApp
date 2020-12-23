using System;

namespace IdentityServiceApp.Models
{
    [Serializable]
    public record Contact
    {
        public string BusinessName { get; set; }
        public string [] Phones { get; set; }
        public string [] Emails { get; set; }
    }
}