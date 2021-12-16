using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mohandisy.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string RoleId { get; set; }
        [Required]
        public int AccountId { get; set; }
    }
}