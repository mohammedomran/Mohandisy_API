using System.Collections.Generic;

namespace Mohandisy.Models
{
    public class ProjectSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }

    }
}