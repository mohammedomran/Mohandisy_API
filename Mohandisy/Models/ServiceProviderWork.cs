using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Models
{
    public class ServiceProviderWork
    {
        public int Id { get; set; }
        public int ProjectCategoryId { get; set; }
        public string ProjectName { get; set; }
        public string OwnerName { get; set; }
        public decimal ProjectPrice { get; set; }
        public int CompletionYear { get; set; }
    }
}
