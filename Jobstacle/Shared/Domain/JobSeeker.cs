using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class JobSeeker : BaseDomainModel
    {
        public byte[]? JobSeekerPic { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Resume is required")]
        public string? Resume { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? ContactNumber { get; set; }
        public virtual List<JobApplication>? JobApplications { get; set; }
        public virtual List<CourseRegistration>? CourseRegistrations { get; set; }



    }
}
