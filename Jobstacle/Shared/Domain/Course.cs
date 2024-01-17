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
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }
        [Required(ErrorMessage = "OrganizerID is required")]
        public int? OrganizerID { get; set; } 
        public virtual Organizer? Organizer { get; set; }
        [Required(ErrorMessage = "StaffID is required")]
        public int? StaffID { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual List<CourseRegistration>? CourseRegistrations { get; set; }

    }
}
