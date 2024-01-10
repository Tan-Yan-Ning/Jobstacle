using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class Organizer : BaseDomainModel
    {
        public string? Name { get; set; }

        public string? ContactNumber { get; set; }

        public string? Email { get; set; }

        public string? Description { get; set; }
        public virtual List<Course>? Courses { get; set; }
    }
}
