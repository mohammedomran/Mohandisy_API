using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Models
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsActive { get; set; } = true;
        [Required]
        [MaxLength(30)]
        public string ArabicName { get; set; }
        public ICollection<AccountType> AccountTypes { get; set; }
    }
}
