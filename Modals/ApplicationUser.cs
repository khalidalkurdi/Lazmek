


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{    
    /// <summary>
    /// Represents an application user in the identity system.
    public class ApplicationUser : IdentityUser
    {
        
        [Required]
        public string Name { get; set; }
        public string? City { get; set; }
        public string? StreetAddress { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public DateOnly CreateAt { get; set; } = DateOnly.FromDateTime(DateTime.Today);
        [NotMapped]
        public string Role { get; set; }

    }
}
