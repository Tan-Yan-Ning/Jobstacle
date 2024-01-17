using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class Job : BaseDomainModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }
        [Required(ErrorMessage = "Company ID is required")]
        public int CompanyID { get; set; } 
        public virtual Company? Company { get; set; }
        [Required(ErrorMessage = "Staff ID is required")]
        public int StaffID { get; set; } 
        public virtual Staff? Staff { get; set; }
        public virtual List<JobApplication>? JobApplications { get; set; }
    }
}
