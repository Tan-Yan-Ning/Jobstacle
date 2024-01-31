using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class JobApplication : BaseDomainModel
    {
        [Required(ErrorMessage = "Application Date is required")]
		[DataType(DataType.Date)]
        public DateTime ApplicationDate { get; set; }

        [Required(ErrorMessage = "Job Seeker Id is required")]
        public int JobSeekerID { get; set; } 
        public virtual JobSeeker? JobSeeker { get; set; }

        [Required(ErrorMessage = "Job Id is required")]
        public int JobID { get; set; }
        public virtual Job? Job { get; set; }
    }
}
