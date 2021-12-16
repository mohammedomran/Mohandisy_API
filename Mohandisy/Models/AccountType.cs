using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mohandisy.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ApplicationRole ApplicationRole { get; set; }

    }
}
