using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class JobSeeker : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Resume { get; set; }
        public string? Location { get; set; }
        public string? ContactNumber { get; set; }
        public virtual List<JobApplication>? JobApplications { get; set; }
        public virtual List<CourseRegistration>? CourseRegistrations { get; set; }



    }
}
