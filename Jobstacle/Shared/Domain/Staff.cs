using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Department { get; set; }

        public string? Position { get; set; }

        public string? ContactNumber { get; set; }
        public virtual List<Job>? Jobs { get; set; }
    }
}
