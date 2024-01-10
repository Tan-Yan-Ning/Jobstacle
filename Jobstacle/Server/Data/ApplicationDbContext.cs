using Duende.IdentityServer.EntityFramework.Options;
using Jobstacle.Server.Models;
using Jobstacle.Shared.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Jobstacle.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegistration> CoursesRegistrations { get; set;}
        public DbSet<Organizer> Organizers { get; set;}
        public DbSet<Staff> Staffs { get; set;}
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

    }
}