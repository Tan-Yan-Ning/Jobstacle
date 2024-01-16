using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class Course : BaseDomainModel
    { 
        public string? Title { get; set; }
        public string? Description { get; set; }   
        public string? Location { get; set; }       
        public int? OrganizerID { get; set; } 
        public virtual Organizer? Organizer { get; set; }   
        public int? StaffID { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual List<CourseRegistration>? CourseRegistrations { get; set; }

    }
}
