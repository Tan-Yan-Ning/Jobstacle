using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class CourseRegistration : BaseDomainModel
    {
        [Required(ErrorMessage = "Registration Date is required")]
        [FutureDate(ErrorMessage = "Registration Date must be from today onwards")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RegistrationDate { get; set; }
        [Required(ErrorMessage = "Job Seeker ID is required")]
        public int JobSeekerID { get; set; } 
        public virtual JobSeeker? JobSeeker { get; set; }
        [Required(ErrorMessage = "Course ID is required")]
        public int CourseID { get; set; }
        public virtual Course? Course { get; set; } 
    }
}
