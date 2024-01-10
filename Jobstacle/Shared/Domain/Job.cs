using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobstacle.Shared.Domain
{
    public class Job : BaseDomainModel
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public double Salary { get; set; } 

        public int CompanyID { get; set; } 
        public virtual Company? Company { get; set; }

        public int StaffID { get; set; } 
        public virtual Staff? Staff { get; set; }
        public virtual List<JobApplication>? JobApplications { get; set; }
    }
}
