using System.Collections.Generic;

namespace Mohandisy.Models
{
    public class ProjectServiceDocument
    {
        public int Id { get; set; }
        public List<ProjectService> ProjectServices { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}