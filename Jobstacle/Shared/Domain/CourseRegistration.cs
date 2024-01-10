using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class CourseRegistration : BaseDomainModel
    {
        public DateTime RegistrationDate { get; set; }
        public int JobSeekerID { get; set; } 
        public virtual JobSeeker? JobSeeker { get; set; }
        public int CourseID { get; set; }
        public virtual Course? Course { get; set; } 
    }
}
