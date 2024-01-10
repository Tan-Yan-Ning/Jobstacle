using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class JobApplication : BaseDomainModel
    {
        public DateTime ApplicationDate { get; set; }

        public int JobSeekerID { get; set; } 
        public virtual JobSeeker? JobSeeker { get; set; }

        public int JobID { get; set; }
        public virtual Job? Job { get; set; }
    }
}
