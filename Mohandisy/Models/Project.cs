using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int ProjectCategoryId { get; set; }
        public int ProjectSubCategoryId { get; set; }
        public decimal Area { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
    }
}
