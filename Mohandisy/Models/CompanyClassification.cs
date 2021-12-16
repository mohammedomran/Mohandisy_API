using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Models
{
    public class CompanyClassification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ServiceProviderProfile> ExtendedProfiles { get; set; }
    }
}
